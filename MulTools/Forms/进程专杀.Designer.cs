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
            this.components = new System.ComponentModel.Container();
            this.btKill = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btClose = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.循环间隔ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.默认进程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtDefaultName = new System.Windows.Forms.ToolStripTextBox();
            this.txtSpantime = new System.Windows.Forms.ToolStripTextBox();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btKill
            // 
            this.btKill.BackColor = System.Drawing.SystemColors.Highlight;
            this.btKill.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btKill.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btKill.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btKill.Location = new System.Drawing.Point(0, 0);
            this.btKill.Name = "btKill";
            this.btKill.Size = new System.Drawing.Size(25, 25);
            this.btKill.TabIndex = 0;
            this.btKill.Text = "杀";
            this.btKill.UseVisualStyleBackColor = false;
            this.btKill.Click += new System.EventHandler(this.BtKill_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(29, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 1;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtName_KeyDown);
            // 
            // btClose
            // 
            this.btClose.BackColor = System.Drawing.SystemColors.Highlight;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btClose.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btClose.Location = new System.Drawing.Point(131, 0);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(25, 25);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "X";
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.BtClose_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemHelp,
            this.循环间隔ToolStripMenuItem,
            this.默认进程ToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(125, 70);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(180, 22);
            this.menuItemHelp.Text = "使用说明";
            this.menuItemHelp.Click += new System.EventHandler(this.menuItemHelp_Click);
            // 
            // 循环间隔ToolStripMenuItem
            // 
            this.循环间隔ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtSpantime});
            this.循环间隔ToolStripMenuItem.Name = "循环间隔ToolStripMenuItem";
            this.循环间隔ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.循环间隔ToolStripMenuItem.Text = "循环间隔";
            // 
            // 默认进程ToolStripMenuItem
            // 
            this.默认进程ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtDefaultName});
            this.默认进程ToolStripMenuItem.Name = "默认进程ToolStripMenuItem";
            this.默认进程ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.默认进程ToolStripMenuItem.Text = "默认进程";
            // 
            // txtDefaultName
            // 
            this.txtDefaultName.BackColor = System.Drawing.SystemColors.Info;
            this.txtDefaultName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.txtDefaultName.Name = "txtDefaultName";
            this.txtDefaultName.Size = new System.Drawing.Size(100, 23);
            // 
            // txtSpantime
            // 
            this.txtSpantime.BackColor = System.Drawing.SystemColors.Info;
            this.txtSpantime.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.txtSpantime.Name = "txtSpantime";
            this.txtSpantime.Size = new System.Drawing.Size(100, 23);
            // 
            // 进程专杀
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(155, 25);
            this.ContextMenuStrip = this.menu;
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btKill);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(155, 25);
            this.MinimumSize = new System.Drawing.Size(155, 25);
            this.Name = "进程专杀";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "进程专杀";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.进程专杀_FormClosed);
            this.Load += new System.EventHandler(this.进程专杀_Load);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btKill;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem 循环间隔ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 默认进程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox txtSpantime;
        private System.Windows.Forms.ToolStripTextBox txtDefaultName;
    }
}