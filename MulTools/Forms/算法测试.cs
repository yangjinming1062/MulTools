using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace MulTools.Forms
{
    public partial class 算法测试 : Form
    {
        public 算法测试()
        {
            InitializeComponent();
        }

        private void btSort_Click(object sender, EventArgs e)
        {
            List<int> numList = txtIn.Tag as List<int>;
            string SortType = ((Button)sender).Text;
            Stopwatch runtime = new Stopwatch();
            runtime.Start();
            switch (SortType)
            {
                case "大根堆":Function.Algorithms.MaxHeapify(numList, numList.Count, 0);break;
                case "桶排序": Function.Algorithms.BucketSort(numList, 5); break;
                case "冒泡排序": Function.Algorithms.BubbleSort(numList); break;
                case "选择排序": Function.Algorithms.ChoiceSort(numList); break;
                case "插入排序": Function.Algorithms.InsertSort(numList); break;
                case "希尔排序": Function.Algorithms.ShellSort(numList); break;
                case "计数排序": Function.Algorithms.CountSort(numList); break;
                case "基数排序": Function.Algorithms.RadixSort(numList); break;
                case "归并排序": Function.Algorithms.MergeSort(numList, 0, numList.Count - 1); break;
                case "快速排序": Function.Algorithms.QuickSort(numList, 0, numList.Count - 1); break;
            }
            runtime.Stop();
            lbTime.Text = "时间：" + runtime.Elapsed.ToString();
            foreach (int num in numList)
            {
                txtOut.Text += num.ToString() + ",";
            }
        }

        private void btRandom_Click(object sender, EventArgs e)
        {
            txtIn.Text = string.Empty;
            Random r = new Random();
            int min = int.Parse(txtMin.Text);
            int max = int.Parse(txtMax.Text);
            int length = int.Parse(txtLength.Text);
            List<int> l = new List<int>();
            for (int i = 0; i < length; i++)
            {
                int temp = r.Next(min, max);
                l.Add(temp);
                txtIn.Text += temp.ToString() + ",";
            }
            txtIn.Tag = l;
        }

        private void 算法测试_Load(object sender, EventArgs e)
        {
            string[] inList = txtIn.Text.Split(',');
            txtOut.Text = string.Empty;
            List<int> numList = new List<int>();
            foreach (string s in inList)
            {
                numList.Add(int.Parse(s));
            }
            txtIn.Tag = numList;
        }
    }
}
