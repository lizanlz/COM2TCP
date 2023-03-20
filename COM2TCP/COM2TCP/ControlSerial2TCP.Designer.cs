namespace COM2TCP
{
    partial class ControlSerial2TCP
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonSerialPortConn = new System.Windows.Forms.Button();
            this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
            this.labelSerialPort = new System.Windows.Forms.Label();
            this.textBoxTCPListenPort = new System.Windows.Forms.TextBox();
            this.radioButtonASCII = new System.Windows.Forms.RadioButton();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.groupBoxSerialPortSetting = new System.Windows.Forms.GroupBox();
            this.labelMsgSeperator = new System.Windows.Forms.Label();
            this.buttonSerialPortClose = new System.Windows.Forms.Button();
            this.textBoxMsgSeperator = new System.Windows.Forms.TextBox();
            this.radioButtonHEX = new System.Windows.Forms.RadioButton();
            this.comboBoxStopBit = new System.Windows.Forms.ComboBox();
            this.labelStopBit = new System.Windows.Forms.Label();
            this.comboBoxCheckBit = new System.Windows.Forms.ComboBox();
            this.labelCheckBit = new System.Windows.Forms.Label();
            this.comboBoxDataBit = new System.Windows.Forms.ComboBox();
            this.labelDataBit = new System.Windows.Forms.Label();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.labelBaudRate = new System.Windows.Forms.Label();
            this.groupBoxTCPServiceSetting = new System.Windows.Forms.GroupBox();
            this.buttonTCPServiceStop = new System.Windows.Forms.Button();
            this.buttonTCPServiceStart = new System.Windows.Forms.Button();
            this.labelTCPListenPort = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.textBoxMsg = new System.Windows.Forms.TextBox();
            this.labelSerialPortConnStatus = new System.Windows.Forms.Label();
            this.labelSPortStatus = new System.Windows.Forms.Label();
            this.labelTCPServiceStatus = new System.Windows.Forms.Label();
            this.labelTCPStatus = new System.Windows.Forms.Label();
            this.groupBoxSerialPortSetting.SuspendLayout();
            this.groupBoxTCPServiceSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSerialPortConn
            // 
            this.buttonSerialPortConn.Location = new System.Drawing.Point(20, 212);
            this.buttonSerialPortConn.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSerialPortConn.Name = "buttonSerialPortConn";
            this.buttonSerialPortConn.Size = new System.Drawing.Size(56, 24);
            this.buttonSerialPortConn.TabIndex = 0;
            this.buttonSerialPortConn.Text = "连接";
            this.buttonSerialPortConn.UseVisualStyleBackColor = true;
            this.buttonSerialPortConn.Click += new System.EventHandler(this.buttonSerialPortConn_Click);
            // 
            // comboBoxSerialPort
            // 
            this.comboBoxSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSerialPort.FormattingEnabled = true;
            this.comboBoxSerialPort.Location = new System.Drawing.Point(63, 19);
            this.comboBoxSerialPort.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSerialPort.Name = "comboBoxSerialPort";
            this.comboBoxSerialPort.Size = new System.Drawing.Size(121, 20);
            this.comboBoxSerialPort.TabIndex = 1;
            this.comboBoxSerialPort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSerialPort_SelectedIndexChanged);
            // 
            // labelSerialPort
            // 
            this.labelSerialPort.AutoSize = true;
            this.labelSerialPort.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSerialPort.Location = new System.Drawing.Point(17, 22);
            this.labelSerialPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSerialPort.Name = "labelSerialPort";
            this.labelSerialPort.Size = new System.Drawing.Size(41, 12);
            this.labelSerialPort.TabIndex = 2;
            this.labelSerialPort.Text = "串  口";
            // 
            // textBoxTCPListenPort
            // 
            this.textBoxTCPListenPort.Location = new System.Drawing.Point(72, 22);
            this.textBoxTCPListenPort.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTCPListenPort.Name = "textBoxTCPListenPort";
            this.textBoxTCPListenPort.Size = new System.Drawing.Size(112, 21);
            this.textBoxTCPListenPort.TabIndex = 3;
            this.textBoxTCPListenPort.TextChanged += new System.EventHandler(this.textBoxTCPListenPort_TextChanged);
            this.textBoxTCPListenPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTCPListenPort_KeyPress);
            // 
            // radioButtonASCII
            // 
            this.radioButtonASCII.AutoSize = true;
            this.radioButtonASCII.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonASCII.Location = new System.Drawing.Point(20, 144);
            this.radioButtonASCII.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonASCII.Name = "radioButtonASCII";
            this.radioButtonASCII.Size = new System.Drawing.Size(53, 16);
            this.radioButtonASCII.TabIndex = 4;
            this.radioButtonASCII.TabStop = true;
            this.radioButtonASCII.Text = "ASCII";
            this.radioButtonASCII.UseVisualStyleBackColor = true;
            this.radioButtonASCII.CheckedChanged += new System.EventHandler(this.radioButtonASCII_CheckedChanged);
            // 
            // groupBoxSerialPortSetting
            // 
            this.groupBoxSerialPortSetting.Controls.Add(this.labelMsgSeperator);
            this.groupBoxSerialPortSetting.Controls.Add(this.buttonSerialPortClose);
            this.groupBoxSerialPortSetting.Controls.Add(this.textBoxMsgSeperator);
            this.groupBoxSerialPortSetting.Controls.Add(this.radioButtonHEX);
            this.groupBoxSerialPortSetting.Controls.Add(this.comboBoxStopBit);
            this.groupBoxSerialPortSetting.Controls.Add(this.buttonSerialPortConn);
            this.groupBoxSerialPortSetting.Controls.Add(this.radioButtonASCII);
            this.groupBoxSerialPortSetting.Controls.Add(this.labelStopBit);
            this.groupBoxSerialPortSetting.Controls.Add(this.comboBoxCheckBit);
            this.groupBoxSerialPortSetting.Controls.Add(this.labelCheckBit);
            this.groupBoxSerialPortSetting.Controls.Add(this.comboBoxDataBit);
            this.groupBoxSerialPortSetting.Controls.Add(this.labelDataBit);
            this.groupBoxSerialPortSetting.Controls.Add(this.comboBoxBaudRate);
            this.groupBoxSerialPortSetting.Controls.Add(this.labelBaudRate);
            this.groupBoxSerialPortSetting.Controls.Add(this.comboBoxSerialPort);
            this.groupBoxSerialPortSetting.Controls.Add(this.labelSerialPort);
            this.groupBoxSerialPortSetting.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxSerialPortSetting.Location = new System.Drawing.Point(2, 2);
            this.groupBoxSerialPortSetting.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxSerialPortSetting.Name = "groupBoxSerialPortSetting";
            this.groupBoxSerialPortSetting.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxSerialPortSetting.Size = new System.Drawing.Size(192, 250);
            this.groupBoxSerialPortSetting.TabIndex = 5;
            this.groupBoxSerialPortSetting.TabStop = false;
            this.groupBoxSerialPortSetting.Text = "串口设置";
            // 
            // labelMsgSeperator
            // 
            this.labelMsgSeperator.AutoSize = true;
            this.labelMsgSeperator.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMsgSeperator.Location = new System.Drawing.Point(4, 178);
            this.labelMsgSeperator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMsgSeperator.Name = "labelMsgSeperator";
            this.labelMsgSeperator.Size = new System.Drawing.Size(65, 12);
            this.labelMsgSeperator.TabIndex = 16;
            this.labelMsgSeperator.Text = "消息分割符";
            // 
            // buttonSerialPortClose
            // 
            this.buttonSerialPortClose.Location = new System.Drawing.Point(127, 212);
            this.buttonSerialPortClose.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSerialPortClose.Name = "buttonSerialPortClose";
            this.buttonSerialPortClose.Size = new System.Drawing.Size(56, 24);
            this.buttonSerialPortClose.TabIndex = 12;
            this.buttonSerialPortClose.Text = "断开";
            this.buttonSerialPortClose.UseVisualStyleBackColor = true;
            this.buttonSerialPortClose.Click += new System.EventHandler(this.buttonSerialPortClose_Click);
            // 
            // textBoxMsgSeperator
            // 
            this.textBoxMsgSeperator.Location = new System.Drawing.Point(72, 174);
            this.textBoxMsgSeperator.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxMsgSeperator.Name = "textBoxMsgSeperator";
            this.textBoxMsgSeperator.Size = new System.Drawing.Size(112, 21);
            this.textBoxMsgSeperator.TabIndex = 15;
            this.textBoxMsgSeperator.TextChanged += new System.EventHandler(this.textBoxMsgSeperator_TextChanged);
            // 
            // radioButtonHEX
            // 
            this.radioButtonHEX.AutoSize = true;
            this.radioButtonHEX.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonHEX.Location = new System.Drawing.Point(144, 144);
            this.radioButtonHEX.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonHEX.Name = "radioButtonHEX";
            this.radioButtonHEX.Size = new System.Drawing.Size(41, 16);
            this.radioButtonHEX.TabIndex = 11;
            this.radioButtonHEX.TabStop = true;
            this.radioButtonHEX.Text = "HEX";
            this.radioButtonHEX.UseVisualStyleBackColor = true;
            this.radioButtonHEX.CheckedChanged += new System.EventHandler(this.radioButtonHEX_CheckedChanged);
            // 
            // comboBoxStopBit
            // 
            this.comboBoxStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStopBit.FormattingEnabled = true;
            this.comboBoxStopBit.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.comboBoxStopBit.Location = new System.Drawing.Point(63, 112);
            this.comboBoxStopBit.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxStopBit.Name = "comboBoxStopBit";
            this.comboBoxStopBit.Size = new System.Drawing.Size(121, 20);
            this.comboBoxStopBit.TabIndex = 9;
            this.comboBoxStopBit.SelectedIndexChanged += new System.EventHandler(this.comboBoxStopBit_SelectedIndexChanged);
            // 
            // labelStopBit
            // 
            this.labelStopBit.AutoSize = true;
            this.labelStopBit.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStopBit.Location = new System.Drawing.Point(17, 114);
            this.labelStopBit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStopBit.Name = "labelStopBit";
            this.labelStopBit.Size = new System.Drawing.Size(41, 12);
            this.labelStopBit.TabIndex = 10;
            this.labelStopBit.Text = "停止位";
            // 
            // comboBoxCheckBit
            // 
            this.comboBoxCheckBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCheckBit.FormattingEnabled = true;
            this.comboBoxCheckBit.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.comboBoxCheckBit.Location = new System.Drawing.Point(63, 89);
            this.comboBoxCheckBit.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCheckBit.Name = "comboBoxCheckBit";
            this.comboBoxCheckBit.Size = new System.Drawing.Size(121, 20);
            this.comboBoxCheckBit.TabIndex = 7;
            this.comboBoxCheckBit.SelectedIndexChanged += new System.EventHandler(this.comboBoxCheckBit_SelectedIndexChanged);
            // 
            // labelCheckBit
            // 
            this.labelCheckBit.AutoSize = true;
            this.labelCheckBit.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCheckBit.Location = new System.Drawing.Point(17, 91);
            this.labelCheckBit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCheckBit.Name = "labelCheckBit";
            this.labelCheckBit.Size = new System.Drawing.Size(41, 12);
            this.labelCheckBit.TabIndex = 8;
            this.labelCheckBit.Text = "校验位";
            // 
            // comboBoxDataBit
            // 
            this.comboBoxDataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataBit.FormattingEnabled = true;
            this.comboBoxDataBit.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.comboBoxDataBit.Location = new System.Drawing.Point(63, 66);
            this.comboBoxDataBit.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxDataBit.Name = "comboBoxDataBit";
            this.comboBoxDataBit.Size = new System.Drawing.Size(121, 20);
            this.comboBoxDataBit.TabIndex = 5;
            this.comboBoxDataBit.SelectedIndexChanged += new System.EventHandler(this.comboBoxDataBit_SelectedIndexChanged);
            // 
            // labelDataBit
            // 
            this.labelDataBit.AutoSize = true;
            this.labelDataBit.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDataBit.Location = new System.Drawing.Point(17, 68);
            this.labelDataBit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDataBit.Name = "labelDataBit";
            this.labelDataBit.Size = new System.Drawing.Size(41, 12);
            this.labelDataBit.TabIndex = 6;
            this.labelDataBit.Text = "数据位";
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBoxBaudRate.Location = new System.Drawing.Point(63, 42);
            this.comboBoxBaudRate.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(121, 20);
            this.comboBoxBaudRate.TabIndex = 3;
            this.comboBoxBaudRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxBaudRate_SelectedIndexChanged);
            // 
            // labelBaudRate
            // 
            this.labelBaudRate.AutoSize = true;
            this.labelBaudRate.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelBaudRate.Location = new System.Drawing.Point(17, 45);
            this.labelBaudRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBaudRate.Name = "labelBaudRate";
            this.labelBaudRate.Size = new System.Drawing.Size(41, 12);
            this.labelBaudRate.TabIndex = 4;
            this.labelBaudRate.Text = "波特率";
            // 
            // groupBoxTCPServiceSetting
            // 
            this.groupBoxTCPServiceSetting.Controls.Add(this.buttonTCPServiceStop);
            this.groupBoxTCPServiceSetting.Controls.Add(this.buttonTCPServiceStart);
            this.groupBoxTCPServiceSetting.Controls.Add(this.labelTCPListenPort);
            this.groupBoxTCPServiceSetting.Controls.Add(this.textBoxTCPListenPort);
            this.groupBoxTCPServiceSetting.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxTCPServiceSetting.Location = new System.Drawing.Point(2, 266);
            this.groupBoxTCPServiceSetting.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxTCPServiceSetting.Name = "groupBoxTCPServiceSetting";
            this.groupBoxTCPServiceSetting.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxTCPServiceSetting.Size = new System.Drawing.Size(192, 90);
            this.groupBoxTCPServiceSetting.TabIndex = 6;
            this.groupBoxTCPServiceSetting.TabStop = false;
            this.groupBoxTCPServiceSetting.Text = "TCP服务设置";
            // 
            // buttonTCPServiceStop
            // 
            this.buttonTCPServiceStop.Location = new System.Drawing.Point(127, 57);
            this.buttonTCPServiceStop.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTCPServiceStop.Name = "buttonTCPServiceStop";
            this.buttonTCPServiceStop.Size = new System.Drawing.Size(56, 24);
            this.buttonTCPServiceStop.TabIndex = 14;
            this.buttonTCPServiceStop.Text = "停止";
            this.buttonTCPServiceStop.UseVisualStyleBackColor = true;
            this.buttonTCPServiceStop.Click += new System.EventHandler(this.buttonTCPServiceStop_Click);
            // 
            // buttonTCPServiceStart
            // 
            this.buttonTCPServiceStart.Location = new System.Drawing.Point(20, 57);
            this.buttonTCPServiceStart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTCPServiceStart.Name = "buttonTCPServiceStart";
            this.buttonTCPServiceStart.Size = new System.Drawing.Size(56, 24);
            this.buttonTCPServiceStart.TabIndex = 13;
            this.buttonTCPServiceStart.Text = "开启";
            this.buttonTCPServiceStart.UseVisualStyleBackColor = true;
            this.buttonTCPServiceStart.Click += new System.EventHandler(this.buttonTCPServiceStart_Click);
            // 
            // labelTCPListenPort
            // 
            this.labelTCPListenPort.AutoSize = true;
            this.labelTCPListenPort.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTCPListenPort.Location = new System.Drawing.Point(17, 26);
            this.labelTCPListenPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTCPListenPort.Name = "labelTCPListenPort";
            this.labelTCPListenPort.Size = new System.Drawing.Size(53, 12);
            this.labelTCPListenPort.TabIndex = 13;
            this.labelTCPListenPort.Text = "监听端口";
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxMsg.Location = new System.Drawing.Point(199, 2);
            this.textBoxMsg.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxMsg.MaxLength = 32763;
            this.textBoxMsg.Multiline = true;
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.ReadOnly = true;
            this.textBoxMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxMsg.Size = new System.Drawing.Size(850, 416);
            this.textBoxMsg.TabIndex = 15;
            this.textBoxMsg.TextChanged += new System.EventHandler(this.textBoxMsg_TextChanged);
            // 
            // labelSerialPortConnStatus
            // 
            this.labelSerialPortConnStatus.AutoSize = true;
            this.labelSerialPortConnStatus.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSerialPortConnStatus.Location = new System.Drawing.Point(32, 370);
            this.labelSerialPortConnStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSerialPortConnStatus.Name = "labelSerialPortConnStatus";
            this.labelSerialPortConnStatus.Size = new System.Drawing.Size(89, 12);
            this.labelSerialPortConnStatus.TabIndex = 16;
            this.labelSerialPortConnStatus.Text = "串口连接状态：";
            // 
            // labelSPortStatus
            // 
            this.labelSPortStatus.AutoSize = true;
            this.labelSPortStatus.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSPortStatus.ForeColor = System.Drawing.Color.Red;
            this.labelSPortStatus.Location = new System.Drawing.Point(121, 370);
            this.labelSPortStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSPortStatus.Name = "labelSPortStatus";
            this.labelSPortStatus.Size = new System.Drawing.Size(41, 12);
            this.labelSPortStatus.TabIndex = 17;
            this.labelSPortStatus.Text = "未连接";
            // 
            // labelTCPServiceStatus
            // 
            this.labelTCPServiceStatus.AutoSize = true;
            this.labelTCPServiceStatus.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTCPServiceStatus.Location = new System.Drawing.Point(32, 394);
            this.labelTCPServiceStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTCPServiceStatus.Name = "labelTCPServiceStatus";
            this.labelTCPServiceStatus.Size = new System.Drawing.Size(89, 12);
            this.labelTCPServiceStatus.TabIndex = 18;
            this.labelTCPServiceStatus.Text = "TCP 服务状态：";
            // 
            // labelTCPStatus
            // 
            this.labelTCPStatus.AutoSize = true;
            this.labelTCPStatus.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTCPStatus.ForeColor = System.Drawing.Color.Red;
            this.labelTCPStatus.Location = new System.Drawing.Point(121, 394);
            this.labelTCPStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTCPStatus.Name = "labelTCPStatus";
            this.labelTCPStatus.Size = new System.Drawing.Size(41, 12);
            this.labelTCPStatus.TabIndex = 20;
            this.labelTCPStatus.Text = "未开启";
            // 
            // ControlSerial2TCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTCPStatus);
            this.Controls.Add(this.labelTCPServiceStatus);
            this.Controls.Add(this.labelSPortStatus);
            this.Controls.Add(this.labelSerialPortConnStatus);
            this.Controls.Add(this.textBoxMsg);
            this.Controls.Add(this.groupBoxTCPServiceSetting);
            this.Controls.Add(this.groupBoxSerialPortSetting);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlSerial2TCP";
            this.Size = new System.Drawing.Size(1051, 420);
            this.groupBoxSerialPortSetting.ResumeLayout(false);
            this.groupBoxSerialPortSetting.PerformLayout();
            this.groupBoxTCPServiceSetting.ResumeLayout(false);
            this.groupBoxTCPServiceSetting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSerialPortConn;
        private System.Windows.Forms.ComboBox comboBoxSerialPort;
        private System.Windows.Forms.Label labelSerialPort;
        private System.Windows.Forms.TextBox textBoxTCPListenPort;
        private System.Windows.Forms.RadioButton radioButtonASCII;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.GroupBox groupBoxSerialPortSetting;
        private System.Windows.Forms.Button buttonSerialPortClose;
        private System.Windows.Forms.RadioButton radioButtonHEX;
        private System.Windows.Forms.ComboBox comboBoxStopBit;
        private System.Windows.Forms.Label labelStopBit;
        private System.Windows.Forms.ComboBox comboBoxCheckBit;
        private System.Windows.Forms.Label labelCheckBit;
        private System.Windows.Forms.ComboBox comboBoxDataBit;
        private System.Windows.Forms.Label labelDataBit;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.Label labelBaudRate;
        private System.Windows.Forms.GroupBox groupBoxTCPServiceSetting;
        private System.Windows.Forms.Button buttonTCPServiceStop;
        private System.Windows.Forms.Button buttonTCPServiceStart;
        private System.Windows.Forms.Label labelTCPListenPort;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.TextBox textBoxMsg;
        private System.Windows.Forms.Label labelSerialPortConnStatus;
        private System.Windows.Forms.Label labelSPortStatus;
        private System.Windows.Forms.Label labelTCPServiceStatus;
        private System.Windows.Forms.Label labelTCPStatus;
        private System.Windows.Forms.Label labelMsgSeperator;
        private System.Windows.Forms.TextBox textBoxMsgSeperator;
    }
}
