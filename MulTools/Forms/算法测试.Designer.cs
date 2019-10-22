namespace MulTools.Forms
{
    partial class 算法测试
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
            this.txtIn = new System.Windows.Forms.TextBox();
            this.txtOut = new System.Windows.Forms.TextBox();
            this.btMaxHeap = new System.Windows.Forms.Button();
            this.btQuick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtIn
            // 
            this.txtIn.Location = new System.Drawing.Point(12, 12);
            this.txtIn.Name = "txtIn";
            this.txtIn.Size = new System.Drawing.Size(606, 21);
            this.txtIn.TabIndex = 0;
            this.txtIn.Text = "13,97,65,50,76,49,49,38,49,49,27,1";
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(12, 294);
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(606, 21);
            this.txtOut.TabIndex = 0;
            // 
            // btMaxHeap
            // 
            this.btMaxHeap.Location = new System.Drawing.Point(12, 51);
            this.btMaxHeap.Name = "btMaxHeap";
            this.btMaxHeap.Size = new System.Drawing.Size(75, 23);
            this.btMaxHeap.TabIndex = 1;
            this.btMaxHeap.Text = "大根堆";
            this.btMaxHeap.UseVisualStyleBackColor = true;
            // 
            // btQuick
            // 
            this.btQuick.Location = new System.Drawing.Point(12, 80);
            this.btQuick.Name = "btQuick";
            this.btQuick.Size = new System.Drawing.Size(75, 23);
            this.btQuick.TabIndex = 1;
            this.btQuick.Text = "快速排序";
            this.btQuick.UseVisualStyleBackColor = true;
            // 
            // 算法测试
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 327);
            this.Controls.Add(this.btQuick);
            this.Controls.Add(this.btMaxHeap);
            this.Controls.Add(this.txtOut);
            this.Controls.Add(this.txtIn);
            this.Name = "算法测试";
            this.Text = "算法测试";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIn;
        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.Button btMaxHeap;
        private System.Windows.Forms.Button btQuick;
    }
}