using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulTools.Function
{
    public static class Algorithms
    {
        public static void maxHeapify(int[] arr, int length, int root)
        {
            if (root >= length)
            {
                return;
            }

            int largest = root;
            int left = root * 2 + 1;
            int right = root * 2 + 2;

            if (left < length && arr[left] > arr[largest])
            {
                largest = left;
            }

            if (right < length && arr[right] > arr[largest])
            {
                largest = right;
            }

            if (largest != root)
            {
                int t = arr[root];
                arr[root] = arr[largest];
                arr[largest] = t;

                maxHeapify(arr, length, largest);
            }
        }

        public static void QuickSort(ref List<int> nums, int left, int right)
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
                QuickSort(ref nums, left, i);
                QuickSort(ref nums, i + 1, right);
            }
        }
    }
}
