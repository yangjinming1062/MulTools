﻿namespace MulTools
{
    partial class frmMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.屏幕截图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbPanel = new System.Windows.Forms.TableLayoutPanel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.窗体监控ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Lavender;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem5,
            this.屏幕截图ToolStripMenuItem,
            this.窗体监控ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(124, 244);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "功能菜单";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(115, 21);
            this.toolStripMenuItem1.Text = "文件操作";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(115, 21);
            this.toolStripMenuItem2.Text = "定时关机";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(115, 21);
            this.toolStripMenuItem3.Text = "进程专杀";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(115, 21);
            this.toolStripMenuItem5.Text = "IP速换";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // 屏幕截图ToolStripMenuItem
            // 
            this.屏幕截图ToolStripMenuItem.Name = "屏幕截图ToolStripMenuItem";
            this.屏幕截图ToolStripMenuItem.Size = new System.Drawing.Size(115, 21);
            this.屏幕截图ToolStripMenuItem.Text = "屏幕截图";
            this.屏幕截图ToolStripMenuItem.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tbPanel
            // 
            this.tbPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tbPanel.ColumnCount = 2;
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPanel.Location = new System.Drawing.Point(124, 0);
            this.tbPanel.Name = "tbPanel";
            this.tbPanel.RowCount = 4;
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbPanel.Size = new System.Drawing.Size(187, 244);
            this.tbPanel.TabIndex = 1;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "MulTools";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.NotifyIcon1_Click);
            // 
            // 窗体监控ToolStripMenuItem
            // 
            this.窗体监控ToolStripMenuItem.Name = "窗体监控ToolStripMenuItem";
            this.窗体监控ToolStripMenuItem.Size = new System.Drawing.Size(115, 21);
            this.窗体监控ToolStripMenuItem.Text = "窗体监控";
            this.窗体监控ToolStripMenuItem.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 244);
            this.Controls.Add(this.tbPanel);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "功能菜单";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tbPanel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem 屏幕截图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 窗体监控ToolStripMenuItem;
    }
}

