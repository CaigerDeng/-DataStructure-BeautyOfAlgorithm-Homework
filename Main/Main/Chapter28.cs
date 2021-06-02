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

            // 测小顶堆：leetcode 703. 数据流中的第 K 大元素
            // https://leetcode-cn.com/problems/kth-largest-element-in-a-stream/



            // 测大顶堆：剑指 Offer 40. 最小的k个数
            // https://leetcode-cn.com/problems/zui-xiao-de-kge-shu-lcof/

        }

    }

    /// <summary>
    /// 小顶堆
    /// </summary>
    public class MinHeap
    {
        private int[] data;
        public int capacity;
        public int count;

        public MinHeap(int capacity)
        {
            this.capacity = capacity;
            // 索引0不放数据，从索引1开始放，这样方便堆化时算其他索引，比如：求索引2和3的父索引，直接整除2得到1
            data = new int[capacity + 1];
            count = 0;

        }

        /// <summary>
        /// 能一直加，大小不会变
        /// </summary>
        /// <param name="val"></param>
        public void Push(int val)
        {
            if (count < capacity)
            {
                count++;
                data[count] = val;
                Up(count);
            }
            // val比top大才会加入
            else if (val > data[1])
            {
                data[1] = val;
                Down(1);
            }

        }

        public int Pop()
        {
            if (count == 0)
            {
                throw new IndexOutOfRangeException("IndexOutOfRangeException");
            }
            int top = GetTop();
            data[1] = data[count];
            count--;
            Down(1);
            return top;

        }


        /// <summary>
        /// 上浮
        /// </summary>
        /// <param name="index"></param>
        public void Up(int index)
        {
            // 因为索引0不放数据，所以其他索引直接整除2即可（如果索引0放数据，求索引2的父索引还要减法这些）
            while (index / 2 > 0 && data[index] < data[index / 2])
            {
                Swap(index, index / 2);
                index = index / 2;
            }

        }

        /// <summary>
        /// 交换索引为aIndex，bIndex的值
        /// </summary>
        /// <param name="aIndex"></param>
        /// <param name="bIndex"></param>
        private void Swap(int aIndex, int bIndex)
        {
            int temp = data[aIndex];
            data[aIndex] = data[bIndex];
            data[bIndex] = temp;

        }

        /// <summary>
        /// 下沉
        /// </summary>
        /// <param name="index"></param>
        private void Down(int index)
        {
            int minPos = index;
            int leftChildIndex = 2 * index;
            int rightChildIndex = 2 * index + 1;
            if (leftChildIndex <= count && data[minPos] > data[leftChildIndex])
            {
                minPos = leftChildIndex;
            }
            if (rightChildIndex <= count && data[minPos] > data[rightChildIndex])
            {
                minPos = rightChildIndex;
            }
            if (minPos != index)
            {
                Swap(index, minPos);
                Down(minPos);
            }

        }

        public int GetTop()
        {
            return data[1];

        }

    }

    /// <summary>
    /// 大顶堆
    /// </summary>
    public class MaxHeap
    {
        private int[] data;
        public int capacity;
        public int count;

        public MaxHeap(int capacity)
        {
            this.capacity = capacity;
            // 索引0不放数据，从索引1开始放，这样方便堆化时算其他索引，比如：求索引2和3的父索引，直接整除2得到1
            data = new int[capacity + 1];
            count = 0;

        }

        public void Push(int val)
        {
            if (count < capacity)
            {
                count++;
                data[count] = val;
                Up(count);
            }
            else if (val < data[1])
            {
                data[1] = val;
                Down(1);
            }

        }

        public int Pop()
        {
            if (count == 0)
            {
                throw new IndexOutOfRangeException("IndexOutOfRangeException");
            }
            int top = GetTop();
            data[1] = data[count];
            count--;
            Down(1);
            return top;

        }


        /// <summary>
        /// 上浮
        /// </summary>
        /// <param name="index"></param>
        public void Up(int index)
        {
            // 因为索引0不放数据，所以其他索引直接整除2即可（如果索引0放数据，求索引2的父索引还要减法这些）
            while (index / 2 > 0 && data[index] > data[index / 2])
            {
                Swap(index, index / 2);
                index = index / 2;
            }

        }

        /// <summary>
        /// 交换索引为aIndex，bIndex的值
        /// </summary>
        /// <param name="aIndex"></param>
        /// <param name="bIndex"></param>
        private void Swap(int aIndex, int bIndex)
        {
            int temp = data[aIndex];
            data[aIndex] = data[bIndex];
            data[bIndex] = temp;

        }

        /// <summary>
        /// 下沉
        /// </summary>
        /// <param name="index"></param>
        private void Down(int index)
        {
            int maxPos = index;
            int leftChildIndex = 2 * index;
            int rightChildIndex = 2 * index + 1;
            if (leftChildIndex <= count && data[maxPos] < data[leftChildIndex])
            {
                maxPos = leftChildIndex;
            }
            if (rightChildIndex <= count && data[maxPos] < data[rightChildIndex])
            {
                maxPos = rightChildIndex;
            }
            if (maxPos != index)
            {
                Swap(index, maxPos);
                Down(maxPos);
            }

        }

        public int GetTop()
        {
            return data[1];

        }

    }


}
