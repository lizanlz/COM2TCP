using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using System.Runtime.InteropServices;
using TouchSocket.Sockets;
using TouchSocket.Core.Config;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls;
using TouchSocket.Rpc.TouchRpc;
using System.Net.Sockets;
using log4net;
using System.Text.RegularExpressions;
using System.Collections;

namespace COM2TCP
{
    public partial class ControlSerial2TCP : UserControl
    {
        private static ILog log = LogManager.GetLogger(typeof(ControlSerial2TCP));

        private System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();

        private System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

        private TcpService service = new TcpService(); // TCP服务

        private ArrayList msgList = new ArrayList(); // 消息列表

        private string serialMsg = ""; // 串口消息

        private object lockObj = new object(); // 线程同步锁
        
        public int ClientCount = 0; // TCP客户端数量
        public string SPort { get; set; } // 串口号 
        public int BaudRate { get; set; } // 串口波特率 
        public int DataBits { get; set; } // 串口数据位 
        public string Parity { get; set; } // 校验位 
        public double StopBits { get; set; } // 停止位 
        public string MsgCode { get; set; } // 消息编码：ASCII, HEX
        public string MsgSeperator { get; set; } // 串口消息分割符
        public int TPort { get; set; } // TCP服务监听端口 
        public bool SPortStatus { get; set; } // 串口连接状态
        public bool TPortStatus { get; set; } // TCP监听端口开启状态
        public ControlSerial2TCP()
        {
            // 开启双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            // Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
            InitializeComponent();
            // 获取系统的串口列表，初始化
            string[] portNames = System.IO.Ports.SerialPort.GetPortNames();
            for (int i = 0; i < portNames.Length; i++)
            {
                comboBoxSerialPort.Items.Add(portNames[i]);
            }
            toggleSerialPortConfig(true);
            toggleTCPServiceConfig(true);
        }

        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
        private void comboBoxSerialPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 串口选择框变化
            SPort = comboBoxSerialPort.SelectedItem.ToString();
        }
        private void comboBoxBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 波特率选择框变化
            BaudRate = int.Parse(comboBoxBaudRate.SelectedItem.ToString());
        }
        private void comboBoxDataBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 数据位选择框变化
            DataBits = int.Parse(comboBoxDataBit.SelectedItem.ToString());
        }
        private void comboBoxCheckBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 校验位选择框变化
            Parity = comboBoxCheckBit.SelectedItem.ToString();
        }
        private void comboBoxStopBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 停止位选择框变化
            StopBits = double.Parse(comboBoxStopBit.SelectedItem.ToString());
        }
        private void radioButtonASCII_CheckedChanged(object sender, EventArgs e)
        {
            // ASCII单选框选择事件
            MsgCode = "ASCII";
        }
        private void radioButtonHEX_CheckedChanged(object sender, EventArgs e)
        {
            // HEX单选框选择事件
            MsgCode = "HEX";
        }
        private void textBoxMsgSeperator_TextChanged(object sender, EventArgs e)
        {
            // 消息分割符变化事件
            MsgSeperator = textBoxMsgSeperator.Text;
        }
        private void buttonSerialPortConn_Click(object sender, EventArgs e)
        {
            // 串口连接按钮事件
            if (!checkSerialPortConfig())
            {
                MessageBox.Show("串口设置错误，请检查", "错误提示");
                return;
            }
            if (createSerialPortConn())
            {
                // 建立串口连接后，禁用串口设置选项
                toggleSerialPortConfig(false);
            }
        }
        private void buttonSerialPortClose_Click(object sender, EventArgs e)
        {
            // 串口连接断开事件
            if (!SPortStatus)
            {
                MessageBox.Show("串口尚未建立连接，无需断开", "错误提示");
                return;
            }
            else
            {
                // 串口断开连接
                closeSerialPortConn();
            }
        }
        private void textBoxTCPListenPort_TextChanged(object sender, EventArgs e)
        {
            // TCP服务监听端口变化事件
            if (textBoxTCPListenPort.Text.Trim().Length > 0)
            {
                TPort = int.Parse(textBoxTCPListenPort.Text);
            }
            else
            {
                TPort = 0;
            }
        }
        private void textBoxTCPListenPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 限制只能输入数字
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (byte)(e.KeyChar) == 8)//8就是回格，backspace(删除).
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxMsg_TextChanged(object sender, EventArgs e)
        {
            /*this.textBoxMsg.SelectionStart = this.textBoxMsg.Text.Length;
            this.textBoxMsg.ScrollToCaret();*/
        }
        private void buttonTCPServiceStart_Click(object sender, EventArgs e)
        {
            // TCP服务开启事件
            if (!checkTCPServiceConfig())
            {
                MessageBox.Show("TCP监听端口设置错误，请检查", "错误提示");
                return;
            }
            if (startTCPService())
            {
                // 建立TCP服务后，禁用TCP设置选项
                toggleTCPServiceConfig(false);
            }
        }
        private void buttonTCPServiceStop_Click(object sender, EventArgs e)
        {
            // TCP服务停止事件
            if (!TPortStatus)
            {
                MessageBox.Show("TCP服务尚未开启，无需停止", "错误提示");
                return;
            }
            else
            {
                // 服务停止
                stopTCPService();
            }
        }
        public void refreshControl()
        {
            // 刷新页面控件
            if (SPort == null || string.Equals(SPort, ""))
            {
                comboBoxSerialPort.SelectedIndex = 0;
            }
            else
            {
                comboBoxSerialPort.SelectedIndex = comboBoxSerialPort.Items.IndexOf(SPort);
            }
            comboBoxBaudRate.SelectedIndex = comboBoxBaudRate.Items.IndexOf(BaudRate.ToString());
            comboBoxDataBit.SelectedIndex = comboBoxDataBit.Items.IndexOf(DataBits.ToString());
            comboBoxCheckBit.SelectedIndex = comboBoxCheckBit.Items.IndexOf(Parity);
            comboBoxStopBit.SelectedIndex = comboBoxStopBit.Items.IndexOf(StopBits.ToString());
            if (string.Equals(MsgCode, "ASCII"))
            {
                radioButtonASCII.Checked = true;
            }
            else if (string.Equals(MsgCode, "HEX"))
            {
                radioButtonHEX.Checked = true;
            }
            textBoxMsgSeperator.Text = MsgSeperator;
            textBoxTCPListenPort.Text = TPort.ToString();
        }

        public void clearMsg()
        {
            msgList.Clear();
            textBoxMsg.Clear();
        }
        public bool checkSerialPortConfig()
        {
            // 检查串口配置
            return !(string.Equals(SPort, "") || BaudRate == 0 || DataBits == 0 ||
                string.Equals(Parity, "") || StopBits == 0 || string.Equals(MsgCode, ""));
        }

        public bool checkTCPServiceConfig()
        {
            // 检查TCP监听端口配置
            return !(TPort == 0);
        }
        public void toggleSerialPortConfig(bool enabled)
        {
            // 开关串口配置选项
            comboBoxSerialPort.Enabled = enabled;
            comboBoxBaudRate.Enabled = enabled;
            comboBoxDataBit.Enabled = enabled;
            comboBoxCheckBit.Enabled = enabled;
            comboBoxStopBit.Enabled = enabled;
            radioButtonASCII.Enabled = enabled;
            radioButtonHEX.Enabled = enabled;
            textBoxMsgSeperator.Enabled = enabled;
            buttonSerialPortConn.Enabled = enabled;
            buttonSerialPortClose.Enabled = !enabled;
        }
        public void toggleTCPServiceConfig(bool enabled)
        {
            // 开关TCP服务配置选项
            textBoxTCPListenPort.Enabled = enabled;
            buttonTCPServiceStart.Enabled = enabled;
            buttonTCPServiceStop.Enabled = !enabled;
        }
        public bool createSerialPortConn()
        {
            try
            {
                // 创建串口连接
                // 串口
                serialPort.PortName = SPort;
                // 波特率
                serialPort.BaudRate = BaudRate;
                // 数据位
                serialPort.DataBits = DataBits;
                // 校验位
                if (string.Equals(Parity, "None"))
                {
                    serialPort.Parity = System.IO.Ports.Parity.None;
                }
                else if (string.Equals(Parity, "Odd"))
                {
                    serialPort.Parity = System.IO.Ports.Parity.Odd;
                }
                else if (string.Equals(Parity, "Even"))
                {
                    serialPort.Parity = System.IO.Ports.Parity.Even;
                }
                else if (string.Equals(Parity, "Mark"))
                {
                    serialPort.Parity = System.IO.Ports.Parity.Mark;
                }
                else if (string.Equals(Parity, "Space"))
                {
                    serialPort.Parity = System.IO.Ports.Parity.Space;
                }
                // 停止位
                if (StopBits == 1)
                {
                    serialPort.StopBits = System.IO.Ports.StopBits.One;
                }
                else if (StopBits == 1.5)
                {
                    serialPort.StopBits = System.IO.Ports.StopBits.OnePointFive;
                }
                else if (StopBits == 2)
                {
                    serialPort.StopBits = System.IO.Ports.StopBits.Two;
                }
                // serialPort.ReadTimeout
                // 接收串口数据
                serialPort.DataReceived += new SerialDataReceivedEventHandler(serialDataReceiveed);

                // 打开串口
                if (!serialPort.IsOpen)
                {
                    serialPort.Open();
                    SPortStatus = true;
                    labelSPortStatus.Text = "已连接";
                    labelSPortStatus.ForeColor = Color.Green; //颜色 
                    toggleSerialPortConfig(false);
                }
            }
            catch (Exception e)
            {
                serialPort.Dispose(); // 可以释放这个对象，还可以连接
                MessageBox.Show(e.Message, "串口连接错误");
                log.Error("串口连接错误", e);
                return false;
            }
            return true;
        }

        public bool closeSerialPortConn()
        {
            lock (lockObj)
            {
                // 关闭串口
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                    SPortStatus = false;
                    labelSPortStatus.Text = "未连接";
                    labelSPortStatus.ForeColor = Color.Red; //颜色 
                    toggleSerialPortConfig(true);
                    return true;
                }
                return false;
            }
        }
        public bool startTCPService()
        {
            try
            {
                // 开启TCP服务
                service.Connecting += (client, e) => { };//有客户端正在连接
                service.Connected += (client, e) => { ClientCount++; };//有客户端连接
                service.Disconnected += (client, e) => { ClientCount--; };//有客户端断开连接
                service.Received += (client, byteBlock, requestInfo) =>
                {
                    //从TCP客户端收到信息
                    string msg = ASCII.GetString(byteBlock.Buffer, 0, byteBlock.Len);

                    //消息转给串口
                    if (string.Equals(this.MsgCode, "ASCII"))
                    {
                        try
                        {
                            serialPort.Write(msg);
                        }
                        catch (Exception e)
                        {
                            SetText("【" + DateTime.Now.ToString() + "  (TCP <-> 串口)】【写入数据失败】" + msg + "\r\n");
                            log.Error("TCP向串口写入数据失败", e);
                        }
                    }
                    else
                    {
                        try
                        {
                            byte[] msgByte = HexStringToBytes(msg);
                            serialPort.Write(msgByte, 0, msgByte.Length);
                        }
                        catch (Exception e)
                        {
                            SetText("【" + DateTime.Now.ToString() + "  (TCP <-> 串口)】【写入数据失败】" + msg + "\r\n");
                            log.Error("TCP向串口写入数据失败", e);
                        }
                    }

                    //将消息显示出来（非控件线程不能直接访问控件，需要通过委托的方式访问）
                    SetText("【" + DateTime.Now.ToString() + "  (TCP <-> 串口)】" + msg + "\r\n");
                };

                service.Setup(new TouchSocketConfig()//载入配置     
                    .SetListenIPHosts(new IPHost[] { new IPHost(TPort) })
                    .SetMaxCount(10000)
                    .SetThreadCount(10)
                    // 清理无数据交互的SocketClient（单位：毫秒），默认60000 毫秒。
                    // 如果不想清除，可使用-1。但是，并不建议设置-1，因为假如有客户端因为网络故障导致僵死的话，服务器将永久保留其实例。
                    // 所以最好的方式是按照自己的业务需要，设置对应值，因为从普遍性而言，无数据交互的客户端，如果时间超出10s，
                    // 则断开的策略是优于一直连接的。或者，自己规定心跳数据包，保持客户端活性
                    .SetClearInterval(-1)
                    .ConfigurePlugins(a =>
                    {
                        //a.Add();//此处可以添加插件
                    })
                    .ConfigureContainer(a =>
                    {

                    }))
                    .Start();//启动
                TPortStatus = true;
                labelTCPStatus.Text = "已开启";
                labelTCPStatus.ForeColor = Color.Green; //颜色 
                toggleTCPServiceConfig(false);
            }
            catch (Exception e)
            {
                // service.Dispose(); // 不能释放这个对象，否则不能再连了
                MessageBox.Show(e.Message, "TCP服务开启错误");
                log.Error("TCP服务开启错误", e);
                return false;
            }
            return true;
        }

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);


        // This method demonstrates a pattern for making thread-safe
        // calls on a Windows Forms control. 
        //
        // If the calling thread is different from the thread that
        // created the TextBox control, this method creates a
        // SetTextCallback and calls itself asynchronously using the
        // Invoke method.
        //
        // If the calling thread is the same as the thread that created
        // the TextBox control, the Text property is set directly.
        public void SetText(string text)
        {
            lock (lockObj) // 加锁，防止刷新UI的同时，关闭串口导致的界面卡顿
            {
                // InvokeRequired required compares the thread ID of the
                // calling thread to the thread ID of the creating thread.
                // If these threads are different, it returns true.
                if (this.textBoxMsg.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.BeginInvoke(d, new object[] { text });
                }
                else
                {
                    int maxLine = 10000;//最大显示行数
                    if (msgList.Count >= maxLine)
                    {
                        msgList = msgList.GetRange(maxLine / 2, maxLine / 2);
                        this.textBoxMsg.Text = String.Join("", msgList);
                        this.textBoxMsg.SelectionStart = this.textBoxMsg.Text.Length;
                        this.textBoxMsg.ScrollToCaret();
                    }
                    msgList.Add(text);
                    this.textBoxMsg.AppendText(text);
                }
            }
        }
        public bool stopTCPService()
        {
            // 停止TCP服务
            if (service.ServerState == ServerState.Running)
            {
                service.Stop();
                TPortStatus = false;
                labelTCPStatus.Text = "未开启";
                labelTCPStatus.ForeColor = Color.Red; //颜色 
                toggleTCPServiceConfig(true);
            }
            return false;

        }
        public void serialDataReceiveed(object sender, SerialDataReceivedEventArgs e)
        {
            lock (lockObj) // 控制对的并发访问
            {
                // 接收串口数据
                SerialPort _SerialPort = (SerialPort)sender;
                int bytesToRead = _SerialPort.BytesToRead;
                byte[] recvData = new byte[bytesToRead];
                _SerialPort.Read(recvData, 0, bytesToRead);
                if (string.Equals(MsgCode, "ASCII"))
                {
                    string msg = ASCII.GetString(recvData);
                    if (string.Equals(msg, ""))
                    {
                        // 空字符串不发送
                        return;
                    }
                    if (!(string.Equals(MsgSeperator, "") || MsgSeperator == null))
                    {
                        // 1、字符串类型的串口消息按分割符处理
                        serialMsg += msg;
                        string seperator = MsgSeperator.Replace("\\r", "\r").Replace("\\n", "\n");
                        while (serialMsg.Length > 0 && serialMsg.IndexOf(seperator) != -1)
                        {
                            msg = serialMsg.Substring(0, serialMsg.IndexOf(seperator) + seperator.Length);
                            serialMsg = serialMsg.Substring(serialMsg.IndexOf(seperator) + seperator.Length);
                            //将收到的信息返回给在线的所有客户端
                            string[] ids = service.GetIDs();
                            foreach (string id in ids)
                            {
                                try
                                {
                                    service.Send(id, msg);
                                }
                                catch (Exception exception)
                                {
                                    SetText("【" + DateTime.Now.ToString() + "  (串口 <-> TCP)】【写入数据失败】" + msg + "\r\n");
                                    log.Error("串口向TCP客户端写入数据失败", exception);
                                }
                            }
                            SetText("【" + DateTime.Now.ToString() + "  (串口 <-> TCP)】" + msg + "\r\n");
                            // SetListText(DateTime.Now.ToString(), "(串口 <-> TCP)", msg);
                        }
                    }
                    else
                    {
                        // 2、直接发送
                        //将收到的信息返回给在线的所有客户端
                        string[] ids = service.GetIDs();
                        foreach (string id in ids)
                        {
                            try
                            {
                                service.Send(id, msg);
                            }
                            catch (Exception exception)
                            {
                                SetText("【" + DateTime.Now.ToString() + "  (串口 <-> TCP)】【写入数据失败】" + msg + "\r\n");
                                log.Error("串口向TCP客户端写入数据失败", exception);
                            }
                        }
                        SetText("【" + DateTime.Now.ToString() + "  (串口 <-> TCP)】" + msg + "\r\n");
                        // SetListText(DateTime.Now.ToString(), "(串口 <-> TCP)", msg);
                    }

                }
                else
                {
                    // 16进制数组转成字符串输出
                    string msg = BitConverter.ToString(recvData).Replace("-", "");
                    if (string.Equals(msg, ""))
                    {
                        // 空字符串不发送
                        return;
                    }
                    //将收到的信息返回给在线的所有客户端
                    string[] ids = service.GetIDs();
                    foreach (string id in ids)
                    {
                        try
                        {
                            service.Send(id, msg);
                        }
                        catch (Exception exception)
                        {
                            SetText("【" + DateTime.Now.ToString() + "  (串口 <-> TCP)】【写入数据失败】" + msg + "\r\n");
                            log.Error("串口向TCP客户端写入数据失败", exception);
                        }
                    }
                    SetText("【" + DateTime.Now.ToString() + "  (串口 <-> TCP)】" + msg + "\r\n");
                    // SetListText(DateTime.Now.ToString(), "(串口 <-> TCP)", msg);
                }
            }

        }
        public byte[] HexStringToBytes(string hs)
        {
            string msg = hs.Trim();
            int length = (int)Math.Ceiling(msg.Length / 2.0);
            string[] strArr = new string[length];
            if (msg.IndexOf(' ') != -1)
            {
                // 按空格分割
                strArr = msg.Split(' ');
            }
            else
            {
                // 按每2个字符做分割
                for (int i = 0; i < msg.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        strArr[i / 2] = "";
                    }
                    strArr[i / 2] = strArr[i / 2] + msg[i];
                }
            }
            byte[] b = new byte[strArr.Length];
            //逐个字符变为16进制字节数据
            for (int i = 0; i < strArr.Length; i++)
            {
                b[i] = Convert.ToByte(strArr[i], 16);
            }
            //按照指定编码将字节数组变为字符串
            return b;
        }
    }
}