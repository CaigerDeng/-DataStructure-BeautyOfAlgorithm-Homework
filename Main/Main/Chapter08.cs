using System;
using System.Collections.Generic;
using System.Text;
using Chapter06;

namespace Chapter08
{
    public class TestChapter08
    {
        static public void Run()
        {
            //ArrayStack<int> ss = new ArrayStack<int>(5);
            //ss.Push(1);
            //ss.Push(2);
            //ss.Push(1);
            //ss.PrintAll();

            LinkedListStack<int> hh = new LinkedListStack<int>();
            hh.Push(1);
            hh.Push(2);
            hh.Push(5);
            hh.PrintAll();

            hh.Pop();
            hh.PrintAll();
        }




    }

    //数组实现栈
    public class ArrayStack<T> where T : IComparable<T>
    {
        private T[] _data;
        private readonly int capacity;
        public int length { get; private set; }

        public ArrayStack(int capa)
        {
            _data = new T[capa];
            capacity = capa;
            length = 0;
        }

        public T Push(T item)
        {
            if (length == capacity)
            {
                throw new OutOfMemoryException("OutOfMemoryException");
            }
            _data[length] = item;
            length++;
            return _data[length];
        }

        public T Pop()
        {
            if (length == 0)
            {
                throw new IndexOutOfRangeException("IndexOutOfRangeException");
            }
            var item = _data[length - 1];
            length--;
            return item;
        }

        public void PrintAll()
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write(_data[i] + " ");
            }
            Console.WriteLine();
        }

    }

    //单链表实现栈
    public class LinkedListStack<T> where T : IComparable<T>
    {
        private SingleLinkedList<T> _data = new SingleLinkedList<T>();

        public T Push(T item)
        {
            //链表头增
            _data.AddToBegin(item);
            return item;
        }
        
        public T Pop()
        {
            var node = _data.RemoveAt(1);
            return node.Val;
        }

        public void PrintAll()
        {
            _data.PrintAll();
        }

    }







}
