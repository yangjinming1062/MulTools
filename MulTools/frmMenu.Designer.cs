namespace MulTools
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
            this.tmiWJCZ = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiDSGJ = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiJCZS = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiIPSH = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiPMJT = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiCTJK = new System.Windows.Forms.ToolStripMenuItem();
            this.tbPanel = new System.Windows.Forms.TableLayoutPanel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSet = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbSetFunc = new System.Windows.Forms.ToolStripComboBox();
            this.cmbSetEXE = new System.Windows.Forms.ToolStripComboBox();
            this.tmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmiWJCZ
            // 
            this.tmiWJCZ.Name = "tmiWJCZ";
            this.tmiWJCZ.Size = new System.Drawing.Size(124, 22);
            this.tmiWJCZ.Text = "文件操作";
            this.tmiWJCZ.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tmiDSGJ
            // 
            this.tmiDSGJ.Name = "tmiDSGJ";
            this.tmiDSGJ.Size = new System.Drawing.Size(124, 22);
            this.tmiDSGJ.Text = "定时关机";
            this.tmiDSGJ.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tmiJCZS
            // 
            this.tmiJCZS.Name = "tmiJCZS";
            this.tmiJCZS.Size = new System.Drawing.Size(124, 22);
            this.tmiJCZS.Text = "进程专杀";
            this.tmiJCZS.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tmiIPSH
            // 
            this.tmiIPSH.Name = "tmiIPSH";
            this.tmiIPSH.Size = new System.Drawing.Size(124, 22);
            this.tmiIPSH.Text = "IP速换";
            this.tmiIPSH.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tmiPMJT
            // 
            this.tmiPMJT.Name = "tmiPMJT";
            this.tmiPMJT.Size = new System.Drawing.Size(124, 22);
            this.tmiPMJT.Text = "屏幕截图";
            this.tmiPMJT.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tmiCTJK
            // 
            this.tmiCTJK.Name = "tmiCTJK";
            this.tmiCTJK.Size = new System.Drawing.Size(124, 22);
            this.tmiCTJK.Text = "窗体监控";
            this.tmiCTJK.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // tbPanel
            // 
            this.tbPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tbPanel.ColumnCount = 2;
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPanel.Location = new System.Drawing.Point(0, 0);
            this.tbPanel.Name = "tbPanel";
            this.tbPanel.RowCount = 4;
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbPanel.Size = new System.Drawing.Size(311, 244);
            this.tbPanel.TabIndex = 1;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "工具集";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiMenu,
            this.tmiSet,
            this.tmiClose,
            this.toolStripSeparator1,
            this.tmiWJCZ,
            this.tmiDSGJ,
            this.tmiJCZS,
            this.tmiIPSH,
            this.tmiPMJT,
            this.tmiCTJK});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(125, 208);
            this.contextMenuStrip.Text = "功能菜单";
            // 
            // tmiMenu
            // 
            this.tmiMenu.ForeColor = System.Drawing.Color.LimeGreen;
            this.tmiMenu.Name = "tmiMenu";
            this.tmiMenu.Size = new System.Drawing.Size(124, 22);
            this.tmiMenu.Text = "菜单界面";
            this.tmiMenu.Click += new System.EventHandler(this.tmiMenu_Click);
            // 
            // tmiSet
            // 
            this.tmiSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbSetFunc,
            this.cmbSetEXE});
            this.tmiSet.Name = "tmiSet";
            this.tmiSet.Size = new System.Drawing.Size(124, 22);
            this.tmiSet.Text = "系统设置";
            this.tmiSet.DropDownClosed += new System.EventHandler(this.tmiSet_DropDownClosed);
            this.tmiSet.DropDownOpening += new System.EventHandler(this.tmiSet_DropDownOpening);
            // 
            // cmbSetFunc
            // 
            this.cmbSetFunc.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cmbSetFunc.Name = "cmbSetFunc";
            this.cmbSetFunc.Size = new System.Drawing.Size(80, 25);
            this.cmbSetFunc.Text = "是";
            this.cmbSetFunc.ToolTipText = "是否允许功能多开";
            // 
            // cmbSetEXE
            // 
            this.cmbSetEXE.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cmbSetEXE.Name = "cmbSetEXE";
            this.cmbSetEXE.Size = new System.Drawing.Size(80, 25);
            this.cmbSetEXE.Text = "是";
            this.cmbSetEXE.ToolTipText = "是否允许程序多开";
            // 
            // tmiClose
            // 
            this.tmiClose.ForeColor = System.Drawing.Color.Red;
            this.tmiClose.Name = "tmiClose";
            this.tmiClose.Size = new System.Drawing.Size(124, 22);
            this.tmiClose.Text = "退出程序";
            this.tmiClose.Click += new System.EventHandler(this.tmiClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 244);
            this.Controls.Add(this.tbPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "功能菜单";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem tmiWJCZ;
        private System.Windows.Forms.TableLayoutPanel tbPanel;
        private System.Windows.Forms.ToolStripMenuItem tmiDSGJ;
        private System.Windows.Forms.ToolStripMenuItem tmiJCZS;
        private System.Windows.Forms.ToolStripMenuItem tmiIPSH;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem tmiPMJT;
        private System.Windows.Forms.ToolStripMenuItem tmiCTJK;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tmiMenu;
        private System.Windows.Forms.ToolStripMenuItem tmiClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tmiSet;
        private System.Windows.Forms.ToolStripComboBox cmbSetFunc;
        private System.Windows.Forms.ToolStripComboBox cmbSetEXE;
    }
}

