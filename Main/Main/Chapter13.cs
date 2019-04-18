using System;
using System.Collections.Generic;
using System.Text;
using Chapter12;

//以下桶排序，计数排序，基数排序都是针对具体例子写的算法

namespace Chapter13
{
    class TestChapter13
    {
        static public void Run()
        {
            //BucketSortExample();
            //CountingSortExample();

            //RadixSortExample();

            //Inner
            int[] arr = { 3221, 1, 10, 9680, 577, 9420, 7, 5622, 4793, 2030, 3138, 82, 2599, 743, 4127 };
            Array.Sort(arr);
            PrintArr(arr);

            
        }

        static public void BucketSortExample()
        {
            //对这组金额在0-50之间的订单进行桶排序
            int[] arr = { 22, 5, 11, 41, 45, 26, 29, 10, 7, 8, 30, 27, 42, 43, 40 };
            //设置5个桶，0-9，10-19，20-29，30-30，40-49，一个桶的容量为arr.Length
            int[,] buckets = new int[5, arr.Length];
            int[] lengthOfBuckets = new int[5];
            for (int i = 0; i < arr.Length; i++)
            {
                int index = arr[i] / 10;
                buckets[index, lengthOfBuckets[index]] = arr[i];
                lengthOfBuckets[index]++;
            }
            int[] temp = new int[arr.Length];
            //针对桶内元素进行快速排序
            int startIndexOfArr = 0;
            for (int i = 0; i < buckets.GetLength(0); i++)
            {
                int len = lengthOfBuckets[i];
                if (len == 0)
                {
                    //跳过空桶
                    continue;
                }
                for (int j = 0; j < len; j++)
                {
                    temp[j] = buckets[i, j];
                }
                TestChapter12.QuickSort(temp, len);
                for (int j = 0; j < len; j++)
                {
                    arr[startIndexOfArr + j] = temp[j];
                }
                startIndexOfArr += len;
            }

            PrintArr(arr);
        }

        static public void CountingSortExample()
        {
            //假设有8个考生，分数在0-5之间，如下，对这组考生成绩进行排序
            int[] arr = { 2, 5, 3, 0, 2, 3, 0, 3 };
            int max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                }
            }
            int[] c = new int[max + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                c[arr[i]]++;
            }
            //依次累加
            for (int i = 1; i < c.Length; i++)
            {
                c[i] += c[i - 1];
            }
            int[] res = new int[arr.Length];
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int index = c[arr[i]] - 1;
                res[index] = arr[i];
                c[arr[i]]--;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = res[i];
            }
            PrintArr(arr);
        }

        static public void RadixSortExample()
        {
            //示例来自 https://visualgo.net/en/sorting
            //对下面这组数据进行基数排序
            int[] arr = { 3221, 1, 10, 9680, 577, 9420, 7, 5622, 4793, 2030, 3138, 82, 2599, 743, 4127 };
            //创建索引为0-9的10个桶,0-9意思是数值范围
            int[,] buckets = new int[10, arr.Length];
            int[] lengthOfBuckets = new int[10];
            int[] tempNums = new int[4]; //临时存放各个位上的数
            for (int i = 0; i < 4; i++) //数字最多为4位数
            {
                //放到合适的桶
                for (int j = 0; j < arr.Length; j++)
                {
                    tempNums[0] = arr[j] / 1000;
                    tempNums[1] = (arr[j] - tempNums[0] * 1000) / 100;
                    tempNums[2] = (arr[j] - tempNums[0] * 1000 - tempNums[1] * 100) / 10;
                    tempNums[3] = arr[j] % 10;
                    int index = tempNums[tempNums.Length - i - 1];
                    buckets[index, lengthOfBuckets[index]] = arr[j];
                    lengthOfBuckets[index]++;
                }
                //用桶中数据重新给arr赋值
                int startIndex = 0;
                for (int j = 0; j < 10; j++)
                {
                    int len = lengthOfBuckets[j];
                    if (len == 0)
                    {
                        //跳过空桶
                        continue;
                    }
                    for (int k = 0; k < len; k++)
                    {
                        arr[startIndex + k] = buckets[j, k];
                    }
                    startIndex += len;
                    lengthOfBuckets[j] = 0; //重置为0
                }
            }
            PrintArr(arr);

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
