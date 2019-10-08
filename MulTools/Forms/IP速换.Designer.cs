namespace MulTools.Forms
{
    partial class IP速换
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.cmbWK = new System.Windows.Forms.ComboBox();
            this.btApply = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btRead = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtYM = new System.Windows.Forms.TextBox();
            this.txtWG = new System.Windows.Forms.TextBox();
            this.txtFDNS = new System.Windows.Forms.TextBox();
            this.txtSDNS = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTogether = new System.Windows.Forms.CheckBox();
            this.cbAutoWG = new System.Windows.Forms.CheckBox();
            this.tvIP = new System.Windows.Forms.TreeView();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.cmbWK);
            this.panel.Controls.Add(this.btApply);
            this.panel.Controls.Add(this.btSave);
            this.panel.Controls.Add(this.btRead);
            this.panel.Controls.Add(this.btDelete);
            this.panel.Controls.Add(this.txtIP);
            this.panel.Controls.Add(this.txtYM);
            this.panel.Controls.Add(this.txtWG);
            this.panel.Controls.Add(this.txtFDNS);
            this.panel.Controls.Add(this.txtSDNS);
            this.panel.Controls.Add(this.txtName);
            this.panel.Controls.Add(this.label6);
            this.panel.Controls.Add(this.label5);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.cbTogether);
            this.panel.Controls.Add(this.cbAutoWG);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(157, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(220, 379);
            this.panel.TabIndex = 0;
            // 
            // cmbWK
            // 
            this.cmbWK.FormattingEnabled = true;
            this.cmbWK.Location = new System.Drawing.Point(9, 265);
            this.cmbWK.Name = "cmbWK";
            this.cmbWK.Size = new System.Drawing.Size(197, 20);
            this.cmbWK.TabIndex = 5;
            this.cmbWK.SelectedIndexChanged += new System.EventHandler(this.CmbWK_SelectedIndexChanged);
            // 
            // btApply
            // 
            this.btApply.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btApply.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btApply.Font = new System.Drawing.Font("楷体", 13F);
            this.btApply.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btApply.Location = new System.Drawing.Point(113, 339);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(93, 30);
            this.btApply.TabIndex = 7;
            this.btApply.Text = "应用";
            this.btApply.UseVisualStyleBackColor = false;
            this.btApply.Click += new System.EventHandler(this.BtApply_Click);
            // 
            // btSave
            // 
            this.btSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btSave.Font = new System.Drawing.Font("楷体", 13F);
            this.btSave.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btSave.Location = new System.Drawing.Point(9, 339);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(93, 30);
            this.btSave.TabIndex = 6;
            this.btSave.Text = "保存";
            this.btSave.UseVisualStyleBackColor = false;
            this.btSave.Click += new System.EventHandler(this.BtSave_Click);
            // 
            // btRead
            // 
            this.btRead.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btRead.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btRead.Font = new System.Drawing.Font("楷体", 13F);
            this.btRead.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btRead.Location = new System.Drawing.Point(113, 303);
            this.btRead.Name = "btRead";
            this.btRead.Size = new System.Drawing.Size(93, 30);
            this.btRead.TabIndex = 4;
            this.btRead.TabStop = false;
            this.btRead.Text = "读取当前";
            this.btRead.UseVisualStyleBackColor = false;
            this.btRead.Click += new System.EventHandler(this.BtRead_Click);
            // 
            // btDelete
            // 
            this.btDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btDelete.Font = new System.Drawing.Font("楷体", 13F);
            this.btDelete.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btDelete.Location = new System.Drawing.Point(9, 303);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(93, 30);
            this.btDelete.TabIndex = 4;
            this.btDelete.TabStop = false;
            this.btDelete.Text = "删除";
            this.btDelete.UseVisualStyleBackColor = false;
            this.btDelete.Click += new System.EventHandler(this.BtDelete_Click);
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("宋体", 12F);
            this.txtIP.Location = new System.Drawing.Point(83, 42);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(123, 26);
            this.txtIP.TabIndex = 4;
            this.txtIP.Leave += new System.EventHandler(this.TxtIP_Leave);
            // 
            // txtYM
            // 
            this.txtYM.Font = new System.Drawing.Font("宋体", 12F);
            this.txtYM.Location = new System.Drawing.Point(83, 78);
            this.txtYM.Name = "txtYM";
            this.txtYM.Size = new System.Drawing.Size(123, 26);
            this.txtYM.TabIndex = 4;
            // 
            // txtWG
            // 
            this.txtWG.Font = new System.Drawing.Font("宋体", 12F);
            this.txtWG.Location = new System.Drawing.Point(83, 114);
            this.txtWG.Name = "txtWG";
            this.txtWG.Size = new System.Drawing.Size(123, 26);
            this.txtWG.TabIndex = 4;
            // 
            // txtFDNS
            // 
            this.txtFDNS.Font = new System.Drawing.Font("宋体", 12F);
            this.txtFDNS.Location = new System.Drawing.Point(83, 150);
            this.txtFDNS.Name = "txtFDNS";
            this.txtFDNS.Size = new System.Drawing.Size(123, 26);
            this.txtFDNS.TabIndex = 4;
            // 
            // txtSDNS
            // 
            this.txtSDNS.Font = new System.Drawing.Font("宋体", 12F);
            this.txtSDNS.Location = new System.Drawing.Point(83, 188);
            this.txtSDNS.Name = "txtSDNS";
            this.txtSDNS.Size = new System.Drawing.Size(123, 26);
            this.txtSDNS.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("宋体", 12F);
            this.txtName.Location = new System.Drawing.Point(83, 223);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(123, 26);
            this.txtName.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("楷体", 12F);
            this.label6.Location = new System.Drawing.Point(6, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "配置名称：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("楷体", 12F);
            this.label5.Location = new System.Drawing.Point(6, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "备选 DNS：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 12F);
            this.label4.Location = new System.Drawing.Point(6, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "首选 DNS：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 12F);
            this.label3.Location = new System.Drawing.Point(6, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "默认网关：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 12F);
            this.label2.Location = new System.Drawing.Point(6, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "子网掩码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 12F);
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP 地 址：";
            // 
            // cbTogether
            // 
            this.cbTogether.AutoSize = true;
            this.cbTogether.Location = new System.Drawing.Point(122, 12);
            this.cbTogether.Name = "cbTogether";
            this.cbTogether.Size = new System.Drawing.Size(84, 16);
            this.cbTogether.TabIndex = 0;
            this.cbTogether.TabStop = false;
            this.cbTogether.Text = "保存时应用";
            this.cbTogether.UseVisualStyleBackColor = true;
            // 
            // cbAutoWG
            // 
            this.cbAutoWG.AutoSize = true;
            this.cbAutoWG.Checked = true;
            this.cbAutoWG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoWG.Location = new System.Drawing.Point(6, 12);
            this.cbAutoWG.Name = "cbAutoWG";
            this.cbAutoWG.Size = new System.Drawing.Size(96, 16);
            this.cbAutoWG.TabIndex = 0;
            this.cbAutoWG.TabStop = false;
            this.cbAutoWG.Text = "自动生成网关";
            this.cbAutoWG.UseVisualStyleBackColor = true;
            this.cbAutoWG.CheckedChanged += new System.EventHandler(this.CbAutoWG_CheckedChanged);
            // 
            // tvIP
            // 
            this.tvIP.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvIP.Location = new System.Drawing.Point(0, 0);
            this.tvIP.Name = "tvIP";
            this.tvIP.Size = new System.Drawing.Size(157, 379);
            this.tvIP.TabIndex = 1;
            this.tvIP.TabStop = false;
            this.tvIP.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvIP_AfterSelect);
            // 
            // IP速换
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 379);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.tvIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IP速换";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IP速换";
            this.Load += new System.EventHandler(this.IP速换_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TreeView tvIP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbTogether;
        private System.Windows.Forms.CheckBox cbAutoWG;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btRead;
        private System.Windows.Forms.ComboBox cmbWK;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtYM;
        private System.Windows.Forms.TextBox txtWG;
        private System.Windows.Forms.TextBox txtFDNS;
        private System.Windows.Forms.TextBox txtSDNS;
    }
}