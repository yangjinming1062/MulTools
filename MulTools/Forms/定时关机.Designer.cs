namespace MulTools.Forms
{
    partial class 定时关机
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
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.cbJS = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dtp
            // 
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp.Location = new System.Drawing.Point(0, 0);
            this.dtp.Margin = new System.Windows.Forms.Padding(4);
            this.dtp.Name = "dtp";
            this.dtp.ShowUpDown = true;
            this.dtp.Size = new System.Drawing.Size(99, 25);
            this.dtp.TabIndex = 0;
            this.dtp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Dtp_KeyDown);
            // 
            // cbJS
            // 
            this.cbJS.AutoSize = true;
            this.cbJS.Location = new System.Drawing.Point(107, 4);
            this.cbJS.Margin = new System.Windows.Forms.Padding(4);
            this.cbJS.Name = "cbJS";
            this.cbJS.Size = new System.Drawing.Size(56, 19);
            this.cbJS.TabIndex = 1;
            this.cbJS.Text = "计时";
            this.cbJS.UseVisualStyleBackColor = true;
            this.cbJS.CheckedChanged += new System.EventHandler(this.CbJS_CheckedChanged);
            // 
            // 定时关机
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(168, 26);
            this.Controls.Add(this.cbJS);
            this.Controls.Add(this.dtp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(168, 26);
            this.MinimumSize = new System.Drawing.Size(168, 26);
            this.Name = "定时关机";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定时关机";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.定时关机_FormClosed);
            this.Load += new System.EventHandler(this.定时关机_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.CheckBox cbJS;
    }
}