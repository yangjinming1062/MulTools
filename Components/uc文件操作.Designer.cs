namespace Components
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
            this.fsWatcher = new System.IO.FileSystemWatcher();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.tbPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDirpath = new System.Windows.Forms.TextBox();
            this.btBrowse = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            this.btOpen = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.btReplace = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReName = new System.Windows.Forms.TextBox();
            this.btReName = new System.Windows.Forms.Button();
            this.fileLV = new System.Windows.Forms.ListView();
            this.cName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cMD5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pgBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.fsWatcher)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // fsWatcher
            // 
            this.fsWatcher.EnableRaisingEvents = true;
            this.fsWatcher.SynchronizingObject = this;
            // 
            // tbPanel
            // 
            this.tbPanel.ColumnCount = 2;
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbPanel.Location = new System.Drawing.Point(0, 409);
            this.tbPanel.Name = "tbPanel";
            this.tbPanel.RowCount = 2;
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPanel.Size = new System.Drawing.Size(512, 84);
            this.tbPanel.TabIndex = 2;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btOpen);
            this.panelTop.Controls.Add(this.btBack);
            this.panelTop.Controls.Add(this.btBrowse);
            this.panelTop.Controls.Add(this.txtDirpath);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 23);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(512, 25);
            this.panelTop.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件夹：";
            // 
            // txtDirpath
            // 
            this.txtDirpath.Location = new System.Drawing.Point(74, 0);
            this.txtDirpath.Name = "txtDirpath";
            this.txtDirpath.Size = new System.Drawing.Size(293, 25);
            this.txtDirpath.TabIndex = 1;
            // 
            // btBrowse
            // 
            this.btBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBrowse.Location = new System.Drawing.Point(366, 1);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(41, 23);
            this.btBrowse.TabIndex = 2;
            this.btBrowse.Text = "...";
            this.btBrowse.UseVisualStyleBackColor = true;
            // 
            // btBack
            // 
            this.btBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btBack.Location = new System.Drawing.Point(413, 1);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(48, 23);
            this.btBack.TabIndex = 3;
            this.btBack.Text = "Back";
            this.btBack.UseVisualStyleBackColor = true;
            // 
            // btOpen
            // 
            this.btOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btOpen.Location = new System.Drawing.Point(461, 1);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(48, 23);
            this.btOpen.TabIndex = 3;
            this.btOpen.Text = "Open";
            this.btOpen.UseVisualStyleBackColor = true;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btReName);
            this.panelBottom.Controls.Add(this.btReplace);
            this.panelBottom.Controls.Add(this.txtTarget);
            this.panelBottom.Controls.Add(this.txtReName);
            this.panelBottom.Controls.Add(this.txtSource);
            this.panelBottom.Controls.Add(this.label3);
            this.panelBottom.Controls.Add(this.label4);
            this.panelBottom.Controls.Add(this.label2);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 342);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(512, 67);
            this.panelBottom.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "批量替换：";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(102, 7);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(198, 25);
            this.txtSource.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(303, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "→";
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(338, 7);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(100, 25);
            this.txtTarget.TabIndex = 2;
            // 
            // btReplace
            // 
            this.btReplace.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btReplace.Location = new System.Drawing.Point(444, 7);
            this.btReplace.Name = "btReplace";
            this.btReplace.Size = new System.Drawing.Size(65, 23);
            this.btReplace.TabIndex = 3;
            this.btReplace.Text = "替换";
            this.btReplace.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "批量重命名[序号]：";
            // 
            // txtReName
            // 
            this.txtReName.Location = new System.Drawing.Point(164, 37);
            this.txtReName.Name = "txtReName";
            this.txtReName.Size = new System.Drawing.Size(274, 25);
            this.txtReName.TabIndex = 1;
            // 
            // btReName
            // 
            this.btReName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btReName.Location = new System.Drawing.Point(444, 38);
            this.btReName.Name = "btReName";
            this.btReName.Size = new System.Drawing.Size(65, 23);
            this.btReName.TabIndex = 3;
            this.btReName.Text = "修改";
            this.btReName.UseVisualStyleBackColor = true;
            // 
            // fileLV
            // 
            this.fileLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cName,
            this.cType,
            this.cMD5});
            this.fileLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileLV.HideSelection = false;
            this.fileLV.Location = new System.Drawing.Point(0, 48);
            this.fileLV.Name = "fileLV";
            this.fileLV.Size = new System.Drawing.Size(512, 294);
            this.fileLV.TabIndex = 5;
            this.fileLV.UseCompatibleStateImageBehavior = false;
            this.fileLV.View = System.Windows.Forms.View.Details;
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
            this.cMD5.Width = 120;
            // 
            // pgBar
            // 
            this.pgBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pgBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pgBar.Location = new System.Drawing.Point(0, 0);
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(512, 23);
            this.pgBar.Step = 1;
            this.pgBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgBar.TabIndex = 6;
            this.pgBar.Visible = false;
            // 
            // uc文件操作
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fileLV);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.tbPanel);
            this.Controls.Add(this.pgBar);
            this.Name = "uc文件操作";
            this.Size = new System.Drawing.Size(512, 493);
            ((System.ComponentModel.ISupportInitialize)(this.fsWatcher)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.FileSystemWatcher fsWatcher;
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
        private System.Windows.Forms.ListView fileLV;
        private System.Windows.Forms.ColumnHeader cName;
        private System.Windows.Forms.ColumnHeader cType;
        private System.Windows.Forms.ColumnHeader cMD5;
        private System.Windows.Forms.ProgressBar pgBar;
    }
}
