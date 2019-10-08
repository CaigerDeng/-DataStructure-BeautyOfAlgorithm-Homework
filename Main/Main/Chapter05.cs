using System;
using System.Collections.Generic;
using System.Text;
using Chapter15;
using Chapter12;

namespace Chapter05
{
    public class TestChapter05
    {
        static public void Run()
        {
            //Array<int> tt = new Array<int>(4);
            //LRU(tt, 1, 4);
            //LRU(tt, 2, 4);
            //LRU(tt, 3, 4);
            //LRU(tt, 4, 4);
            //tt.PrintAll();

            //LRU(tt, 2, 4);
            //tt.PrintAll();

            //LRU(tt, 3, 4);
            //tt.PrintAll();

            //LRU(tt, 3, 4);
            //tt.PrintAll();

            //Pra.p2Array tt = new Pra.p2Array(6);
            //tt.Add(1);
            //tt.Add(5);
            //tt.Add(3);
            //tt.PrintAll(); // 1 3 5

            //tt.Add(0);
            //tt.Remove(5);
            //tt.PrintAll(); // 0 1 3

            //tt.Set(0, 99);
            //tt.PrintAll(); //1 3 99

            int[] a = { 1, 2, 4 };
            int[] b = { 6,33, 90 };
            int[] res = Pra.MergeTwo(a, b);

            for (int i = 0; i < res.Length; i++)
            {
                Console.Write(res[i] + " ");
            }
            Console.WriteLine();

        }

        static public void LRU(Array<int> arr, int val, int capacity)
        {
            if (arr.Length > 0 && arr.GetItem(0) == val)
            {
                Console.WriteLine("Return same val.");
                return;
            }
            var temp = arr.Remove(val);
            if (temp == false)
            {
                if (arr.Length >= capacity)
                {
                    arr.RemoveAt(arr.Length);
                }
            }
            arr.Insert(0, val);

        }

    }

    public sealed class Array<T> where T : IComparable<T>
    {
        private T[] _data;
        private int _capacity;
        private int _length;
        public int Length => _length;


        public Array(int capacity)
        {
            _length = 0;
            _capacity = capacity;
            _data = new T[_capacity];
        }

        public void PrintAll()
        {
            for (int i = 0; i < Length; i++)
            {
                Console.Write(_data[i] + " ");
            }
            Console.WriteLine();
        }

        public void Add(T newItem)
        {
            if (_length == _capacity)
            {
                throw new OutOfMemoryException("OutOfMemoryException");
            }
            _data[_length] = newItem;
            _length++;
        }

        public void Insert(int index, T newItem)
        {
            if (index < 0 || index > _length)
            {
                throw new IndexOutOfRangeException("IndexOutOfRangeException");
            }
            if (_length == _capacity)
            {
                throw new OutOfMemoryException("OutOfMemoryException");
            }
            for (int i = _length - 1; i >= index; i--)
            {
                _data[i + 1] = _data[i];
            }
            _data[index] = newItem;
            _length++;
        }

        public T Find(int index)
        {
            if (index < 0 || index >= _length)
            {
                throw new IndexOutOfRangeException("IndexOutOfRangeException");
            }
            return _data[index];
        }

        public int IndexOf(T val)
        {
            int res = -1;
            if (_length == 0)
            {
                return res;
            }
            if (_data[0].Equals(val))
            {
                return 0;
            }
            if (_data[_length - 1].Equals(val))
            {
                return _length - 1;
            }
            for (int i = 0; i < _length; i++)
            {
                if (_data[i].Equals(val))
                {
                    res = i;
                    break;
                }
            }
            return res;
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index > _length - 1)
            {
                return false;
            }
            for (int i = index + 1; i <= _length - 1; i++)
            {
                _data[i - 1] = _data[i];
            }
            _length--;
            return true;
        }

        public bool Remove(T val)
        {
            int index = IndexOf(val);
            if (index == -1)
            {
                return false;
            }
            return RemoveAt(index);
        }

        public void Clear()
        {
            _data = new T[_capacity];
            _length = 0;
        }

