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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIn = new System.Windows.Forms.TextBox();
            this.btMaoPao = new System.Windows.Forms.Button();
            this.btXuanZe = new System.Windows.Forms.Button();
            this.btChaRu = new System.Windows.Forms.Button();
            this.btGuiBing = new System.Windows.Forms.Button();
            this.btQuaiPai = new System.Windows.Forms.Button();
            this.btXiEr = new System.Windows.Forms.Button();
            this.btDaGenDui = new System.Windows.Forms.Button();
            this.btTong = new System.Windows.Forms.Button();
            this.btJiShu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btJi1Shu = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.btRandom = new System.Windows.Forms.Button();
            this.txtOut = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbTime);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btJi1Shu);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btJiShu);
            this.groupBox1.Controls.Add(this.btTong);
            this.groupBox1.Controls.Add(this.btDaGenDui);
            this.groupBox1.Controls.Add(this.btXiEr);
            this.groupBox1.Controls.Add(this.btGuiBing);
            this.groupBox1.Controls.Add(this.btQuaiPai);
            this.groupBox1.Controls.Add(this.btChaRu);
            this.groupBox1.Controls.Add(this.btXuanZe);
            this.groupBox1.Controls.Add(this.btMaoPao);
            this.groupBox1.Controls.Add(this.txtIn);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(601, 369);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "排序算法";
            // 
            // txtIn
            // 
            this.txtIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtIn.Location = new System.Drawing.Point(3, 17);
            this.txtIn.Name = "txtIn";
            this.txtIn.Size = new System.Drawing.Size(595, 21);
            this.txtIn.TabIndex = 1;
            this.txtIn.Text = "13,97,65,50,76,49,49,38,49,49,27,1";
            // 
            // btMaoPao
            // 
            this.btMaoPao.Location = new System.Drawing.Point(9, 68);
            this.btMaoPao.Name = "btMaoPao";
            this.btMaoPao.Size = new System.Drawing.Size(75, 23);
            this.btMaoPao.TabIndex = 3;
            this.btMaoPao.Text = "冒泡排序";
            this.btMaoPao.UseVisualStyleBackColor = true;
            this.btMaoPao.Click += new System.EventHandler(this.btSort_Click);
            // 
            // btXuanZe
            // 
            this.btXuanZe.Location = new System.Drawing.Point(9, 97);
            this.btXuanZe.Name = "btXuanZe";
            this.btXuanZe.Size = new System.Drawing.Size(75, 23);
            this.btXuanZe.TabIndex = 4;
            this.btXuanZe.Text = "选择排序";
            this.btXuanZe.UseVisualStyleBackColor = true;
            this.btXuanZe.Click += new System.EventHandler(this.btSort_Click);
            // 
            // btChaRu
            // 
            this.btChaRu.Location = new System.Drawing.Point(9, 126);
            this.btChaRu.Name = "btChaRu";
            this.btChaRu.Size = new System.Drawing.Size(75, 23);
            this.btChaRu.TabIndex = 5;
            this.btChaRu.Text = "插入排序";
            this.btChaRu.UseVisualStyleBackColor = true;
            this.btChaRu.Click += new System.EventHandler(this.btSort_Click);
            // 
            // btGuiBing
            // 
            this.btGuiBing.Location = new System.Drawing.Point(9, 184);
            this.btGuiBing.Name = "btGuiBing";
            this.btGuiBing.Size = new System.Drawing.Size(75, 23);
            this.btGuiBing.TabIndex = 6;
            this.btGuiBing.Text = "归并排序";
            this.btGuiBing.UseVisualStyleBackColor = true;
            this.btGuiBing.Click += new System.EventHandler(this.btSort_Click);
            // 
            // btQuaiPai
            // 
            this.btQuaiPai.Location = new System.Drawing.Point(9, 213);
            this.btQuaiPai.Name = "btQuaiPai";
            this.btQuaiPai.Size = new System.Drawing.Size(75, 23);
            this.btQuaiPai.TabIndex = 7;
            this.btQuaiPai.Text = "快速排序";
            this.btQuaiPai.UseVisualStyleBackColor = true;
            this.btQuaiPai.Click += new System.EventHandler(this.btSort_Click);
            // 
            // btXiEr
            // 
            this.btXiEr.Location = new System.Drawing.Point(9, 155);
            this.btXiEr.Name = "btXiEr";
            this.btXiEr.Size = new System.Drawing.Size(75, 23);
            this.btXiEr.TabIndex = 8;
            this.btXiEr.Text = "希尔排序";
            this.btXiEr.UseVisualStyleBackColor = true;
            this.btXiEr.Click += new System.EventHandler(this.btSort_Click);
            // 
            // btDaGenDui
            // 
            this.btDaGenDui.Location = new System.Drawing.Point(9, 242);
            this.btDaGenDui.Name = "btDaGenDui";
            this.btDaGenDui.Size = new System.Drawing.Size(75, 23);
            this.btDaGenDui.TabIndex = 9;
            this.btDaGenDui.Text = "大根堆";
            this.btDaGenDui.UseVisualStyleBackColor = true;
            this.btDaGenDui.Click += new System.EventHandler(this.btSort_Click);
            // 
            // btTong
            // 
            this.btTong.Location = new System.Drawing.Point(9, 271);
            this.btTong.Name = "btTong";
            this.btTong.Size = new System.Drawing.Size(75, 23);
            this.btTong.TabIndex = 3;
            this.btTong.Text = "桶排序";
            this.btTong.UseVisualStyleBackColor = true;
            this.btTong.Click += new System.EventHandler(this.btSort_Click);
            // 
            // btJiShu
            // 
            this.btJiShu.Location = new System.Drawing.Point(9, 300);
            this.btJiShu.Name = "btJiShu";
            this.btJiShu.Size = new System.Drawing.Size(75, 23);
            this.btJiShu.TabIndex = 10;
            this.btJiShu.Text = "计数排序";
            this.btJiShu.UseVisualStyleBackColor = true;
            this.btJiShu.Click += new System.EventHandler(this.btSort_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "时O(n^2)|空O(1)|稳";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "时O(n^2)|空O(1)|否";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "时O(n^2)|空O(1)|稳";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "时O(nlog n)|空O(1)|否";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "时O(nlog n)|空O(n)|稳";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "时O(n^(1.3—2))|空O(1)|否";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(99, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "时O(nlog n)|空O(1)|否";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(99, 276);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "时O(n+k)|空O(n+k)|稳";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(99, 305);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "时O(n+k)|空O(k)|稳";
            // 
            // btJi1Shu
            // 
            this.btJi1Shu.Location = new System.Drawing.Point(9, 329);
            this.btJi1Shu.Name = "btJi1Shu";
            this.btJi1Shu.Size = new System.Drawing.Size(75, 23);
            this.btJi1Shu.TabIndex = 10;
            this.btJi1Shu.Text = "基数排序";
            this.btJi1Shu.UseVisualStyleBackColor = true;
            this.btJi1Shu.Click += new System.EventHandler(this.btSort_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(99, 334);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "时O(n*k)|空O(n+k)|稳";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.BackColor = System.Drawing.Color.Chartreuse;
            this.lbTime.Font = new System.Drawing.Font("宋体", 12F);
            this.lbTime.Location = new System.Drawing.Point(6, 41);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(89, 20);
            this.lbTime.TabIndex = 12;
            this.lbTime.Text = "运行时间";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btRandom);
            this.panel1.Controls.Add(this.txtLength);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtMax);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtMin);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 40);
            this.panel1.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "最小值：";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(68, 6);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(79, 21);
            this.txtMin.TabIndex = 1;
            this.txtMin.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(156, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "最大值：";
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(212, 6);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(78, 21);
            this.txtMax.TabIndex = 1;
            this.txtMax.Text = "100";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(300, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "长度：";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(343, 6);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(100, 21);
            this.txtLength.TabIndex = 1;
            this.txtLength.Text = "50";
            // 
            // btRandom
            // 
            this.btRandom.Location = new System.Drawing.Point(463, 6);
            this.btRandom.Name = "btRandom";
            this.btRandom.Size = new System.Drawing.Size(97, 23);
            this.btRandom.TabIndex = 2;
            this.btRandom.Text = "生成随机数组";
            this.btRandom.UseVisualStyleBackColor = true;
            this.btRandom.Click += new System.EventHandler(this.btRandom_Click);
            // 
            // txtOut
            // 
            this.txtOut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtOut.Location = new System.Drawing.Point(0, 409);
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(601, 21);
            this.txtOut.TabIndex = 4;
            // 
            // 算法测试
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 430);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtOut);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "算法测试";
            this.Text = "算法测试";
            this.Load += new System.EventHandler(this.算法测试_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIn;
        private System.Windows.Forms.Button btGuiBing;
        private System.Windows.Forms.Button btQuaiPai;
        private System.Windows.Forms.Button btChaRu;
        private System.Windows.Forms.Button btXuanZe;
        private System.Windows.Forms.Button btMaoPao;
        private System.Windows.Forms.Button btJiShu;
        private System.Windows.Forms.Button btTong;
        private System.Windows.Forms.Button btDaGenDui;
        private System.Windows.Forms.Button btXiEr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btJi1Shu;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btRandom;
        private System.Windows.Forms.TextBox txtOut;
    }
}