namespace MulTools.Components
{
    partial class uc文件操作
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.tbPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.txtDirpath = new System.Windows.Forms.TextBox();
            this.btOpen = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            this.btBrowse = new System.Windows.Forms.Button();
            this.cbDG = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btReName = new System.Windows.Forms.Button();
            this.btReplace = new System.Windows.Forms.Button();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.txtReName = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fileLV = new System.Windows.Forms.ListView();
            this.cName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cMD5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmItemCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmItemReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmItemRename = new System.Windows.Forms.ToolStripMenuItem();
            this.pgBar = new System.Windows.Forms.ProgressBar();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.lvMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgWorker_BuildList);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgWorker_RunWorkerCompleted);
            // 
            // tbPanel
            // 
            this.tbPanel.AutoScroll = true;
            this.tbPanel.BackColor = System.Drawing.Color.SkyBlue;
            this.tbPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tbPanel.ColumnCount = 4;
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbPanel.Location = new System.Drawing.Point(0, 345);
            this.tbPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbPanel.Name = "tbPanel";
            this.tbPanel.RowCount = 2;
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel.Size = new System.Drawing.Size(426, 67);
            this.tbPanel.TabIndex = 2;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.SkyBlue;
            this.panelTop.Controls.Add(this.txtDirpath);
            this.panelTop.Controls.Add(this.btOpen);
            this.panelTop.Controls.Add(this.btBack);
            this.panelTop.Controls.Add(this.btBrowse);
            this.panelTop.Controls.Add(this.cbDG);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 18);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(426, 22);
            this.panelTop.TabIndex = 3;
            // 
            // txtDirpath
            // 
            this.txtDirpath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirpath.Location = new System.Drawing.Point(93, 0);
            this.txtDirpath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDirpath.Name = "txtDirpath";
            this.txtDirpath.Size = new System.Drawing.Size(208, 21);
            this.txtDirpath.TabIndex = 1;
            this.txtDirpath.TextChanged += new System.EventHandler(this.TxtDirpath_TextChanged);
            // 
            // btOpen
            // 
            this.btOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btOpen.Font = new System.Drawing.Font("楷体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btOpen.Location = new System.Drawing.Point(384, 0);
            this.btOpen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(38, 20);
            this.btOpen.TabIndex = 3;
            this.btOpen.Text = "打开";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.BtOpen_Click);
            // 
            // btBack
            // 
            this.btBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btBack.Font = new System.Drawing.Font("楷体", 7.8F);
            this.btBack.Location = new System.Drawing.Point(345, 0);
            this.btBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(38, 20);
            this.btBack.TabIndex = 3;
            this.btBack.Text = "上级";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.BtBack_Click);
            // 
            // btBrowse
            // 
            this.btBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBrowse.Font = new System.Drawing.Font("楷体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btBrowse.Location = new System.Drawing.Point(302, 0);
            this.btBrowse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(36, 20);
            this.btBrowse.TabIndex = 2;
            this.btBrowse.Text = "...";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.BtBrowse_Click);
            // 
            // cbDG
            // 
            this.cbDG.AutoSize = true;
            this.cbDG.Location = new System.Drawing.Point(47, 3);
            this.cbDG.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbDG.Name = "cbDG";
            this.cbDG.Size = new System.Drawing.Size(48, 16);
            this.cbDG.TabIndex = 4;
            this.cbDG.Text = "递归";
            this.cbDG.UseVisualStyleBackColor = true;
            this.cbDG.CheckedChanged += new System.EventHandler(this.CbDG_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件夹：";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.SkyBlue;
            this.panelBottom.Controls.Add(this.btReName);
            this.panelBottom.Controls.Add(this.btReplace);
            this.panelBottom.Controls.Add(this.txtTarget);
            this.panelBottom.Controls.Add(this.txtReName);
            this.panelBottom.Controls.Add(this.txtSource);
            this.panelBottom.Controls.Add(this.label3);
            this.panelBottom.Controls.Add(this.label4);
            this.panelBottom.Controls.Add(this.label2);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 289);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(426, 56);
            this.panelBottom.TabIndex = 4;
            // 
            // btReName
            // 
            this.btReName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btReName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btReName.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btReName.Location = new System.Drawing.Point(352, 30);
            this.btReName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btReName.Name = "btReName";
            this.btReName.Size = new System.Drawing.Size(72, 18);
            this.btReName.TabIndex = 3;
            this.btReName.Text = "修改";
            this.btReName.UseVisualStyleBackColor = true;
            this.btReName.Click += new System.EventHandler(this.BtReName_Click);
            // 
            // btReplace
            // 
            this.btReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btReplace.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btReplace.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btReplace.Location = new System.Drawing.Point(352, 5);
            this.btReplace.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btReplace.Name = "btReplace";
            this.btReplace.Size = new System.Drawing.Size(72, 18);
            this.btReplace.TabIndex = 3;
            this.btReplace.Text = "替换";
            this.btReplace.UseVisualStyleBackColor = true;
            this.btReplace.Click += new System.EventHandler(this.BtReplace_Click);
            // 
            // txtTarget
            // 
            this.txtTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTarget.Location = new System.Drawing.Point(254, 5);
            this.txtTarget.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(95, 21);
            this.txtTarget.TabIndex = 2;
            // 
            // txtReName
            // 
            this.txtReName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReName.Location = new System.Drawing.Point(123, 30);
            this.txtReName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReName.Name = "txtReName";
            this.txtReName.Size = new System.Drawing.Size(225, 21);
            this.txtReName.TabIndex = 1;
            // 
            // txtSource
            // 
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.Location = new System.Drawing.Point(76, 5);
            this.txtSource.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(150, 21);
            this.txtSource.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(227, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "→";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "批量重命名[序号]：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "批量替换：";
            // 
            // fileLV
            // 
            this.fileLV.BackColor = System.Drawing.Color.White;
            this.fileLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cName,
            this.cType,
            this.cMD5});
            this.fileLV.ContextMenuStrip = this.lvMenu;
            this.fileLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileLV.FullRowSelect = true;
            this.fileLV.GridLines = true;
            this.fileLV.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.fileLV.HideSelection = false;
            this.fileLV.Location = new System.Drawing.Point(0, 40);
            this.fileLV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fileLV.Name = "fileLV";
            this.fileLV.Size = new System.Drawing.Size(426, 249);
            this.fileLV.TabIndex = 5;
            this.fileLV.UseCompatibleStateImageBehavior = false;
            this.fileLV.View = System.Windows.Forms.View.Details;
            this.fileLV.SizeChanged += new System.EventHandler(this.fileLV_SizeChanged);
            this.fileLV.DoubleClick += new System.EventHandler(this.FileLV_DoubleClick);
            // 
            // cName
            // 
            this.cName.Text = "文件名";
            this.cName.Width = 240;
            // 
            // cType
            // 
            this.cType.Text = "文件类型";
            this.cType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cType.Width = 80;
            // 
            // cMD5
            // 
            this.cMD5.Text = "MD5值";
            this.cMD5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cMD5.Width = 100;
            // 
            // lvMenu
            // 
            this.lvMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.lvMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmItemOpen,
            this.tsmItemDelete,
            this.tsmItemCut,
            this.tsmItemCopy,
            this.tsmItemReplace,
            this.tsmItemRename});
            this.lvMenu.Name = "lvMenu";
            this.lvMenu.Size = new System.Drawing.Size(183, 136);
            // 
            // tsmItemOpen
            // 
            this.tsmItemOpen.Name = "tsmItemOpen";
            this.tsmItemOpen.Size = new System.Drawing.Size(182, 22);
            this.tsmItemOpen.Text = "打开";
            this.tsmItemOpen.Click += new System.EventHandler(this.TsmItemOpen_Click);
            // 
            // tsmItemDelete
            // 
            this.tsmItemDelete.Name = "tsmItemDelete";
            this.tsmItemDelete.Size = new System.Drawing.Size(182, 22);
            this.tsmItemDelete.Text = "删除";
            this.tsmItemDelete.Click += new System.EventHandler(this.TsmItemDelete_Click);
            // 
            // tsmItemCut
            // 
            this.tsmItemCut.Name = "tsmItemCut";
            this.tsmItemCut.Size = new System.Drawing.Size(182, 22);
            this.tsmItemCut.Text = "移动（剪切）";
            this.tsmItemCut.Visible = false;
            this.tsmItemCut.Click += new System.EventHandler(this.TsmItemCut_Click);
            // 
            // tsmItemCopy
            // 
            this.tsmItemCopy.Name = "tsmItemCopy";
            this.tsmItemCopy.Size = new System.Drawing.Size(182, 22);
            this.tsmItemCopy.Text = "移动（复制）";
            this.tsmItemCopy.Visible = false;
            this.tsmItemCopy.Click += new System.EventHandler(this.TsmItemCopy_Click);
            // 
            // tsmItemReplace
            // 
            this.tsmItemReplace.Name = "tsmItemReplace";
            this.tsmItemReplace.Size = new System.Drawing.Size(182, 22);
            this.tsmItemReplace.Text = "提取到\"批量替换\"";
            this.tsmItemReplace.Click += new System.EventHandler(this.TsmItemReplace_Click);
            // 
            // tsmItemRename
            // 
            this.tsmItemRename.Name = "tsmItemRename";
            this.tsmItemRename.Size = new System.Drawing.Size(182, 22);
            this.tsmItemRename.Text = "提取到\"批量重命名\"";
            this.tsmItemRename.Click += new System.EventHandler(this.TsmItemRename_Click);
            // 
            // pgBar
            // 
            this.pgBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pgBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pgBar.Location = new System.Drawing.Point(0, 0);
            this.pgBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(426, 18);
            this.pgBar.Step = 1;
            this.pgBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgBar.TabIndex = 6;
            this.pgBar.Visible = false;
            // 
            // folderBrowser
            // 
            this.folderBrowser.ShowNewFolderButton = false;
            // 
            // uc文件操作
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fileLV);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.tbPanel);
            this.Controls.Add(this.pgBar);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "uc文件操作";
            this.Size = new System.Drawing.Size(426, 412);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.lvMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tbPanel;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.TextBox txtDirpath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btReplace;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btReName;
        private System.Windows.Forms.TextBox txtReName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader cName;
        private System.Windows.Forms.ColumnHeader cType;
        private System.Windows.Forms.ColumnHeader cMD5;
        private System.Windows.Forms.ProgressBar pgBar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.CheckBox cbDG;
        private System.Windows.Forms.ContextMenuStrip lvMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmItemOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmItemDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmItemCut;
        private System.Windows.Forms.ToolStripMenuItem tsmItemCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmItemReplace;
        private System.Windows.Forms.ToolStripMenuItem tsmItemRename;
        public System.Windows.Forms.ListView fileLV;
    }
}