        public T GetItem(int index)
        {
            return _data[index];
        }


    }


    //>>>>>>>>>>>>>>>>>>>>>练习 实现部分>>>>>>>>>>>>>>>>>>>>>>
    public sealed class Pra
    {
        //p1:实现一个支持动态扩容的数组
        public sealed class p1Array
        {
            private int cap;
            private int len;
            public int length => len;
            private int[] data;

            public p1Array(int capacity)
            {
                cap = capacity;
                data = new int[cap];
                len = 0;
            }

            public void Expand(int size)
            {
                if (size <= cap)
                {
                    return;
                }
                cap = size;
                int[] newData = new int[cap];
                for (int i = 0; i < cap; i++)
                {
                    newData[i] = data[i];
                }
                data = newData;
            }

            public void Add(int val)
            {
                if (len == cap)
                {
                    Expand(cap * 2);
                }
                data[len] = val;
                len++;
            }

            public int IndexOf(int val)
            {
                int res = -1;
                if (len == 0)
                {
                    return res;
                }
                if (data[len - 1] == val)
                {
                    return len - 1;
                }
                for (int i = 0; i < len; i++)
                {
                    if (data[i] == val)
                    {
                        res = i;
                        break;
                    }
                }
                return res;
            }

            public void Remove(int val)
            {
                int index = IndexOf(val);
                if (index == -1)
                {
                    return;
                }
                RemoveAt(index);
            }

            public void RemoveAt(int index)
            {
                if (index < 0 || index > len - 1)
                {
                    return;
                }
                for (int i = index + 1; i <= len - 1; i++)
                {
                    data[i - 1] = data[i];
                }
                len--;
            }

        }

        //p2:实现一个大小固定的有序数组，支持动态增删改操作
        public sealed class p2Array
        {
            private int cap;
            private int len;
            public int length => len;
            private int[] data;

            public p2Array(int capacity)
            {
                cap = capacity;
                data = new int[cap];
                len = 0;
            }

            public void Set(int index, int val)
            {
                if (index < 0 || index >= len)
                {
                    return;
                }
                data[index] = val;
                //使用快排，保持有序
                TestChapter12.QuickSort(data);
            }

            public void Add(int val)
            {
                if (len >= cap)
                {
                    return;
                }
                data[len] = val;
                len++;
                //使用快排，保持有序
                TestChapter12.QuickSort(data);
            }

            public int IndexOf(int val)
            {
                //使用二分查找
                return TestChapter15.BSearch(data, len, val);
            }

            public void Remove(int val)
            {
                int index = IndexOf(val);
                if (index == -1)
                {
                    return;
                }
                RemoveAt(index);
            }

            public void RemoveAt(int index)
            {
                if (index < 0 || index > len - 1)
                {
                    return;
                }
                for (int i = index + 1; i <= len - 1; i++)
                {
                    data[i - 1] = data[i];
                }
                len--;
            }

            public void PrintAll()
            {
                for (int i = 0; i < len; i++)
                {
                    Console.Write(data[i] + " ");
                }
                Console.WriteLine();
            }

        }

        //p3:实现两个有序数组合并为一个有序数组
        static public int[] MergeTwo(int[] a, int[] b)
        {
            int[] res = new int[a.Length + b.Length];
            int aIndex = 0;
            int bIndex = 0;
            int i = 0;
            bool aPass = false;
            bool bPass = false;
            while (aIndex <= a.Length - 1 || bIndex <= b.Length - 1) //让两个index都走到尽头
            {
                if (aPass)
                {
                    res[i++] = b[bIndex++];
                    continue;
                }
                if (bPass)
                {
                    res[i++] = a[aIndex++];
                    continue;
                }
                if (a[aIndex] <= b[bIndex])
                {
                    res[i++] = a[aIndex++];
                }
                else
                {
                    res[i++] = b[bIndex++];
                }
                if (aIndex > a.Length - 1)
                {
                    aPass = true;
                }
                if (bIndex > b.Length - 1)
                {
                    bPass = true;
                }
            }
            return res;
        }

    }


}
