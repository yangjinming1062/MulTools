namespace MulTools.Forms
{
    partial class 进程专杀
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
            this.btKill = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btKill
            // 
            this.btKill.BackColor = System.Drawing.SystemColors.Highlight;
            this.btKill.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btKill.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btKill.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btKill.Location = new System.Drawing.Point(0, 0);
            this.btKill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btKill.Name = "btKill";
            this.btKill.Size = new System.Drawing.Size(33, 31);
            this.btKill.TabIndex = 0;
            this.btKill.Text = "杀";
            this.btKill.UseVisualStyleBackColor = false;
            this.btKill.Click += new System.EventHandler(this.BtKill_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(39, 2);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(132, 25);
            this.txtName.TabIndex = 1;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtName_KeyDown);
            // 
            // btClose
            // 
            this.btClose.BackColor = System.Drawing.SystemColors.Highlight;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btClose.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btClose.Location = new System.Drawing.Point(175, 0);
            this.btClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(33, 31);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "X";
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.BtClose_Click);
            // 
            // 进程专杀
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 31);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btKill);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(207, 31);
            this.MinimumSize = new System.Drawing.Size(207, 31);
            this.Name = "进程专杀";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "进程专杀";
            this.Load += new System.EventHandler(this.进程专杀_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btKill;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btClose;
    }
}