using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter11
{
    public class TestChapter11
    {
        static public void Run()
        {
            //int[] arr = { 3, 5, 4, 1, 2, 6 };
            //int[] res = BubbleSort(arr, arr.Length);
            //PrintArr(res);

            //int[] arr = { 4, 5, 6, 1, 3, 2 };
            //int[] res = InsertionSort(arr, arr.Length);
            //PrintArr(res);

            int[] arr = { 4, 5, 6, 3, 2, 1 };
            int[] res = SelectionSort(arr, arr.Length);
            PrintArr(res);

        }

        //加入了替换检测的冒泡排序        
        static public int[] BubbleSort(int[] arr, int n)
        {
            if (n <= 1)
            {
                return arr;
            }
            for (int i = 0; i < n; i++)
            {
                bool hasSwap = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        hasSwap = true;
                    }
                }
                if (!hasSwap)
                {
                    break;
                }
            }
            return arr;
        }

        //插入排序
        static public int[] InsertionSort(int[] arr, int n)
        {
            if (n <= 1)
            {
                return arr;
            }
            for (int i = 1; i < n; i++)
            {
                int compareVal = arr[i]; //拿来比较的那个数
                int j = i - 1;
                for (j = i - 1; j >= 0; j--)
                {
                    //如果前面的数更大
                    if (arr[j] > compareVal)
                    {
                        arr[j + 1] = arr[j];
                    }
                    else
                    {
                        break;
                    }
                }
                arr[j + 1] = compareVal; //写成a[i] = compareVal是不对的，前面辛辛苦苦挪了位置，此时arr[i]的值可能会变
            }
            return arr;
        }

        //选择排序
        //看上去让人想起插入排序，但插入排序会有数据搬移操作，而选择排序是直接交换位置
        static public int[] SelectionSort(int[] arr, int n)
        {
            if (n <= 1)
            {
                return arr;
            }
            for (int i = 0; i < n - 1; i++) //最后一个数没有求minValIndex的必要了，所以是i<n-1
            {
                int minValIndex = i;
                //因为已有minValIndex = i，所以j从i+1开始
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minValIndex])
                    {
                        minValIndex = j;
                    }
                }
                int temp = arr[i];
                arr[i] = arr[minValIndex];
                arr[minValIndex] = temp;
            }
            return arr;
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
