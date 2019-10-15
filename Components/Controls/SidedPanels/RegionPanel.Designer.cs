namespace MulTools.Components
{
    partial class RegionPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupRegions = new System.Windows.Forms.GroupBox();
            this.checkRelative = new System.Windows.Forms.CheckBox();
            this.numH = new System.Windows.Forms.NumericUpDown();
            this.numW = new System.Windows.Forms.NumericUpDown();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.buttonDone = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelCurrentRegion = new System.Windows.Forms.Label();
            this.groupRegions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            this.SuspendLayout();
            // 
            // groupRegions
            // 
            this.groupRegions.Controls.Add(this.checkRelative);
            this.groupRegions.Controls.Add(this.numH);
            this.groupRegions.Controls.Add(this.numW);
            this.groupRegions.Controls.Add(this.numY);
            this.groupRegions.Controls.Add(this.numX);
            this.groupRegions.Controls.Add(this.buttonDone);
            this.groupRegions.Controls.Add(this.buttonReset);
            this.groupRegions.Controls.Add(this.labelHeight);
            this.groupRegions.Controls.Add(this.labelWidth);
            this.groupRegions.Controls.Add(this.labelY);
            this.groupRegions.Controls.Add(this.labelX);
            this.groupRegions.Controls.Add(this.labelCurrentRegion);
            this.groupRegions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupRegions.Location = new System.Drawing.Point(7, 8);
            this.groupRegions.Name = "groupRegions";
            this.groupRegions.Size = new System.Drawing.Size(254, 193);
            this.groupRegions.TabIndex = 0;
            this.groupRegions.TabStop = false;
            // 
            // checkRelative
            // 
            this.checkRelative.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkRelative.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkRelative.Location = new System.Drawing.Point(7, 114);
            this.checkRelative.Name = "checkRelative";
            this.checkRelative.Size = new System.Drawing.Size(240, 24);
            this.checkRelative.TabIndex = 12;
            this.checkRelative.Text = "关联到边框";
            this.checkRelative.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkRelative.UseVisualStyleBackColor = true;
            this.checkRelative.CheckedChanged += new System.EventHandler(this.CheckRelative_checked);
            // 
            // numH
            // 
            this.numH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numH.Enabled = false;
            this.numH.Location = new System.Drawing.Point(197, 80);
            this.numH.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numH.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numH.Name = "numH";
            this.numH.Size = new System.Drawing.Size(50, 23);
            this.numH.TabIndex = 7;
            this.numH.ValueChanged += new System.EventHandler(this.RegionValueSpinner_value_change);
            // 
            // numW
            // 
            this.numW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numW.Enabled = false;
            this.numW.Location = new System.Drawing.Point(197, 46);
            this.numW.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numW.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numW.Name = "numW";
            this.numW.Size = new System.Drawing.Size(50, 23);
            this.numW.TabIndex = 6;
            this.numW.ValueChanged += new System.EventHandler(this.RegionValueSpinner_value_change);
            // 
            // numY
            // 
            this.numY.Enabled = false;
            this.numY.Location = new System.Drawing.Point(64, 80);
            this.numY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numY.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(50, 23);
            this.numY.TabIndex = 5;
            this.numY.ValueChanged += new System.EventHandler(this.RegionValueSpinner_value_change);
            // 
            // numX
            // 
            this.numX.Enabled = false;
            this.numX.Location = new System.Drawing.Point(64, 46);
            this.numX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numX.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(50, 23);
            this.numX.TabIndex = 4;
            this.numX.ValueChanged += new System.EventHandler(this.RegionValueSpinner_value_change);
            // 
            // buttonDone
            // 
            this.buttonDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDone.Location = new System.Drawing.Point(166, 144);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(82, 31);
            this.buttonDone.TabIndex = 9;
            this.buttonDone.Text = "完成";
            this.buttonDone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.Close_click);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.Location = new System.Drawing.Point(77, 144);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(82, 31);
            this.buttonReset.TabIndex = 8;
            this.buttonReset.Text = "重置";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.Reset_click);
            // 
            // labelHeight
            // 
            this.labelHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHeight.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelHeight.Location = new System.Drawing.Point(121, 84);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(70, 24);
            this.labelHeight.TabIndex = 9;
            this.labelHeight.Text = "Height";
            this.labelHeight.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelWidth
            // 
            this.labelWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWidth.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelWidth.Location = new System.Drawing.Point(125, 50);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(66, 24);
            this.labelWidth.TabIndex = 8;
            this.labelWidth.Text = "Width";
            this.labelWidth.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelY
            // 
            this.labelY.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelY.Location = new System.Drawing.Point(7, 85);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(50, 23);
            this.labelY.TabIndex = 5;
            this.labelY.Text = "Y";
            this.labelY.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelX
            // 
            this.labelX.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelX.Location = new System.Drawing.Point(7, 51);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(50, 23);
            this.labelX.TabIndex = 4;
            this.labelX.Text = "X";
            this.labelX.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelCurrentRegion
            // 
            this.labelCurrentRegion.AutoSize = true;
            this.labelCurrentRegion.Location = new System.Drawing.Point(7, 21);
            this.labelCurrentRegion.Name = "labelCurrentRegion";
            this.labelCurrentRegion.Size = new System.Drawing.Size(68, 17);
            this.labelCurrentRegion.TabIndex = 3;
            this.labelCurrentRegion.Text = "当前区域：";
            // 
            // RegionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupRegions);
            this.MinimumSize = new System.Drawing.Size(268, 209);
            this.Name = "RegionPanel";
            this.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Size = new System.Drawing.Size(268, 209);
            this.groupRegions.ResumeLayout(false);
            this.groupRegions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupRegions;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelCurrentRegion;
        private System.Windows.Forms.NumericUpDown numH;
        private System.Windows.Forms.NumericUpDown numW;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.CheckBox checkRelative;
    }
}
