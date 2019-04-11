using System;
using System.Collections.Generic;
using System.Text;
using Chapter06;

namespace Chapter09
{
    public class TestChapter09
    {
        static public void Run()
        {
            //ArrayQueue<int> qq = new ArrayQueue<int>(10);
            //qq.Enqueue(1);
            //qq.Enqueue(2);
            //qq.Enqueue(5);
            //qq.PrintAll();

            //qq.Dequeue();
            //qq.PrintAll();

            LinkedListQueue<int> qq = new LinkedListQueue<int>();
            qq.Enqueue(1);
            qq.Enqueue(2);
            qq.Enqueue(5);
            qq.PrintAll();

            qq.Dequeue();
            qq.PrintAll();

        }


    }

    //数组实现队列
    public class ArrayQueue<T> where T : IComparable<T>
    {
        private T[] _data;
        public int length
        {
            get
            {
                return Math.Max(0, tail - head + 1);
            }
        }
        private int capacity;
        private int head = 0; //队头下标
        private int tail = 0; //队尾下标 (lastIndex+1)

        public ArrayQueue(int capa)
        {
            _data = new T[capa];
            capacity = capa;
        }

        public T Enqueue(T item)
        {
            if (tail == capacity)
            {
                throw new OutOfMemoryException("OutOfMemoryException");
            }
            _data[tail] = item;
            tail++;
            return item;
        }

        //有数据搬移检测
        public T EnqueueBetter(T item)
        {
            if (tail == capacity)
            {
                if (head == 0)
                {
                    throw new OutOfMemoryException("OutOfMemoryException");
                }
                for (int i = head; i < tail; i++)
                {
                    _data[i - head] = _data[i];
                }
            }
            tail -= head;
            head = 0;
            _data[tail] = item;
            tail++;
            return item;
        }

        public T Dequeue()
        {
            if (head == tail)
            {
                throw new IndexOutOfRangeException("OutOfMemoryException");
            }
            var item = _data[head];
            head++;
            return item;
        }

        public void PrintAll()
        {
            for (int i = head; i < tail; i++)
            {
                Console.Write(_data[i] + " ");
            }
            Console.WriteLine();
        }

    }

    //单链表实现队列
    public class LinkedListQueue<T> where T : IComparable<T>
    {
        private SingleLinkedList<T> _data;
        public int length { get { return _data.Length; } }
        private Node<T> head;
        private Node<T> tail;

        public LinkedListQueue()
        {
            _data = new SingleLinkedList<T>();
            head = _data.First; //还是null
            tail = null;
        }

        //表尾加
        public T Enqueue(T item)
        {
            Node<T> node = new Node<T>(item);
            if (head == null)
            {
                head = node;
                _data.Head.Next = head;
                tail = head;
            }
            else
            {
                tail.Next = node;
                tail = node;
            }
            return item;
        }

        //表头删
        public T Dequeue()
        {
            if (head == null)
            {
                throw new IndexOutOfRangeException("IndexOutOfRangeException");
            }
            var item = head;
            head = head.Next;
            _data.Head.Next = head;
            if (head == null)
            {
                tail = null;
            }
            return item.Val;
        }

        public void PrintAll()
        {
            _data.PrintAll();

        }

    }

    //数组实现的循环队列
    public class CircleQueue<T> where T : IComparable<T>
    {
        private T[] _data;
        public int length { get; private set; }
        public int capacity;
        private int head = 0;
        private int tail = 0;

        public CircleQueue(int capa)
        {
            _data = new T[capa];
            capacity = capa;
            length = 0;
        }

        public T Enqueue(T item)
        {
            if ( (tail + 1) % capacity == head) //keypoint here
            {
                //队列已满
                throw new OutOfMemoryException("OutOfMemoryException");
            }
            _data[tail] = item;
            tail = (tail + 1) % capacity; //keypoint here
            return item;
        }

        public T Dequeue()
        {
            if (head == tail)
            {
                throw new IndexOutOfRangeException("OutOfMemoryException");
            }
            var item = _data[head];
            head = (head + 1) % capacity; //keypoint here
            return item;
        }

        public void PrintAll()
        {
            for (int i = head; i < tail; i++)
            {
                Console.Write(_data[i] + " ");
            }
            Console.WriteLine();
        }
    }

}
