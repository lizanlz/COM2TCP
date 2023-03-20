namespace COM2TCP
{
    partial class Form
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.buttonAddConn = new System.Windows.Forms.Button();
            this.buttonDelConn = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonConnAll = new System.Windows.Forms.Button();
            this.buttonClearMsg = new System.Windows.Forms.Button();
            this.buttonCloseAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1420, 566);
            this.tabControl.TabIndex = 0;
            // 
            // buttonAddConn
            // 
            this.buttonAddConn.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAddConn.ForeColor = System.Drawing.Color.ForestGreen;
            this.buttonAddConn.Location = new System.Drawing.Point(12, 592);
            this.buttonAddConn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddConn.Name = "buttonAddConn";
            this.buttonAddConn.Size = new System.Drawing.Size(100, 32);
            this.buttonAddConn.TabIndex = 1;
            this.buttonAddConn.Text = "添加连接";
            this.buttonAddConn.UseVisualStyleBackColor = true;
            this.buttonAddConn.Click += new System.EventHandler(this.buttonAddConn_Click);
            // 
            // buttonDelConn
            // 
            this.buttonDelConn.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonDelConn.ForeColor = System.Drawing.Color.Red;
            this.buttonDelConn.Location = new System.Drawing.Point(153, 592);
            this.buttonDelConn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelConn.Name = "buttonDelConn";
            this.buttonDelConn.Size = new System.Drawing.Size(100, 32);
            this.buttonDelConn.TabIndex = 1;
            this.buttonDelConn.Text = "删除连接";
            this.buttonDelConn.UseVisualStyleBackColor = true;
            this.buttonDelConn.Click += new System.EventHandler(this.buttonDelConn_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSave.Location = new System.Drawing.Point(1303, 592);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 32);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "保存配置";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonConnAll
            // 
            this.buttonConnAll.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonConnAll.ForeColor = System.Drawing.Color.ForestGreen;
            this.buttonConnAll.Location = new System.Drawing.Point(294, 592);
            this.buttonConnAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonConnAll.Name = "buttonConnAll";
            this.buttonConnAll.Size = new System.Drawing.Size(100, 32);
            this.buttonConnAll.TabIndex = 2;
            this.buttonConnAll.Text = "连接所有";
            this.buttonConnAll.UseVisualStyleBackColor = true;
            this.buttonConnAll.Click += new System.EventHandler(this.buttonConnAll_Click);
            // 
            // buttonClearMsg
            // 
            this.buttonClearMsg.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClearMsg.ForeColor = System.Drawing.Color.Red;
            this.buttonClearMsg.Location = new System.Drawing.Point(1162, 592);
            this.buttonClearMsg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClearMsg.Name = "buttonClearMsg";
            this.buttonClearMsg.Size = new System.Drawing.Size(100, 32);
            this.buttonClearMsg.TabIndex = 3;
            this.buttonClearMsg.Text = "清空消息";
            this.buttonClearMsg.UseVisualStyleBackColor = true;
            this.buttonClearMsg.Click += new System.EventHandler(this.buttonClearMsg_Click);
            // 
            // buttonCloseAll
            // 
            this.buttonCloseAll.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCloseAll.ForeColor = System.Drawing.Color.Red;
            this.buttonCloseAll.Location = new System.Drawing.Point(435, 592);
            this.buttonCloseAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCloseAll.Name = "buttonCloseAll";
            this.buttonCloseAll.Size = new System.Drawing.Size(100, 32);
            this.buttonCloseAll.TabIndex = 4;
            this.buttonCloseAll.Text = "断开所有";
            this.buttonCloseAll.UseVisualStyleBackColor = true;
            this.buttonCloseAll.Click += new System.EventHandler(this.buttonCloseAll_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 639);
            this.Controls.Add(this.buttonCloseAll);
            this.Controls.Add(this.buttonClearMsg);
            this.Controls.Add(this.buttonConnAll);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonDelConn);
            this.Controls.Add(this.buttonAddConn);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form";
            this.Text = "串口连接转TCP连接工具";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button buttonAddConn;
        private System.Windows.Forms.Button buttonDelConn;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonConnAll;
        private System.Windows.Forms.Button buttonClearMsg;
        private System.Windows.Forms.Button buttonCloseAll;
    }
}

