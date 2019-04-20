//Chapter 15 + 16

using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter15
{
    class TestChapter15
    {
        static public void Run()
        {
            //int[] arr = { 1, 5, 7, 10, 22, 40 };
            //Console.WriteLine("find index:{0}", BSearch(arr, arr.Length, 22));

            //Console.WriteLine("find index:{0}", BSearch_1(arr, arr.Length, 22));

            //求中点值的错误写法
            //int mid = 1 + (5 - 1) >> 1; //左移运算符比 加减号 还低，应该是1 + ((5 - 1) >> 1)
            //Console.WriteLine("mid:{0}", mid);

            //int[] arr = { 4, 5, 6, 0, 1, 2, 3 };
            //int[] arr = { 6, 0, 1, 2, 3, 4, 5 };
            int[] arr = { 0, 1, 2, 3, 4, 5, 6 };
            Console.WriteLine("Find index :{0}", BSearchForLoopArr(arr, arr.Length, 5));

        }

        //
        public static int BSearch(int[] arr, int n, int val)
        {
            int low = 0;
            int high = n - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] == val)
                {
                    return mid;
                }
                else if (arr[mid] < val)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }

        //使用递归实现
        public static int BSearch_1(int[] arr, int n, int val)
        {
            return BSearch_1_Detail(arr, 0, n - 1, val);
        }

        public static int BSearch_1_Detail(int[] arr, int low, int high, int val)
        {
            if (low > high)
            {
                return -1;
            }
            int mid = low + (high - low) / 2;
            if (arr[mid] == val)
            {
                return mid;
            }
            else if (arr[mid] < val)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
            return BSearch_1_Detail(arr, low, high, val);
        }

        static public void PrintArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        static public double FindSqrt(double val, double precision)
        {
            double mid = 0;
            if (val < 0)
            {
                return Double.NaN;
            }
            double low = 0;
            double high = val;
            if (val < 1 && val > 0)
            {
                //进一步限制范围
                low = val;
                high = 1;
            }
            while (high - low > precision)
            {
                mid = low + (high - low) / 2;
                if (mid * mid > val)
                {
                    high = mid;
                }
                else if (mid * mid < val)
                {
                    low = mid;
                }
                else
                {
                    break;
                }
            }
            mid = Math.Round(mid, 6);
            return mid;
        }

        #region 二分法变形
        //查找第一个符合给定值的元素
        static public int BSearch_FirstFit(int[] arr, int n, int val)
        {
            int low = 0;
            int high = n - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] < val)
                {
                    low = mid + 1; //往后面找
                }
                else if (arr[mid] > val)
                {
                    high = mid - 1;//往前面找
                }
                if (arr[mid] == val)
                {
                    if (mid == 0 || arr[mid - 1] != val)
                    {
                        return mid;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
            }
            return -1;
        }

        //查找最后一个符合给定值的元素
        static public int BSearch_LastFit(int[] arr, int n, int val)
        {
            int low = 0;
            int high = n - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] < val)
                {
                    low = mid + 1; //往后面找
                }
                else if (arr[mid] > val)
                {
                    high = mid - 1;//往前面找
                }
                if (arr[mid] == val)
                {
                    if (mid == n - 1 || arr[mid + 1] != val)
                    {
                        return mid;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
            }
            return -1;
        }

        //查找第一个大于等于给定值的元素
        static public int BSearch_FirstFit_GE(int[] arr, int n, int val)
        {
            int low = 0;
            int high = n - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] < val)
                {
                    low = mid + 1; //往后面找
                }
                else
                {
                    if (mid == 0 || arr[mid - 1] < arr[mid])
                    {
                        return mid;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }

            }
            return -1;
        }

        //查找最后一个小于等于给定值的元素
        static public int BSearch_FirstFit_LE(int[] arr, int n, int val)
        {
            int low = 0;
            int high = n - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] <= val)
                {
                    if (mid == n - 1 || arr[mid + 1] > arr[mid])
                    {
                        return mid;
                    }
                    else
                    {
                        low = mid + 1; //往后面找
                    }
                }
                else
                {
                    high = mid - 1;
                }

            }
            return -1;
        }


        //针对循环数组的二分法变形
        static public int BSearchForLoopArr(int[] arr, int n, int val)
        {


            //用minValueIndex做标记这个并不合适，因为遍历(<n)求这个minValueIndex，同时也能找到val了...
            return BSearchForLoopArrDetail(arr, 0, n - 1, val);
        }

        static public int BSearchForLoopArrDetail(int[] arr, int low, int high, int val)
        {
            int mid = low + (high - low) / 2;
            if (arr[low] <= arr[mid] && arr[mid] <= arr[high])
            {
                //已经是从小到大排好序的数组
                return BSearch(arr, arr.Length, val);
            }
            if (arr[mid] == val)
            {
                return mid;
            }
            if (arr[low] == val)
            {
                return low;
            }
            if (arr[high] == val)
            {
                return high;
            }
            if (low == high)
            {
                return -1;
            }
            if (arr[low] > arr[mid]) //mid后面是有序数组
            {
                if (val > arr[mid] && val < arr[high]) //如果在有序数组中
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            else //mid前面是有序数组
            {
                if (val < arr[mid] && val > arr[low]) //如果在有序数组中
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid - 1;
                }
            }
            return BSearchForLoopArrDetail(arr, low, high, val);

        }

        #endregion

    }


}
