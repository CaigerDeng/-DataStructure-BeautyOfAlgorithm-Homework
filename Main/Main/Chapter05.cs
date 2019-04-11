using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter05
{
    public class TestChapter05
    {
        static public void Run()
        {
            Array<int> tt = new Array<int>(4);
            LRU(tt, 1, 4);
            LRU(tt, 2, 4);
            LRU(tt, 3, 4);
            LRU(tt, 4, 4);
            tt.PrintAll();

            LRU(tt, 2, 4);
            tt.PrintAll();

            LRU(tt, 3, 4);
            tt.PrintAll();

            LRU(tt, 3, 4);
            tt.PrintAll();


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
            arr.Insert(0,val);

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




}
