using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace COM2TCP
{
    public partial class Form : System.Windows.Forms.Form
    {
        private static ILog log = LogManager.GetLogger(typeof(Form));
        private const int WM_DEVICECHANGE = 0x219; //设备改变
        private const int DBT_DEVICEARRIVAL = 0x8000; //检测到新设备
        private const int DBT_DEVICEREMOVECOMPLETE = 0x8004; //移除设备

        private ArrayList tabPageList = new ArrayList(); // tab标签页
        private ArrayList serial2TCPList = new ArrayList(); // 自定义控件
        private ArrayList configList = new ArrayList(); // 串口转TCP配置
        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // 加载配置文件
            loadConfig();
            // 初始化连接
            renderPage();
            // 定时清理内存
            timerClear();
            // 启动日志
            log.Info("串口转TCP连接程序启动成功");
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            // 自动连接全部
            this.buttonConnAll.PerformClick();
        }
        private void loadConfig()
        {
            // AppSettings是NameValueConnection类型，使用AllKeys返回一个所有Key组成的字符串数组
            string[] keys = ConfigurationManager.AppSettings.AllKeys;
            for (int i = 0; i < keys.Length; i++)
            {
                string key = keys[i];
                //通过Key来索引Value
                string value = ConfigurationManager.AppSettings[key];
                string[] list = value.Split(';');
                if (list.Length != 8)
                {
                    MessageBox.Show("串口连接转TCP连接配置错误，配置节点：" + key, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ConfigInfo config = new ConfigInfo();
                    config.TabName = key;
                    config.SPort = list[0];
                    config.BaudRate = int.Parse(list[1]);
                    config.DataBits = int.Parse(list[2]);
                    config.Parity = list[3];
                    config.StopBits = double.Parse(list[4]);
                    config.MsgCode = list[5];
                    config.TPort = int.Parse(list[6]);
                    config.MsgSeperator = list[7];
                    configList.Add(config);
                }
            }
        }
        private void renderPage()
        {
            if (configList.Count > 0)
            {
                for (int i = 0; i < configList.Count; i++)
                {
                    addOldConn((ConfigInfo)configList[i]);
                }
            }
        }
        private void addOldConn(ConfigInfo config)
        {
            TabPage tabPage = new TabPage();
            ControlSerial2TCP controlSerial2TCP = new ControlSerial2TCP();
            tabPageList.Add(tabPage);
            serial2TCPList.Add(controlSerial2TCP);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(tabPage);

            // 
            // tabPage
            // 
            tabPage.Controls.Add(controlSerial2TCP);
            tabPage.Location = new System.Drawing.Point(4, 25);
            tabPage.Name = "tabPage" + tabPageList.Count;
            tabPage.Padding = new System.Windows.Forms.Padding(3);
            tabPage.Size = new System.Drawing.Size(1151, 537);
            tabPage.TabIndex = tabPageList.Count - 1;
            tabPage.Text = config.TabName;
            tabPage.UseVisualStyleBackColor = true;
            // 
            // controlSerial2TCP
            // 
            controlSerial2TCP.BaudRate = config.BaudRate;
            controlSerial2TCP.DataBits = config.DataBits;
            controlSerial2TCP.Location = new System.Drawing.Point(3, 5);
            controlSerial2TCP.MsgCode = config.MsgCode;
            controlSerial2TCP.MsgSeperator = config.MsgSeperator;
            controlSerial2TCP.Name = "controlSerial2TCP" + tabPageList.Count;
            controlSerial2TCP.Parity = config.Parity;
            controlSerial2TCP.SPort = config.SPort; // 这个不能赋值为空字符串
            controlSerial2TCP.Size = new System.Drawing.Size(1141, 525);
            controlSerial2TCP.SPortStatus = false;
            controlSerial2TCP.StopBits = config.StopBits;
            controlSerial2TCP.TabIndex = tabPageList.Count - 1;
            controlSerial2TCP.TPort = config.TPort;
            controlSerial2TCP.TPortStatus = false;

            // 刷新自定义控件页面
            controlSerial2TCP.refreshControl();

        }
        private void addNewConn()
        {
            TabPage tabPage = new TabPage();
            ControlSerial2TCP controlSerial2TCP = new ControlSerial2TCP();
            tabPageList.Add(tabPage);
            serial2TCPList.Add(controlSerial2TCP);

            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(tabPage);

            // 
            // tabPage
            // 
            tabPage.Controls.Add(controlSerial2TCP);
            tabPage.Location = new System.Drawing.Point(4, 25);
            tabPage.Name = "tabPage" + tabPageList.Count;
            tabPage.Padding = new System.Windows.Forms.Padding(3);
            tabPage.Size = new System.Drawing.Size(1151, 537);
            tabPage.TabIndex = tabPageList.Count - 1;
            tabPage.Text = "连接" + tabPageList.Count;
            tabPage.UseVisualStyleBackColor = true;
            // 
            // controlSerial2TCP
            // 
            controlSerial2TCP.BaudRate = 9600;
            controlSerial2TCP.DataBits = 8;
            controlSerial2TCP.Location = new System.Drawing.Point(3, 5);
            controlSerial2TCP.MsgCode = "ASCII";
            controlSerial2TCP.MsgSeperator = "";
            controlSerial2TCP.Name = "controlSerial2TCP" + tabPageList.Count;
            controlSerial2TCP.Parity = "None";
            controlSerial2TCP.Size = new System.Drawing.Size(1141, 525);
            controlSerial2TCP.SPortStatus = false;
            controlSerial2TCP.StopBits = 1D;
            controlSerial2TCP.TabIndex = tabPageList.Count - 1;
            controlSerial2TCP.TPort = 8000 + tabPageList.Count;
            controlSerial2TCP.TPortStatus = false;

            // 刷新自定义控件页面
            controlSerial2TCP.refreshControl();
        }
        private void delCurConn()
        {
            if (tabPageList.Count == 0)
            {
                MessageBox.Show("没有连接可以删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // 获取当前活动的tab页
            int index = this.tabControl.SelectedIndex;
            TabPage tabPage = (TabPage)tabPageList[index];
            // 关闭串口连接和TCP服务
            ControlSerial2TCP controlSerial2TCP = (ControlSerial2TCP)serial2TCPList[index];
            if (controlSerial2TCP.SPortStatus)
            {
                controlSerial2TCP.closeSerialPortConn();
            }
            if (controlSerial2TCP.TPortStatus)
            {
                controlSerial2TCP.stopTCPService();
            }
            controlSerial2TCP.Dispose();
            // 销毁tab页
            this.tabControl.Controls.Remove(tabPage);
            tabPage.Controls.Clear();
            tabPage.Dispose();
            // 删除数据
            tabPageList.RemoveAt(index);
            serial2TCPList.RemoveAt(index);
        }
        private void buttonAddConn_Click(object sender, EventArgs e)
        {
            // 添加新串口转TCP连接
            DialogResult dr = MessageBox.Show("确认添加新串口转TCP连接？", "添加连接", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                addNewConn();
            }
        }
        private void buttonDelConn_Click(object sender, EventArgs e)
        {
            // 删除新串口转TCP连接
            DialogResult dr = MessageBox.Show("确认删除当前串口转TCP连接？", "删除连接", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                delCurConn();
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            string file = System.Windows.Forms.Application.ExecutablePath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            ArrayList keyList = new ArrayList();
            // 更新和保存节点
            for (int i = 0; i < tabPageList.Count; i++)
            {
                TabPage tabPage = (TabPage)tabPageList[i];
                ControlSerial2TCP controlSerial2TCP = (ControlSerial2TCP)serial2TCPList[i];

                string key = tabPage.Text;
                string value = controlSerial2TCP.SPort + ";"
                    + controlSerial2TCP.BaudRate + ";"
                    + controlSerial2TCP.DataBits + ";"
                    + controlSerial2TCP.Parity + ";"
                    + controlSerial2TCP.StopBits + ";"
                    + controlSerial2TCP.MsgCode + ";"
                    + controlSerial2TCP.TPort + ";"
                    + controlSerial2TCP.MsgSeperator;
                keyList.Add(key);

                if (config.AppSettings.Settings.AllKeys.Contains(key))
                {
                    //判断是否包含节点
                    config.AppSettings.Settings[key].Value = value;
                }
                else
                {
                    //添加节点
                    config.AppSettings.Settings.Add(key, value);
                }
            }
            // 删除多余节点
            string[] keys = config.AppSettings.Settings.AllKeys;
            for (int i = 0; i < keys.Length; i++)
            {
                string key = keys[i];
                if (!keyList.Contains(key))
                {
                    //删除节点
                    config.AppSettings.Settings.Remove(key);
                }
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            MessageBox.Show("所有串口转TCP连接配置保存成功！", "保存", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonConnAll_Click(object sender, EventArgs e)
        {
            // 所有tab页，全部连接
            for (int i = 0; i < serial2TCPList.Count; i++)
            {
                ControlSerial2TCP controlSerial2TCP = (ControlSerial2TCP)serial2TCPList[i];
                controlSerial2TCP.createSerialPortConn();
                controlSerial2TCP.startTCPService();
            }

        }

        private void buttonCloseAll_Click(object sender, EventArgs e)
        {
            // 所有tab页，全部连接
            for (int i = 0; i < serial2TCPList.Count; i++)
            {
                ControlSerial2TCP controlSerial2TCP = (ControlSerial2TCP)serial2TCPList[i];
                controlSerial2TCP.closeSerialPortConn();
                controlSerial2TCP.stopTCPService();
            }
        }

        private void buttonClearMsg_Click(object sender, EventArgs e)
        {
            // 清空当前Tab页消息
            DialogResult dr = MessageBox.Show("确认删除当前窗口消息？", "清空消息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                clearMsg();
            }
            
        }

        private void clearMsg()
        {
            // 获取当前活动的tab页
            int index = this.tabControl.SelectedIndex;
            // 关闭串口连接和TCP服务
            ControlSerial2TCP controlSerial2TCP = (ControlSerial2TCP)serial2TCPList[index];
            controlSerial2TCP.clearMsg();
        }

        protected override void WndProc(ref Message m)
        {
            int devType;
            // 监听设备变化事件
            base.WndProc(ref m);//调用父类方法，以确保其他功能正常
            switch (m.Msg)
            {
                
                case WM_DEVICECHANGE://设备改变事件
                    switch ((int)m.WParam)
                    {
                        case DBT_DEVICEARRIVAL:
                            devType = Marshal.ReadInt32(m.LParam, 4);
                            log.Info("新设备连接事件，设备类型:" + devType);
                            break;

                        case DBT_DEVICEREMOVECOMPLETE:
                            devType = Marshal.ReadInt32(m.LParam, 4);
                            log.Warn("设备移除，设备类型:" + devType);
                            break;
                    }
                    //刷新串口设备

                    break;
            }
        }

        public void timerClear()
        {
            // 定时清理内存
            System.Timers.Timer t = new System.Timers.Timer(5000); //实例化Timer类，设置间隔时间为10000毫秒；
            t.Elapsed += new System.Timers.ElapsedEventHandler(Excute); //到达时间的时候执行事件；
            t.AutoReset = true; //设置是执行一次（false）还是一直执行(true)；
            t.Enabled = true; //是否执行System.Timers.Timer.Elapsed事件；
            t.Start();  //启动定时器
        }
        public static void Excute(object source, System.Timers.ElapsedEventArgs e)
        {
            ClearMemory();
        }

        /// <summary>
        /// 刷新内存
        /// </summary>
        public static void ClearMemory()
        {
            GarbageCollect();

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }

        /// <summary>
        /// 主动通知系统进行垃圾回收
        /// </summary>
        public static void GarbageCollect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        /// <summary>
        /// 把不频繁执行或者已经很久没有执行的代码,没有必要留在物理内存中,只会造成浪费;放在虚拟内存中,等执行这部分代码的时候,再调出来
        /// </summary>
        /// <param name="process"></param>
        /// <param name="minSize"></param>
        /// <param name="maxSize"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern bool SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);

        
    }
}
