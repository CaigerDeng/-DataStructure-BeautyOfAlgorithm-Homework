using System;
using System.Collections.Generic;
using System.Text;

//如何借助树来求解递归算法的时间复杂度
namespace Chapter27
{
    class TestChapter27
    {
        static public void Run()
        {
            //假设数组中存储的是 1，2， 3...n。
            //f(1, 2,...n) = { 最后一位是 1, f(n - 1)} + { 最后一位是 2, f(n - 1)}+...+{ 最后一位是 n, f(n - 1)}。最后一位有n种可能
            // = {最后一位1，最后二位2，f(n-2)}+{最后一位1，最后二位3，f(n-2)}+...+{最后一位n，最后二位n-1，f(n-2)}。最后一位有n种可能，最后二位有n-1种可能


            //int[] a = { 1, 2, 3, 4 };
            //printPermutations(a, 4, 4);
            int[] a = { 1, 2, 3 };
            printPermutations(a, 3, 3);

        }

        //求全排列
        // k 表示要处理的子数组的数据个数（或许还可以理解成还剩几个空位）
        static public void printPermutations(int[] data, int n, int k)
        {
            if (k == 1)
            {
                for (int i = 0; i < n; ++i)
                {
                    Console.Write(data[i] + " ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < k; ++i)
            {
                int tmp = data[i];
                data[i] = data[k - 1];
                data[k - 1] = tmp;

                printPermutations(data, n, k - 1);

                tmp = data[i];
                data[i] = data[k - 1];
                data[k - 1] = tmp;
            }
        }


    }


}
