namespace MyCtrler
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnDispose = new System.Windows.Forms.Button();
            this.btnAbsDispose = new System.Windows.Forms.Button();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCL = new System.Windows.Forms.Button();
            this.btnCR = new System.Windows.Forms.Button();
            this.btnDD = new System.Windows.Forms.Button();
            this.btnDU = new System.Windows.Forms.Button();
            this.btnDM = new System.Windows.Forms.Button();
            this.btnCM = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLR = new System.Windows.Forms.Button();
            this.btnLL = new System.Windows.Forms.Button();
            this.btnLD = new System.Windows.Forms.Button();
            this.btnLU = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.Location = new System.Drawing.Point(12, 161);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(480, 360);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            this.picImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseDown);
            this.picImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseMove);
            this.picImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseUp);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(234, 6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(63, 7);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 21);
            this.txtIP.TabIndex = 2;
            this.txtIP.Text = "192.168.1.2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP端口：";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(170, 7);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(47, 21);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "8888";
            // 
            // btnDispose
            // 
            this.btnDispose.Enabled = false;
            this.btnDispose.Location = new System.Drawing.Point(315, 6);
            this.btnDispose.Name = "btnDispose";
            this.btnDispose.Size = new System.Drawing.Size(75, 23);
            this.btnDispose.TabIndex = 5;
            this.btnDispose.Text = "释放";
            this.btnDispose.UseVisualStyleBackColor = true;
            this.btnDispose.Click += new System.EventHandler(this.btnDispose_Click);
            this.btnDispose.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnDispose_KeyUp);
            // 
            // btnAbsDispose
            // 
            this.btnAbsDispose.Location = new System.Drawing.Point(396, 6);
            this.btnAbsDispose.Name = "btnAbsDispose";
            this.btnAbsDispose.Size = new System.Drawing.Size(75, 23);
            this.btnAbsDispose.TabIndex = 9;
            this.btnAbsDispose.Text = "强制释放";
            this.btnAbsDispose.UseVisualStyleBackColor = true;
            this.btnAbsDispose.Click += new System.EventHandler(this.btnAbsDispose_Click);
            // 
            // cmbMode
            // 
            this.cmbMode.DisplayMember = "text";
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Location = new System.Drawing.Point(63, 35);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(100, 20);
            this.cmbMode.TabIndex = 11;
            this.cmbMode.ValueMember = "value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "模式：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCL);
            this.groupBox1.Controls.Add(this.btnCR);
            this.groupBox1.Controls.Add(this.btnDD);
            this.groupBox1.Controls.Add(this.btnDU);
            this.groupBox1.Controls.Add(this.btnDM);
            this.groupBox1.Controls.Add(this.btnCM);
            this.groupBox1.Location = new System.Drawing.Point(14, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 80);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "摄像头";
            // 
            // btnCL
            // 
            this.btnCL.Location = new System.Drawing.Point(196, 49);
            this.btnCL.Name = "btnCL";
            this.btnCL.Size = new System.Drawing.Size(46, 23);
            this.btnCL.TabIndex = 5;
            this.btnCL.Text = "右";
            this.btnCL.UseVisualStyleBackColor = true;
            this.btnCL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCL_MouseDown);
            this.btnCL.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnCL_MouseUp);
            // 
            // btnCR
            // 
            this.btnCR.Location = new System.Drawing.Point(92, 49);
            this.btnCR.Name = "btnCR";
            this.btnCR.Size = new System.Drawing.Size(46, 23);
            this.btnCR.TabIndex = 4;
            this.btnCR.Text = "左";
            this.btnCR.UseVisualStyleBackColor = true;
            this.btnCR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCR_MouseDown);
            this.btnCR.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnCL_MouseUp);
            // 
            // btnDD
            // 
            this.btnDD.Location = new System.Drawing.Point(144, 49);
            this.btnDD.Name = "btnDD";
            this.btnDD.Size = new System.Drawing.Size(46, 23);
            this.btnDD.TabIndex = 3;
            this.btnDD.Text = "下";
            this.btnDD.UseVisualStyleBackColor = true;
            this.btnDD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDD_MouseDown);
            this.btnDD.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDU_MouseUp);
            // 
            // btnDU
            // 
            this.btnDU.Location = new System.Drawing.Point(144, 20);
            this.btnDU.Name = "btnDU";
            this.btnDU.Size = new System.Drawing.Size(46, 23);
            this.btnDU.TabIndex = 2;
            this.btnDU.Text = "上";
            this.btnDU.UseVisualStyleBackColor = true;
            this.btnDU.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDU_MouseDown);
            this.btnDU.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDU_MouseUp);
            // 
            // btnDM
            // 
            this.btnDM.Location = new System.Drawing.Point(11, 20);
            this.btnDM.Name = "btnDM";
            this.btnDM.Size = new System.Drawing.Size(73, 23);
            this.btnDM.TabIndex = 1;
            this.btnDM.Text = "垂直复位";
            this.btnDM.UseVisualStyleBackColor = true;
            this.btnDM.Click += new System.EventHandler(this.btnDM_Click);
            // 
            // btnCM
            // 
            this.btnCM.Location = new System.Drawing.Point(11, 49);
            this.btnCM.Name = "btnCM";
            this.btnCM.Size = new System.Drawing.Size(73, 23);
            this.btnCM.TabIndex = 0;
            this.btnCM.Text = "水平复位";
            this.btnCM.UseVisualStyleBackColor = true;
            this.btnCM.Click += new System.EventHandler(this.btnCM_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLR);
            this.groupBox2.Controls.Add(this.btnLL);
            this.groupBox2.Controls.Add(this.btnLD);
            this.groupBox2.Controls.Add(this.btnLU);
            this.groupBox2.Location = new System.Drawing.Point(268, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(203, 80);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "车灯";
            // 
            // btnLR
            // 
            this.btnLR.Location = new System.Drawing.Point(110, 49);
            this.btnLR.Name = "btnLR";
            this.btnLR.Size = new System.Drawing.Size(75, 23);
            this.btnLR.TabIndex = 3;
            this.btnLR.Text = "右灯";
            this.btnLR.UseVisualStyleBackColor = true;
            this.btnLR.Click += new System.EventHandler(this.btnLR_Click);
            // 
            // btnLL
            // 
            this.btnLL.Location = new System.Drawing.Point(18, 49);
            this.btnLL.Name = "btnLL";
            this.btnLL.Size = new System.Drawing.Size(75, 23);
            this.btnLL.TabIndex = 2;
            this.btnLL.Text = "左灯";
            this.btnLL.UseVisualStyleBackColor = true;
            this.btnLL.Click += new System.EventHandler(this.btnLL_Click);
            // 
            // btnLD
            // 
            this.btnLD.Location = new System.Drawing.Point(110, 20);
            this.btnLD.Name = "btnLD";
            this.btnLD.Size = new System.Drawing.Size(75, 23);
            this.btnLD.TabIndex = 1;
            this.btnLD.Text = "熄灯";
            this.btnLD.UseVisualStyleBackColor = true;
            this.btnLD.Click += new System.EventHandler(this.btnLD_Click);
            // 
            // btnLU
            // 
            this.btnLU.Location = new System.Drawing.Point(18, 20);
            this.btnLU.Name = "btnLU";
            this.btnLU.Size = new System.Drawing.Size(75, 23);
            this.btnLU.TabIndex = 0;
            this.btnLU.Text = "全灯";
            this.btnLU.UseVisualStyleBackColor = true;
            this.btnLU.Click += new System.EventHandler(this.btnLU_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 536);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbMode);
            this.Controls.Add(this.btnAbsDispose);
            this.Controls.Add(this.btnDispose);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.picImage);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "SoyKing-喵星人侦探";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnDispose;
        private System.Windows.Forms.Button btnAbsDispose;
        private System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDM;
        private System.Windows.Forms.Button btnCM;
        private System.Windows.Forms.Button btnDU;
        private System.Windows.Forms.Button btnCR;
        private System.Windows.Forms.Button btnDD;
        private System.Windows.Forms.Button btnCL;
        private System.Windows.Forms.Button btnLD;
        private System.Windows.Forms.Button btnLU;
        private System.Windows.Forms.Button btnLL;
        private System.Windows.Forms.Button btnLR;
    }
}

