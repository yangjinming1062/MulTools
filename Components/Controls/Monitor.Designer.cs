namespace MulTools.Components
{
    partial class Monitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monitor));
            this.MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuitem_Select = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitem_IsShowBorder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitem_ClickThrough = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitem_PositionLock = new System.Windows.Forms.ToolStripMenuItem();
            this.PosLockNUll = new System.Windows.Forms.ToolStripMenuItem();
            this.PosLockTL = new System.Windows.Forms.ToolStripMenuItem();
            this.PosLockTR = new System.Windows.Forms.ToolStripMenuItem();
            this.PosLockC = new System.Windows.Forms.ToolStripMenuItem();
            this.PosLockBL = new System.Windows.Forms.ToolStripMenuItem();
            this.PosLockBR = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitem_Opacity = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuitem_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitem_Select,
            this.menuitem_IsShowBorder,
            this.menuitem_ClickThrough,
            this.menuitem_PositionLock,
            this.menuitem_Opacity,
            this.toolStripSeparator1,
            this.menuitem_Close});
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(125, 142);
            this.MenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.MenuStrip_Opening);
            // 
            // menuitem_Select
            // 
            this.menuitem_Select.Name = "menuitem_Select";
            this.menuitem_Select.Size = new System.Drawing.Size(124, 22);
            this.menuitem_Select.Text = "选择进程";
            this.menuitem_Select.DropDownOpening += new System.EventHandler(this.SelectWindows_DropDownOpening);
            // 
            // menuitem_IsShowBorder
            // 
            this.menuitem_IsShowBorder.Name = "menuitem_IsShowBorder";
            this.menuitem_IsShowBorder.Size = new System.Drawing.Size(124, 22);
            this.menuitem_IsShowBorder.Text = "显示边框";
            this.menuitem_IsShowBorder.Click += new System.EventHandler(this.IsShowBorder_Click);
            // 
            // menuitem_ClickThrough
            // 
            this.menuitem_ClickThrough.Name = "menuitem_ClickThrough";
            this.menuitem_ClickThrough.Size = new System.Drawing.Size(124, 22);
            this.menuitem_ClickThrough.Text = "点击穿透";
            this.menuitem_ClickThrough.Click += new System.EventHandler(this.ClickThrough_Click);
            // 
            // menuitem_PositionLock
            // 
            this.menuitem_PositionLock.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PosLockNUll,
            this.PosLockTL,
            this.PosLockTR,
            this.PosLockC,
            this.PosLockBL,
            this.PosLockBR});
            this.menuitem_PositionLock.Image = global::MulTools.Components.Properties.Resources.pos_null;
            this.menuitem_PositionLock.Name = "menuitem_PositionLock";
            this.menuitem_PositionLock.Size = new System.Drawing.Size(124, 22);
            this.menuitem_PositionLock.Text = "位置锁定";
            // 
            // PosLockNUll
            // 
            this.PosLockNUll.Checked = true;
            this.PosLockNUll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PosLockNUll.Name = "PosLockNUll";
            this.PosLockNUll.Size = new System.Drawing.Size(112, 22);
            this.PosLockNUll.Text = "不锁定";
            this.PosLockNUll.Click += new System.EventHandler(this.PositionLock_Click);
            // 
            // PosLockTL
            // 
            this.PosLockTL.Image = global::MulTools.Components.Properties.Resources.pos_topleft;
            this.PosLockTL.Name = "PosLockTL";
            this.PosLockTL.Size = new System.Drawing.Size(112, 22);
            this.PosLockTL.Text = "左上";
            this.PosLockTL.Click += new System.EventHandler(this.PositionLock_Click);
            // 
            // PosLockTR
            // 
            this.PosLockTR.Image = global::MulTools.Components.Properties.Resources.pos_topright;
            this.PosLockTR.Name = "PosLockTR";
            this.PosLockTR.Size = new System.Drawing.Size(112, 22);
            this.PosLockTR.Text = "右上";
            this.PosLockTR.Click += new System.EventHandler(this.PositionLock_Click);
            // 
            // PosLockC
            // 
            this.PosLockC.Image = global::MulTools.Components.Properties.Resources.pos_center;
            this.PosLockC.Name = "PosLockC";
            this.PosLockC.Size = new System.Drawing.Size(112, 22);
            this.PosLockC.Text = "中间";
            this.PosLockC.Click += new System.EventHandler(this.PositionLock_Click);
            // 
            // PosLockBL
            // 
            this.PosLockBL.Image = global::MulTools.Components.Properties.Resources.pos_bottomleft;
            this.PosLockBL.Name = "PosLockBL";
            this.PosLockBL.Size = new System.Drawing.Size(112, 22);
            this.PosLockBL.Text = "左下";
            this.PosLockBL.Click += new System.EventHandler(this.PositionLock_Click);
            // 
            // PosLockBR
            // 
            this.PosLockBR.Image = global::MulTools.Components.Properties.Resources.pos_bottomright;
            this.PosLockBR.Name = "PosLockBR";
            this.PosLockBR.Size = new System.Drawing.Size(112, 22);
            this.PosLockBR.Text = "右下";
            this.PosLockBR.Click += new System.EventHandler(this.PositionLock_Click);
            // 
            // menuitem_Opacity
            // 
            this.menuitem_Opacity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.menuitem_Opacity.Name = "menuitem_Opacity";
            this.menuitem_Opacity.Size = new System.Drawing.Size(124, 22);
            this.menuitem_Opacity.Text = "透明度";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(108, 22);
            this.toolStripMenuItem1.Tag = "1";
            this.toolStripMenuItem1.Text = "100%";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.Opacity_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(108, 22);
            this.toolStripMenuItem2.Tag = "0.75";
            this.toolStripMenuItem2.Text = "75%";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.Opacity_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(108, 22);
            this.toolStripMenuItem3.Tag = "0.5";
            this.toolStripMenuItem3.Text = "50%";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.Opacity_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(108, 22);
            this.toolStripMenuItem4.Tag = "0.25";
            this.toolStripMenuItem4.Text = "25%";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.Opacity_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // menuitem_Close
            // 
            this.menuitem_Close.Name = "menuitem_Close";
            this.menuitem_Close.Size = new System.Drawing.Size(124, 22);
            this.menuitem_Close.Text = "关闭";
            this.menuitem_Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 371);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.HideCaption = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Monitor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Monitor";
            this.TopMost = true;
            this.MenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuitem_Select;
        private System.Windows.Forms.ToolStripMenuItem menuitem_IsShowBorder;
        private System.Windows.Forms.ToolStripMenuItem menuitem_ClickThrough;
        private System.Windows.Forms.ToolStripMenuItem menuitem_PositionLock;
        private System.Windows.Forms.ToolStripMenuItem menuitem_Opacity;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuitem_Close;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem PosLockNUll;
        private System.Windows.Forms.ToolStripMenuItem PosLockTL;
        private System.Windows.Forms.ToolStripMenuItem PosLockTR;
        private System.Windows.Forms.ToolStripMenuItem PosLockC;
        private System.Windows.Forms.ToolStripMenuItem PosLockBL;
        private System.Windows.Forms.ToolStripMenuItem PosLockBR;
    }
}