//Chapter28 + 29

using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter28
{
    class TestChapter28
    {
        static public void Run()
        {
            //int[] arr = { 33, 27, 21, 16, 13, 15, 19, 5, 6, 7, 8, 1, 2, 12 };
            //Heap h = new Heap(30);
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    h.Insert(arr[i]);
            //}
            //h.PrintAll();

            //h.RemoveMax();
            //h.PrintAll();

            int[] arr = { 9, 6, 3, 1, 5 };
            HeapSort2(arr, arr.Length);

        }

        public static void PrintAll(int[] a)
        {
            for (int i = 1; i <= a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }

        //堆排序（建堆：堆化自下而上）
        static public void HeapSort1(int[] arr, int n)
        {
            Heap h = new Heap(n);
            for (int i = 0; i < n; i++)
            {
                h.Insert(arr[i]);
            }
            //sort
            int k = n;
            while (k > 1)
            {
                h.Swap(1, k);
                k--;
                h.HeapifyFromTop(k, 1);
            }
            h.PrintAll();
        }

        //堆排序（建堆：堆化自上而下）
        static public void HeapSort2(int[] arr, int n)
        {
            Heap h = new Heap(n);
            h.ResetData(arr);
            for (int i = n / 2; i >= 1; i--)
            {
                h.HeapifyFromTop(n, i);
            }
            //sort
            int k = n;
            while (k > 1)
            {
                h.Swap(1, k);
                k--;
                h.HeapifyFromTop(k, 1);
            }
            h.PrintAll();
        }



    }

    //数组存储的（大顶）堆
    public class Heap
    {
        private int[] data;
        private int capacity;
        private int count;

        public Heap(int capacity)
        {
            data = new int[capacity + 1];  //索引0不存东西
            this.capacity = capacity;
            count = 0;
        }

        //堆化 自上而下
        public void HeapifyFromTop(int n, int i)
        {
            //因为要保持堆顶元素是最大，所以需要判断子节点谁最大
            while (true)
            {
                int maxPos = i;
                if (2 * i <= n && data[i] < data[2 * i])
                {
                    maxPos = 2 * i;
                }
                else if (2 * i + 1 <= n && data[i] < data[2 * i + 1])
                {
                    maxPos = 2 * i + 1;
                }
                else
                {
                    break;
                }
                Swap(i, maxPos);
                i = maxPos;
            }

        }

        //交换索引为aIndex，bIndex的值
        public void Swap(int aIndex, int bIndex)
        {
            int temp = data[aIndex];
            data[aIndex] = data[bIndex];
            data[bIndex] = temp;
        }


        public void Insert(int val)
        {
            if (count == capacity)
            {
                return;
            }
            //插入
            count++;
            data[count] = val;
            //堆化 自下而上
            int i = count;
            while (i / 2 > 0 && data[i] > data[i / 2]) //跳过索引0
            {
                Swap(i, i / 2);
                i = i / 2;
            }
        }

        //删除堆顶
        public void RemoveMax()
        {
            if (count == 0)
            {
                return;
            }
            data[1] = data[count];
            count--;
            HeapifyFromTop(count, 1);
        }

        public void PrintAll()
        {
            for (int i = 1; i <= count; i++)
            {
                Console.Write(data[i] + " ");
            }
            Console.WriteLine();
        }

        public void ResetData(int[] a)
        {
            data = new int[capacity + 1];  //索引0不存东西
            for (int i = 0; i < a.Length; i++)
            {
                data[i + 1] = a[i];
            }
            count = a.Length;
        }

    }


}
