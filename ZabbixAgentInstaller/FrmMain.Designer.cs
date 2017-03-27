namespace ZabbixAgentInstaller
{
    partial class FrmMain
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
            this.cbDrives = new System.Windows.Forms.ComboBox();
            this.lbDrive = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbOstype = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbHostname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUni = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbDrives
            // 
            this.cbDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDrives.FormattingEnabled = true;
            this.cbDrives.Location = new System.Drawing.Point(60, 23);
            this.cbDrives.Name = "cbDrives";
            this.cbDrives.Size = new System.Drawing.Size(80, 20);
            this.cbDrives.TabIndex = 0;
            // 
            // lbDrive
            // 
            this.lbDrive.AutoSize = true;
            this.lbDrive.Location = new System.Drawing.Point(13, 26);
            this.lbDrive.Name = "lbDrive";
            this.lbDrive.Size = new System.Drawing.Size(41, 12);
            this.lbDrive.TabIndex = 1;
            this.lbDrive.Text = "Drive:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Os:";
            // 
            // cbOstype
            // 
            this.cbOstype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOstype.FormattingEnabled = true;
            this.cbOstype.Location = new System.Drawing.Point(196, 23);
            this.cbOstype.Name = "cbOstype";
            this.cbOstype.Size = new System.Drawing.Size(81, 20);
            this.cbOstype.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(15, 103);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(166, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Install";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "IP:";
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(60, 76);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(217, 21);
            this.tbIP.TabIndex = 6;
            // 
            // tbHostname
            // 
            this.tbHostname.Location = new System.Drawing.Point(60, 49);
            this.tbHostname.Name = "tbHostname";
            this.tbHostname.Size = new System.Drawing.Size(217, 21);
            this.tbHostname.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Host:";
            // 
            // btnUni
            // 
            this.btnUni.Location = new System.Drawing.Point(185, 103);
            this.btnUni.Name = "btnUni";
            this.btnUni.Size = new System.Drawing.Size(92, 23);
            this.btnUni.TabIndex = 9;
            this.btnUni.Text = "Uninstall";
            this.btnUni.UseVisualStyleBackColor = true;
            this.btnUni.Click += new System.EventHandler(this.btnUni_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(15, 132);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(166, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "ReStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(185, 132);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(92, 23);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 171);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnUni);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbHostname);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbOstype);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbDrive);
            this.Controls.Add(this.cbDrives);
            this.Name = "FrmMain";
            this.Text = "Agent Installer V1.2";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDrives;
        private System.Windows.Forms.Label lbDrive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbOstype;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.TextBox tbHostname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUni;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
    }
}

