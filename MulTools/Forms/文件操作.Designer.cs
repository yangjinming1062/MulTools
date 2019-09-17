namespace MulTools.Forms
{
    partial class 文件操作
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btLeft = new System.Windows.Forms.Button();
            this.btRight = new System.Windows.Forms.Button();
            this.gbCompare = new System.Windows.Forms.GroupBox();
            this.rbFileName = new System.Windows.Forms.RadioButton();
            this.rbMD5 = new System.Windows.Forms.RadioButton();
            this.btClose = new System.Windows.Forms.Button();
            this.uc文件操作L = new Components.uc文件操作();
            this.uc文件操作R = new Components.uc文件操作();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbCompare.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.SkyBlue;
            this.panelTop.Controls.Add(this.btClose);
            this.panelTop.Controls.Add(this.gbCompare);
            this.panelTop.Controls.Add(this.btRight);
            this.panelTop.Controls.Add(this.btLeft);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1196, 64);
            this.panelTop.TabIndex = 0;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTop_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelTop_MouseMove);
            this.panelTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelTop_MouseUp);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 64);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.uc文件操作L);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.uc文件操作R);
            this.splitContainer1.Size = new System.Drawing.Size(1196, 590);
            this.splitContainer1.SplitterDistance = 592;
            this.splitContainer1.TabIndex = 1;
            // 
            // btLeft
            // 
            this.btLeft.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btLeft.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btLeft.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btLeft.Location = new System.Drawing.Point(27, 24);
            this.btLeft.Name = "btLeft";
            this.btLeft.Size = new System.Drawing.Size(140, 34);
            this.btLeft.TabIndex = 0;
            this.btLeft.Text = "右侧不存在";
            this.btLeft.UseVisualStyleBackColor = false;
            this.btLeft.Click += new System.EventHandler(this.BtLeft_Click);
            // 
            // btRight
            // 
            this.btRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRight.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btRight.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btRight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btRight.Location = new System.Drawing.Point(1029, 24);
            this.btRight.Name = "btRight";
            this.btRight.Size = new System.Drawing.Size(140, 34);
            this.btRight.TabIndex = 0;
            this.btRight.Text = "左侧不存在";
            this.btRight.UseVisualStyleBackColor = false;
            this.btRight.Click += new System.EventHandler(this.BtRight_Click);
            // 
            // gbCompare
            // 
            this.gbCompare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCompare.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gbCompare.Controls.Add(this.rbMD5);
            this.gbCompare.Controls.Add(this.rbFileName);
            this.gbCompare.Location = new System.Drawing.Point(490, 3);
            this.gbCompare.Name = "gbCompare";
            this.gbCompare.Size = new System.Drawing.Size(206, 55);
            this.gbCompare.TabIndex = 1;
            this.gbCompare.TabStop = false;
            this.gbCompare.Text = "对比方式";
            // 
            // rbFileName
            // 
            this.rbFileName.AutoSize = true;
            this.rbFileName.Checked = true;
            this.rbFileName.Location = new System.Drawing.Point(6, 27);
            this.rbFileName.Name = "rbFileName";
            this.rbFileName.Size = new System.Drawing.Size(73, 19);
            this.rbFileName.TabIndex = 0;
            this.rbFileName.TabStop = true;
            this.rbFileName.Text = "文件名";
            this.rbFileName.UseVisualStyleBackColor = true;
            // 
            // rbMD5
            // 
            this.rbMD5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbMD5.AutoSize = true;
            this.rbMD5.Location = new System.Drawing.Point(127, 27);
            this.rbMD5.Name = "rbMD5";
            this.rbMD5.Size = new System.Drawing.Size(52, 19);
            this.rbMD5.TabIndex = 0;
            this.rbMD5.Text = "MD5";
            this.rbMD5.UseVisualStyleBackColor = true;
            this.rbMD5.CheckedChanged += new System.EventHandler(this.RbMD5_CheckedChanged);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.BackColor = System.Drawing.Color.Red;
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btClose.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.ForeColor = System.Drawing.Color.White;
            this.btClose.Location = new System.Drawing.Point(1171, 0);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(25, 22);
            this.btClose.TabIndex = 2;
            this.btClose.Text = "X";
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.BtClose_Click);
            // 
            // uc文件操作L
            // 
            this.uc文件操作L.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc文件操作L.Location = new System.Drawing.Point(0, 0);
            this.uc文件操作L.Name = "uc文件操作L";
            this.uc文件操作L.Size = new System.Drawing.Size(592, 590);
            this.uc文件操作L.TabIndex = 0;
            // 
            // uc文件操作R
            // 
            this.uc文件操作R.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc文件操作R.Location = new System.Drawing.Point(0, 0);
            this.uc文件操作R.Name = "uc文件操作R";
            this.uc文件操作R.Size = new System.Drawing.Size(600, 590);
            this.uc文件操作R.TabIndex = 0;
            // 
            // 文件操作
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 654);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "文件操作";
            this.Text = "文件夹内容对比";
            this.Load += new System.EventHandler(this.文件操作_Load);
            this.panelTop.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbCompare.ResumeLayout(false);
            this.gbCompare.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Components.uc文件操作 uc文件操作L;
        private Components.uc文件操作 uc文件操作R;
        private System.Windows.Forms.Button btLeft;
        private System.Windows.Forms.Button btRight;
        private System.Windows.Forms.GroupBox gbCompare;
        private System.Windows.Forms.RadioButton rbMD5;
        private System.Windows.Forms.RadioButton rbFileName;
        private System.Windows.Forms.Button btClose;
    }
}