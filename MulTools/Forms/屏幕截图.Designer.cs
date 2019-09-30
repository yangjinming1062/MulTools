namespace MulTools.Forms
{
    partial class 屏幕截图
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.settingMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_cmbPicType = new System.Windows.Forms.ToolStripComboBox();
            this.删除临时图片长图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_cmbLong = new System.Windows.Forms.ToolStripComboBox();
            this.删除临时图片动图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_cmbGIF = new System.Windows.Forms.ToolStripComboBox();
            this.动图帧间隔ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_GIFframetime = new System.Windows.Forms.ToolStripTextBox();
            this.动图捕获间隔ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_txtGiftime = new System.Windows.Forms.ToolStripTextBox();
            this.长图捕获间隔ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_txtLongtime = new System.Windows.Forms.ToolStripTextBox();
            this.永久记录当前保存路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_cmbPath = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btCLose = new System.Windows.Forms.Button();
            this.lbBar = new System.Windows.Forms.Label();
            this.button18 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btSavePath = new System.Windows.Forms.Button();
            this.btLong = new System.Windows.Forms.Button();
            this.btGif = new System.Windows.Forms.Button();
            this.btJPG = new System.Windows.Forms.Button();
            this.btPen = new System.Windows.Forms.Button();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.DirPathDg = new System.Windows.Forms.FolderBrowserDialog();
            this.lbBottom = new System.Windows.Forms.Label();
            this.lbLeft = new System.Windows.Forms.Label();
            this.lbRight = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bgWorkerLong = new System.ComponentModel.BackgroundWorker();
            this.panelTop.SuspendLayout();
            this.settingMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.Control;
            this.panelTop.ContextMenuStrip = this.settingMenu;
            this.panelTop.Controls.Add(this.btCLose);
            this.panelTop.Controls.Add(this.lbBar);
            this.panelTop.Controls.Add(this.button18);
            this.panelTop.Controls.Add(this.button9);
            this.panelTop.Controls.Add(this.button17);
            this.panelTop.Controls.Add(this.button6);
            this.panelTop.Controls.Add(this.button16);
            this.panelTop.Controls.Add(this.button15);
            this.panelTop.Controls.Add(this.button3);
            this.panelTop.Controls.Add(this.button14);
            this.panelTop.Controls.Add(this.button8);
            this.panelTop.Controls.Add(this.button13);
            this.panelTop.Controls.Add(this.button5);
            this.panelTop.Controls.Add(this.button12);
            this.panelTop.Controls.Add(this.button7);
            this.panelTop.Controls.Add(this.button11);
            this.panelTop.Controls.Add(this.button4);
            this.panelTop.Controls.Add(this.button10);
            this.panelTop.Controls.Add(this.button2);
            this.panelTop.Controls.Add(this.button1);
            this.panelTop.Controls.Add(this.txtPath);
            this.panelTop.Controls.Add(this.btSavePath);
            this.panelTop.Controls.Add(this.btLong);
            this.panelTop.Controls.Add(this.btGif);
            this.panelTop.Controls.Add(this.btJPG);
            this.panelTop.Controls.Add(this.btPen);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(589, 32);
            this.panelTop.TabIndex = 0;
            // 
            // settingMenu
            // 
            this.settingMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.删除临时图片长图ToolStripMenuItem,
            this.删除临时图片动图ToolStripMenuItem,
            this.动图帧间隔ToolStripMenuItem,
            this.动图捕获间隔ToolStripMenuItem,
            this.长图捕获间隔ToolStripMenuItem,
            this.永久记录当前保存路径ToolStripMenuItem,
            this.toolStripMenuItem2});
            this.settingMenu.Name = "settingMenu";
            this.settingMenu.Size = new System.Drawing.Size(197, 202);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_cmbPicType});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem1.Text = "截图文件类型";
            // 
            // menu_cmbPicType
            // 
            this.menu_cmbPicType.BackColor = System.Drawing.SystemColors.Info;
            this.menu_cmbPicType.Items.AddRange(new object[] {
            "bmp",
            "jpg"});
            this.menu_cmbPicType.Name = "menu_cmbPicType";
            this.menu_cmbPicType.Size = new System.Drawing.Size(121, 25);
            this.menu_cmbPicType.Text = "bmp";
            // 
            // 删除临时图片长图ToolStripMenuItem
            // 
            this.删除临时图片长图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_cmbLong});
            this.删除临时图片长图ToolStripMenuItem.Name = "删除临时图片长图ToolStripMenuItem";
            this.删除临时图片长图ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.删除临时图片长图ToolStripMenuItem.Text = "删除临时图片（长图）";
            // 
            // menu_cmbLong
            // 
            this.menu_cmbLong.BackColor = System.Drawing.SystemColors.Info;
            this.menu_cmbLong.Items.AddRange(new object[] {
            "是",
            "否"});
            this.menu_cmbLong.Name = "menu_cmbLong";
            this.menu_cmbLong.Size = new System.Drawing.Size(75, 25);
            this.menu_cmbLong.Text = "是";
            // 
            // 删除临时图片动图ToolStripMenuItem
            // 
            this.删除临时图片动图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_cmbGIF});
            this.删除临时图片动图ToolStripMenuItem.Name = "删除临时图片动图ToolStripMenuItem";
            this.删除临时图片动图ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.删除临时图片动图ToolStripMenuItem.Text = "删除临时图片（动图）";
            // 
            // menu_cmbGIF
            // 
            this.menu_cmbGIF.BackColor = System.Drawing.SystemColors.Info;
            this.menu_cmbGIF.Items.AddRange(new object[] {
            "是",
            "否"});
            this.menu_cmbGIF.Name = "menu_cmbGIF";
            this.menu_cmbGIF.Size = new System.Drawing.Size(75, 25);
            this.menu_cmbGIF.Text = "是";
            // 
            // 动图帧间隔ToolStripMenuItem
            // 
            this.动图帧间隔ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_GIFframetime});
            this.动图帧间隔ToolStripMenuItem.Name = "动图帧间隔ToolStripMenuItem";
            this.动图帧间隔ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.动图帧间隔ToolStripMenuItem.Text = "动图帧间隔";
            // 
            // menu_GIFframetime
            // 
            this.menu_GIFframetime.BackColor = System.Drawing.SystemColors.Info;
            this.menu_GIFframetime.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.menu_GIFframetime.Name = "menu_GIFframetime";
            this.menu_GIFframetime.Size = new System.Drawing.Size(60, 23);
            this.menu_GIFframetime.Text = "10";
            // 
            // 动图捕获间隔ToolStripMenuItem
            // 
            this.动图捕获间隔ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_txtGiftime});
            this.动图捕获间隔ToolStripMenuItem.Name = "动图捕获间隔ToolStripMenuItem";
            this.动图捕获间隔ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.动图捕获间隔ToolStripMenuItem.Text = "动图捕获间隔";
            // 
            // menu_txtGiftime
            // 
            this.menu_txtGiftime.BackColor = System.Drawing.SystemColors.Info;
            this.menu_txtGiftime.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.menu_txtGiftime.Name = "menu_txtGiftime";
            this.menu_txtGiftime.Size = new System.Drawing.Size(60, 23);
            this.menu_txtGiftime.Text = "100";
            // 
            // 长图捕获间隔ToolStripMenuItem
            // 
            this.长图捕获间隔ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_txtLongtime});
            this.长图捕获间隔ToolStripMenuItem.Name = "长图捕获间隔ToolStripMenuItem";
            this.长图捕获间隔ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.长图捕获间隔ToolStripMenuItem.Text = "长图捕获间隔";
            // 
            // menu_txtLongtime
            // 
            this.menu_txtLongtime.BackColor = System.Drawing.SystemColors.Info;
            this.menu_txtLongtime.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.menu_txtLongtime.Name = "menu_txtLongtime";
            this.menu_txtLongtime.Size = new System.Drawing.Size(60, 23);
            this.menu_txtLongtime.Text = "300";
            // 
            // 永久记录当前保存路径ToolStripMenuItem
            // 
            this.永久记录当前保存路径ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_cmbPath});
            this.永久记录当前保存路径ToolStripMenuItem.Name = "永久记录当前保存路径ToolStripMenuItem";
            this.永久记录当前保存路径ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.永久记录当前保存路径ToolStripMenuItem.Text = "永久记录当前保存路径";
            // 
            // menu_cmbPath
            // 
            this.menu_cmbPath.BackColor = System.Drawing.SystemColors.Info;
            this.menu_cmbPath.Items.AddRange(new object[] {
            "是",
            "否"});
            this.menu_cmbPath.Name = "menu_cmbPath";
            this.menu_cmbPath.Size = new System.Drawing.Size(75, 25);
            this.menu_cmbPath.Text = "否";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.SystemColors.Info;
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.Red;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem2.Text = "*以上修改重启生效*";
            // 
            // btCLose
            // 
            this.btCLose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCLose.BackColor = System.Drawing.Color.Red;
            this.btCLose.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btCLose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCLose.Font = new System.Drawing.Font("宋体", 9F);
            this.btCLose.ForeColor = System.Drawing.Color.White;
            this.btCLose.Location = new System.Drawing.Point(558, 6);
            this.btCLose.Margin = new System.Windows.Forms.Padding(2);
            this.btCLose.Name = "btCLose";
            this.btCLose.Size = new System.Drawing.Size(20, 20);
            this.btCLose.TabIndex = 24;
            this.btCLose.Text = "X";
            this.btCLose.UseVisualStyleBackColor = false;
            this.btCLose.Click += new System.EventHandler(this.btCLose_Click);
            // 
            // lbBar
            // 
            this.lbBar.BackColor = System.Drawing.Color.PaleGreen;
            this.lbBar.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Italic);
            this.lbBar.Location = new System.Drawing.Point(9, 4);
            this.lbBar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbBar.Name = "lbBar";
            this.lbBar.Size = new System.Drawing.Size(128, 24);
            this.lbBar.TabIndex = 21;
            this.lbBar.Text = "图像合成中...";
            this.lbBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbBar.Visible = false;
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.Black;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Location = new System.Drawing.Point(312, 16);
            this.button18.Margin = new System.Windows.Forms.Padding(2);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(11, 12);
            this.button18.TabIndex = 20;
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.Bt_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.DarkViolet;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(312, 3);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(11, 12);
            this.button9.TabIndex = 11;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.Bt_Click);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.Gray;
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.Location = new System.Drawing.Point(276, 16);
            this.button17.Margin = new System.Windows.Forms.Padding(2);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(11, 12);
            this.button17.TabIndex = 17;
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.Bt_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Blue;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(276, 3);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(11, 12);
            this.button6.TabIndex = 8;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.Bt_Click);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.SpringGreen;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Location = new System.Drawing.Point(240, 16);
            this.button16.Margin = new System.Windows.Forms.Padding(2);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(11, 12);
            this.button16.TabIndex = 14;
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.Bt_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.DarkRed;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Location = new System.Drawing.Point(300, 16);
            this.button15.Margin = new System.Windows.Forms.Padding(2);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(11, 12);
            this.button15.TabIndex = 19;
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.Bt_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Yellow;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(240, 3);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(11, 12);
            this.button3.TabIndex = 5;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Bt_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Sienna;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Location = new System.Drawing.Point(264, 16);
            this.button14.Margin = new System.Windows.Forms.Padding(2);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(11, 12);
            this.button14.TabIndex = 16;
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.Bt_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Violet;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(300, 3);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(11, 12);
            this.button8.TabIndex = 10;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.Bt_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Silver;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Location = new System.Drawing.Point(288, 16);
            this.button13.Margin = new System.Windows.Forms.Padding(2);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(11, 12);
            this.button13.TabIndex = 18;
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.Bt_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Aquamarine;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(264, 3);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(11, 12);
            this.button5.TabIndex = 7;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.Bt_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Khaki;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Location = new System.Drawing.Point(252, 16);
            this.button12.Margin = new System.Windows.Forms.Padding(2);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(11, 12);
            this.button12.TabIndex = 15;
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.Bt_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Purple;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(288, 3);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(11, 12);
            this.button7.TabIndex = 9;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.Bt_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.RoyalBlue;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Location = new System.Drawing.Point(228, 16);
            this.button11.Margin = new System.Windows.Forms.Padding(2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(11, 12);
            this.button11.TabIndex = 13;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.Bt_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Green;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(252, 3);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(11, 12);
            this.button4.TabIndex = 6;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Bt_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.DeepPink;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Location = new System.Drawing.Point(216, 16);
            this.button10.Margin = new System.Windows.Forms.Padding(2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(11, 12);
            this.button10.TabIndex = 12;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.Bt_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(228, 3);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(11, 12);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Bt_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(216, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(11, 12);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Bt_Click);
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.SystemColors.Info;
            this.txtPath.Location = new System.Drawing.Point(421, 7);
            this.txtPath.Margin = new System.Windows.Forms.Padding(2);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(118, 21);
            this.txtPath.TabIndex = 2;
            this.txtPath.TabStop = false;
            // 
            // btSavePath
            // 
            this.btSavePath.BackColor = System.Drawing.Color.SkyBlue;
            this.btSavePath.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.btSavePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSavePath.Font = new System.Drawing.Font("楷体", 9F);
            this.btSavePath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btSavePath.Location = new System.Drawing.Point(335, 4);
            this.btSavePath.Margin = new System.Windows.Forms.Padding(2);
            this.btSavePath.Name = "btSavePath";
            this.btSavePath.Size = new System.Drawing.Size(81, 24);
            this.btSavePath.TabIndex = 0;
            this.btSavePath.TabStop = false;
            this.btSavePath.Text = "保存位置：";
            this.btSavePath.UseVisualStyleBackColor = false;
            this.btSavePath.Click += new System.EventHandler(this.BtSavePath_Click);
            // 
            // btLong
            // 
            this.btLong.BackColor = System.Drawing.Color.Aquamarine;
            this.btLong.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.btLong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLong.Font = new System.Drawing.Font("楷体", 9F);
            this.btLong.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btLong.Location = new System.Drawing.Point(98, 4);
            this.btLong.Margin = new System.Windows.Forms.Padding(2);
            this.btLong.Name = "btLong";
            this.btLong.Size = new System.Drawing.Size(40, 24);
            this.btLong.TabIndex = 1;
            this.btLong.TabStop = false;
            this.btLong.Text = "长图";
            this.btLong.UseVisualStyleBackColor = false;
            this.btLong.Click += new System.EventHandler(this.BtLong_Click);
            // 
            // btGif
            // 
            this.btGif.BackColor = System.Drawing.Color.Aquamarine;
            this.btGif.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.btGif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGif.Font = new System.Drawing.Font("楷体", 9F);
            this.btGif.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btGif.Location = new System.Drawing.Point(53, 4);
            this.btGif.Margin = new System.Windows.Forms.Padding(2);
            this.btGif.Name = "btGif";
            this.btGif.Size = new System.Drawing.Size(40, 24);
            this.btGif.TabIndex = 1;
            this.btGif.TabStop = false;
            this.btGif.Text = "动图";
            this.btGif.UseVisualStyleBackColor = false;
            this.btGif.Click += new System.EventHandler(this.BtGif_Click);
            // 
            // btJPG
            // 
            this.btJPG.BackColor = System.Drawing.Color.Aquamarine;
            this.btJPG.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.btJPG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btJPG.Font = new System.Drawing.Font("楷体", 9F);
            this.btJPG.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btJPG.Location = new System.Drawing.Point(9, 4);
            this.btJPG.Margin = new System.Windows.Forms.Padding(2);
            this.btJPG.Name = "btJPG";
            this.btJPG.Size = new System.Drawing.Size(40, 24);
            this.btJPG.TabIndex = 0;
            this.btJPG.TabStop = false;
            this.btJPG.Text = "静图";
            this.btJPG.UseVisualStyleBackColor = false;
            this.btJPG.Click += new System.EventHandler(this.BtJPG_Click);
            // 
            // btPen
            // 
            this.btPen.BackColor = System.Drawing.Color.SkyBlue;
            this.btPen.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
            this.btPen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPen.Font = new System.Drawing.Font("楷体", 9F);
            this.btPen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btPen.Location = new System.Drawing.Point(144, 4);
            this.btPen.Margin = new System.Windows.Forms.Padding(2);
            this.btPen.Name = "btPen";
            this.btPen.Size = new System.Drawing.Size(66, 24);
            this.btPen.TabIndex = 2;
            this.btPen.Text = "启动画笔";
            this.btPen.UseVisualStyleBackColor = false;
            this.btPen.Click += new System.EventHandler(this.BtPen_Click);
            // 
            // picBox
            // 
            this.picBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox.Location = new System.Drawing.Point(0, 32);
            this.picBox.Margin = new System.Windows.Forms.Padding(2);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(589, 328);
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            // 
            // lbBottom
            // 
            this.lbBottom.BackColor = System.Drawing.Color.Black;
            this.lbBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbBottom.Location = new System.Drawing.Point(0, 359);
            this.lbBottom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbBottom.Name = "lbBottom";
            this.lbBottom.Size = new System.Drawing.Size(589, 1);
            this.lbBottom.TabIndex = 2;
            this.lbBottom.Text = "————";
            // 
            // lbLeft
            // 
            this.lbLeft.BackColor = System.Drawing.Color.Black;
            this.lbLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbLeft.Location = new System.Drawing.Point(0, 32);
            this.lbLeft.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLeft.Name = "lbLeft";
            this.lbLeft.Size = new System.Drawing.Size(1, 327);
            this.lbLeft.TabIndex = 3;
            this.lbLeft.Text = "————";
            // 
            // lbRight
            // 
            this.lbRight.BackColor = System.Drawing.Color.Black;
            this.lbRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbRight.Location = new System.Drawing.Point(588, 32);
            this.lbRight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbRight.Name = "lbRight";
            this.lbRight.Size = new System.Drawing.Size(1, 327);
            this.lbRight.TabIndex = 4;
            this.lbRight.Text = ".";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(1, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(587, 1);
            this.label4.TabIndex = 5;
            this.label4.Text = ".";
            // 
            // bgWorkerLong
            // 
            this.bgWorkerLong.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerLong_DoWork);
            this.bgWorkerLong.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerLong_RunWorkerCompleted);
            // 
            // 屏幕截图
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(589, 360);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbRight);
            this.Controls.Add(this.lbLeft);
            this.Controls.Add(this.lbBottom);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "屏幕截图";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "屏幕截图";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.屏幕截图_FormClosed);
            this.Load += new System.EventHandler(this.屏幕截图_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.settingMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btPen;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Button btSavePath;
        private System.Windows.Forms.Button btGif;
        private System.Windows.Forms.Button btJPG;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.FolderBrowserDialog DirPathDg;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btLong;
        private System.Windows.Forms.Label lbBottom;
        private System.Windows.Forms.Label lbLeft;
        private System.Windows.Forms.Label lbRight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbBar;
        private System.ComponentModel.BackgroundWorker bgWorkerLong;
        private System.Windows.Forms.Button btCLose;
        private System.Windows.Forms.ContextMenuStrip settingMenu;
        private System.Windows.Forms.ToolStripMenuItem 删除临时图片长图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox menu_cmbLong;
        private System.Windows.Forms.ToolStripMenuItem 删除临时图片动图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox menu_cmbGIF;
        private System.Windows.Forms.ToolStripMenuItem 动图帧间隔ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox menu_GIFframetime;
        private System.Windows.Forms.ToolStripMenuItem 动图捕获间隔ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox menu_txtGiftime;
        private System.Windows.Forms.ToolStripMenuItem 长图捕获间隔ToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox menu_txtLongtime;
        private System.Windows.Forms.ToolStripMenuItem 永久记录当前保存路径ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox menu_cmbPath;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripComboBox menu_cmbPicType;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}