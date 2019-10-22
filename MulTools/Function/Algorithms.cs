using System;
using System.Collections.Generic;
using System.Linq;

namespace MulTools.Function
{
    public static class Algorithms
    {
        #region 排序
        /// <summary>
        /// 大根堆/最大堆
        /// </summary>
        /// <param name="nums">待排序列表</param>
        /// <param name="length">列表长度</param>
        /// <param name="root">当前根</param>
        public static void MaxHeapify(List<int> nums, int length, int root)
        {
            if (root >= length)
            {
                return;
            }

            int largest = root;
            int left = root * 2 + 1;
            int right = root * 2 + 2;

            if (left < length && nums[left] > nums[largest])
            {
                largest = left;
            }

            if (right < length && nums[right] > nums[largest])
            {
                largest = right;
            }

            if (largest != root)
            {
                int t = nums[root];
                nums[root] = nums[largest];
                nums[largest] = t;
                MaxHeapify(nums, length, largest);
            }
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="left">左边界</param>
        /// <param name="right">右边界</param>
        public static void QuickSort(List<int> nums, int left, int right)
        {
            if (left < right)
            {
                int i = left;
                int j = right;
                int middle = nums[(left + right) / 2];
                while (true)
                {
                    while (i < right && nums[i] < middle) { i++; };
                    while (j > 0 && nums[j] > middle) { j--; };
                    if (i == j) break;
                    int temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                    if (nums[i] == nums[j]) j--;
                }
                QuickSort(nums, left, i);
                QuickSort(nums, i + 1, right);
            }
        }

        /// <summary>
        /// 冒泡排序
        /// </summary>
        public static void BubbleSort(List<int> nums)
        {
            bool IsChange;
            for (int i = 0; i < nums.Count; i++)
            {
                IsChange = false;
                for (int j = 0; j < nums.Count - i - 1; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        int t = nums[j + 1];
                        nums[j + 1] = nums[j];
                        nums[j] = t;
                        IsChange = true;
                    }
                }
                if (!IsChange)
                    break;
            }
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        public static void ChoiceSort(List<int> nums)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < nums.Count; j++)
                {
                    if (nums[j] < nums[minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (minIndex > i)
                {
                    int temp = nums[i];
                    nums[i] = nums[minIndex];
                    nums[minIndex] = temp;
                }
            }
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        public static void InsertSort(List<int> nums)
        {
            int preIndex;
            for (int i=0;i<nums.Count;i++)
            {
                preIndex = i - 1;
                int current = nums[i];
                while (preIndex >= 0 && current < nums[preIndex])
                {
                    preIndex -= 1;
                }
                nums.RemoveAt(i);
                nums.Insert(preIndex + 1, current);
            }
        }

        /// <summary>
        /// 归并排序
        /// </summary>
        /// <param name="left">左边界</param>
        /// <param name="right">右边界</param>
        public static void MergeSort(List<int> nums, int left, int right)
        {
            if (left < right)//子表的长度大于1，则进入下面的递归处理
            {
                int mid = (left + right) / 2;   //子表划分的位置
                MergeSort(nums, left, mid);   //对划分出来的左侧子表进行递归划分
                MergeSort(nums, mid + 1, right);    //对划分出来的右侧子表进行递归划分
                MergeSortCore(nums, left, mid, right); //对左右子表进行有序的整合（归并排序的核心部分）
            }
        }

        //归并排序的核心部分：将两个有序的左右子表（以mid区分），合并成一个有序的表
        private static void MergeSortCore(List<int> nums, int left, int mid, int right)
        {
            int indexA = left; //左侧子表的起始位置
            int indexB = mid + 1;   //右侧子表的起始位置
            int[] temp = new int[right + 1]; //声明数组（暂存左右子表的所有有序数列）：长度等于左右子表的长度之和。
            int tempIndex = 0;
            while (indexA <= mid && indexB <= right) //进行左右子表的遍历，如果其中有一个子表遍历完，则跳出循环
            {
                temp[tempIndex++] = nums[indexA] <= nums[indexB] ? nums[indexA++] : nums[indexB++];
            }
            //有一侧子表遍历完后，跳出循环，将另外一侧子表剩下的数一次放入暂存数组中（有序）
            while (indexA <= mid)
            {
                temp[tempIndex++] = nums[indexA++];
            }
            while (indexB <= right)
            {
                temp[tempIndex++] = nums[indexB++];
            }

            //将暂存数组中有序的数列写入目标数组的制定位置，使进行归并的数组段有序
            tempIndex = 0;
            for (int i = left; i <= right; i++)
            {
                nums[i] = temp[tempIndex++];
            }
        }

        /// <summary>
        /// 希尔排序
        /// </summary>
        public static void ShellSort(List<int> nums)
        {
            int length = nums.Count;
            for (int g = length / 2; g > 0; g /= 2)//折半式分组
            {
                for (int i = g; i < length; i++)//保证组里面的长度逐渐加长
                {
                    for (int j = i - g; j >= 0; j -= g)
                    {
                        if (nums[j] > nums[j + g])
                        {
                            int temp = nums[j];
                            nums[j] = nums[g + j];
                            nums[g + j] = temp;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 计数排序
        /// </summary>
        public static void CountSort(List<int> nums)
        {
            int max = nums.Max();
            int min = nums.Min();
            int[] countArr = new int[max - min + 1];
            for (int i = 0; i < nums.Count; i++)
            {
                countArr[nums[i] - min] += 1;
            }
            int index = 0;
            for (int i = 0; i < countArr.Length; i++)
            {
                for (int j = 0; j < countArr[i]; j++)
                {
                    nums[index++] = i + min;
                }
            }
        }

        /// <summary>
        /// 基数排序
        /// </summary>
        public static void RadixSort(List<int> nums)
        {
            int times = nums.Max().ToString().Length;//根据最大数字位数判断需要几次
            List<List<int>> buckets = new List<List<int>>();
            for (int i = 0; i < 10; i++)
                buckets.Add(new List<int>());

            for (int t = 0; t < times; t++)
            {
                int currentBase = Convert.ToInt32(Math.Pow(10, t));
                for (int i = 0; i < nums.Count; i++)//入桶
                {
                    int target = nums[i] / currentBase % 10;
                    buckets[target].Add(nums[i]);
                }
                int index = 0;
                for (int i = 0; i < 10; i++)//出桶
                {
                    foreach (int num in buckets[i])
                        nums[index++] = num;
                    buckets[i].Clear();
                }
            }
        }

        /// <summary>
        /// 桶排序
        /// </summary>
        public static void BucketSort(List<int> nums, int bucketNum)
        {
            if (bucketNum <= 0)
                return;
            int min = nums.Min();
            int max = nums.Max();
            int bucketSize = (max - min) / bucketNum;//无法整除就最后一个桶大一点点
            List<List<int>> buckets = new List<List<int>>();
            for (int i = 0; i < bucketNum; i++)
                buckets.Add(new List<int>());

            for (int i = 0; i < nums.Count; i++)
            {
                int v = nums[i] - min;//当前数的相对值，用来判断应该去几号桶
                int target = v / bucketSize;
                if (v > 0 && v % bucketSize == 0 || target == bucketNum)//包含左侧，不包含右侧[),剩余部分统一扔最后一个桶
                    target -= 1;
                if (buckets[target].Count == 0)//桶没有数据则直接放入
                    buckets[target].Add(nums[i]);
                else
                {
                    if (buckets[target][buckets[target].Count - 1] <= nums[i])//待放入数据大于等于桶中最大的直接末尾添加
                        buckets[target].Add(nums[i]);
                    else
                    {
                        for (int j = 0; j < buckets[target].Count; j++)
                        {
                            if (buckets[target][j] >= nums[i])
                            {
                                buckets[target].Insert(j, nums[i]);
                                break;
                            }
                        }
                    }
                }
            }
            int index = 0;
            foreach (List<int> bucket in buckets)
            {
                for (int i = 0; i < bucket.Count; i++)
                {
                    nums[index++] = bucket[i];
                }
            }
        }
        #endregion
    }
}
