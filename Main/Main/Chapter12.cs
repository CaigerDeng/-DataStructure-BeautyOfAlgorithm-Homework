using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter12
{
    public class TestChapter12
    {
        static public void Run()
        {
            //int[] arr = { 3, 2, 9, 1 };
            //int[] a = { 2, 3 };
            //int[] b = { 1, 9 };
            //PrintArr(Merge(arr, a, b));

            //int[] arr = { 11, 8, 3, 9, 7, 1, 2, 5 };
            //MergeSort(arr, arr.Length);
            //PrintArr(arr);

            int[] arr = { 11, 8, 3, 9, 7, 1, 2, 5 };
            QuickSort(arr, arr.Length);
            PrintArr(arr);

            //Console.WriteLine(">>>>>>>>>>>>>FindMaxK");
            //int[] yoyo = { 11, 8, 3, 9, 7, 1, 2, 5 };
            //Console.WriteLine("res:{0}", FindMaxK(yoyo, 3));

        }

        //归并排序
        static public void MergeSort(int[] arr, int n)
        {
            if (n <= 1)
            {
                return;
            }
            MergeSortDetail(arr, 0, n - 1);
        }

        static public void MergeSortDetail(int[] arr, int left, int right)
        {
            if (left >= right)
            {
                return;
            }
            int mid = (left + right) / 2;
            MergeSortDetail(arr, left, mid);
            MergeSortDetail(arr, mid + 1, right);
            Merge(arr, left, mid, right);
            //MergeWithGuard(arr, left, mid, right);
        }

        static public void Merge(int[] arr, int left, int mid, int right)
        {
            int len = right - left + 1;
            int[] res = new int[len]; //不能写 = new int[arr.Length]，这样是不对的，因为(right - left + 1)<= arr.Length
            int aIndex = left;
            int bIndex = mid + 1;
            int i = 0;
            while (aIndex <= mid && bIndex <= right) //总会有一个index走到尽头
            {
                if (arr[aIndex] <= arr[bIndex])
                {
                    res[i++] = arr[aIndex++];
                }
                else
                {
                    res[i++] = arr[bIndex++];
                }
            }
            int beginIndex = aIndex;
            int endIndex = mid;
            if (bIndex <= right)
            {
                beginIndex = bIndex;
                endIndex = right;
            }
            for (int j = beginIndex; j <= endIndex; j++, i++)
            {
                res[i] = arr[j];
            }
            //数组不能直接赋值
            for (int j = 0; j < len; j++)
            {
                arr[left + j] = res[j]; // keypoint:left + j
            }

        }

        //有哨兵的合并
        //使用bool判断
        static public void MergeWithGuard(int[] arr, int left, int mid, int right)
        {
            int len = right - left + 1;
            int[] res = new int[len]; //不能写 = new int[arr.Length]，这样是不对的，因为(right - left + 1)<= arr.Length
            int aIndex = left;
            int bIndex = mid + 1;
            int i = 0;
            bool aPass = false;
            bool bPass = false;
            while (aIndex <= mid || bIndex <= right) //让两个index都走到尽头
            {
                if (aPass)
                {
                    res[i++] = arr[bIndex++];
                    continue;
                }
                if (bPass)
                {
                    res[i++] = arr[aIndex++];
                    continue;
                }
                if (arr[aIndex] <= arr[bIndex])
                {
                    res[i++] = arr[aIndex++];
                }
                else
                {
                    res[i++] = arr[bIndex++];
                }
                if (aIndex > mid)
                {
                    aPass = true;
                }
                if (bIndex > right)
                {
                    bPass = true;
                }

            }
            //数组不能直接赋值
            for (int j = 0; j < len; j++)
            {
                arr[left + j] = res[j]; // keypoint:left + j
            }

        }

        //快速排序
        static public void QuickSort(int[] arr, int n)
        {
            if (n <= 1)
            {
                return;
            }
            QuickSortDetail(arr, 0, n - 1);
        }

        static public void QuickSortDetail(int[] arr, int left, int right)
        {
            if (left >= right)
            {
                return;
            }
            int p = partition(arr, left, right);
            QuickSortDetail(arr, left, p - 1);
            QuickSortDetail(arr, p + 1, right);
        }

        static public int partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left;
            int tmp;
            for (int j = left; j < right; j++) 
            {
                if (arr[j] < pivot)
                {
                    if (i != j)
                    {
                        tmp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tmp;
                    }
                    i++;
                }
            }
            tmp = arr[i];
            arr[i] = pivot;
            arr[right] = tmp;
            return i;
        }

        //找第K大元素
        //根据题意需要从大到小排序
        //以下标pivot为区分点，分为arr[0,pivot-1],arr[pivot],arr[pivot+1,n-1]三组，比arr[pivot]大的放前面，否则放后面
        //如果pivot+1=N，计算完毕；如果pivot+1<K，则从后面那组找，反之从前面那组找
        static public int FindMaxK(int[] arr, int K)
        {
            int res;
            int pivot = FindMaxKDetail(arr, 0, arr.Length - 1);
            while (pivot + 1 != K)
            {
                if (pivot + 1 < K)
                {
                    pivot = FindMaxKDetail(arr, pivot + 1, arr.Length - 1);
                }
                else
                {
                    pivot = FindMaxKDetail(arr, 0, pivot - 1);
                }
            }
            res = arr[pivot];
            return res;
        }

        static public int FindMaxKDetail(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left;
            int temp;
            for (int j = left; j < right; j++)
            {
                if (arr[j] > pivot)
                {
                    if (i != j)
                    {
                        temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                    i++;
                }
            }
            temp = arr[right];
            arr[right] = arr[i];
            arr[i] = temp;
            return i;
        }

        static public void PrintArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

    }




}
