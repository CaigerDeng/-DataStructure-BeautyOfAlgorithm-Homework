//Chapter06+07

using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter06
{
    public class Node<T>
    {
        public T Val;
        public Node<T> Next;
        public Node(T value)
        {
            Val = value;
        }
    }

    public class TestChapter06
    {
        static public void Run()
        {
            //SingleLinkedList<int> tt = new SingleLinkedList<int>();
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

            //SingleLinkedList<int> tt = new SingleLinkedList<int>(1,2);
            //tt.Reverse();
            //tt.PrintAll();

            //SingleLinkedList<int> tt = new SingleLinkedList<int>(1, 2, 3, 4);
            //tt.PrintAll();
            //tt.MakeLoop(2);
            //Console.WriteLine("Has Loop:{0}", tt.HasLoop());

            //SingleLinkedList<int> tt = new SingleLinkedList<int>(1, 2, 3, 2, 1);
            //Console.WriteLine("Is Huiwen:{0}", IsHuiwen(tt));
            //tt.PrintAll();

            SingleLinkedList<int> tt = new SingleLinkedList<int>(1, 2, 5);
            SingleLinkedList<int> ss = new SingleLinkedList<int>(3, 4, 4);
            SingleLinkedList<int> hh = MergeSortedTwo(tt, ss);
            hh.PrintAll();

        }

        //LRU缓存清除算法
        static public void LRU(SingleLinkedList<int> sll, int val, int capacity)
        {
            if (sll.First != null && sll.First.Val == val)
            {
                Console.WriteLine("Return same val.");
                return;
            }
            var temp = sll.Remove(val);
            if (temp == null)
            {
                if (sll.Length >= capacity)
                {
                    sll.RemoveAt(sll.Length);
                }
            }
            sll.AddToBegin(val);

        }

        //是否回文
        static public bool IsHuiwen(SingleLinkedList<int> sll)
        {
            if (sll.Length <= 1)
            {
                return false;
            }
            //反转前半部分
            Node<int> pre = null;
            Node<int> slow = sll.First;
            Node<int> fast = sll.First;
            Node<int> reverseNode = null;
            Node<int> midNode = null;
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                var next = slow.Next;
                slow.Next = pre;
                pre = slow;
                slow = next;
            }
            reverseNode = pre;
            midNode = slow;
            if (fast != null)
            {
                //说明是奇数，因为刚好走完。需要跳过中点好检测内容，则再走一步
                slow = slow.Next;
            }
            //比较
            bool res = true;
            while (slow != null)
            {
                if (slow.Val != pre.Val)
                {
                    res = false;
                    break;
                }
                slow = slow.Next;
                pre = pre.Next;
            }
            //还原前半部分
            pre = midNode;
            slow = reverseNode;
            while (slow != null)
            {
                var next = slow.Next;
                slow.Next = pre;
                pre = slow;
                slow = next;
            }
            sll.Head.Next = pre;
            return res;
        }

        //合并两个有序单链表
        static public SingleLinkedList<int> MergeSortedTwo(SingleLinkedList<int> s1, SingleLinkedList<int> s2)
        {
            if (s1.Length == 0)
            {
                return s2;
            }
            if (s2.Length == 0)
            {
                return s1;
            }
            Node<int> temp1 = s1.First;
            Node<int> temp2 = s2.First;
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            Node<int> endNode = list.Head;
            Node<int> temp = null;
            while (true)
            {
                if (temp1.Val < temp2.Val)
                {
                    temp = temp1;
                    temp1 = temp1.Next;
                }
                else
                {
                    temp = temp2;
                    temp2 = temp2.Next;
                }
                Node<int> node = new Node<int>(temp.Val);
                endNode.Next = node;
                endNode = node;
                if (temp1 == null || temp2 == null)
                {
                    break;
                }
            }
            if (temp1 == null)
            {
                endNode.Next = temp2;
            }
            else
            {
                endNode.Next = temp1;
            }
            return list;
        }

        static public void PrintByNode(Node<int> headNode)
        {
            var p = headNode;
            while (p != null)
            {
                Console.Write(p.Val + " ");
                p = p.Next;
            }
            Console.WriteLine("打印完毕");

        }

    }


    //有哨兵结点的单链表
    public class SingleLinkedList<T> where T : IComparable<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> First => Head.Next;

        public int Length { get; private set; }

        public SingleLinkedList(params T[] list)
        {
            //哨兵结点 默认值
            Head = new Node<T>(default(T));
            Length = 0;
            if (list.Length > 0)
            {
                int index = 0;
                var p = Head;
                while (index < list.Length)
                {
                    var q = new Node<T>(list[index]);
                    p.Next = q;
                    p = q;
                    index++;
                }
                Length = list.Length;
            }
        }

        public void PrintAll()
        {
            var p = First;
            //前进
            while (p != null)
            {
                Console.Write(p.Val + " ");
                p = p.Next;
            }
            Console.WriteLine();
        }

        public Node<T> Find(int position)
        {
            if (position < 1 || position > Length)
            {
                return null;
            }
            var p = First;
            //前进
            int pos = 1;
            while (p != null && pos < position)
            {
                p = p.Next;
                pos++;
            }
            return p;
        }

        //表头插入
        public Node<T> AddToBegin(T newItem)
        {
            Node<T> p = new Node<T>(newItem);
            var q = First;
            p.Next = q;
            Head.Next = p;
            Length++;
            return p;
        }

        //从position后插入
        public Node<T> Insert(int position, T newItem)
        {
            var p = Find(position);
            if (p == null)
            {
                return null;
            }
            var q = new Node<T>(newItem);
            q.Next = p.Next;
            p.Next = q;
            Length++;
            return q;
        }

        public Node<T> Find(T item)
        {
            var p = First;
            //前进
            while (p != null)
            {
                if (p.Val.Equals(item))
                {
                    break;
                }
                p = p.Next;
            }
            return p;
        }

        public Node<T> Remove(T item)
        {
            var p = First;
            var q = p;
            //前进
            while (p != null)
            {
                if (p.Val.Equals(item))
                {
                    break;
                }
                q = p;
                p = p.Next;
            }
            if (p == null)
            {
                return null;
            }
            q.Next = p.Next;
            p.Next = null;
            Length--;
            return p;
        }

        public Node<T> RemoveAt(int position)
        {
            if (position < 1 || position > Length)
            {
                throw new IndexOutOfRangeException("IndexOutOfRangeException");
            }
            //直接用Find(...)会被拦截
            //这里用p = Head 更好
            var p = Head;
            //前进
            int pos = 1;
            while (p != null && pos <= position - 1)
            {
                p = p.Next;
                pos++;
            }
            if (p == null)
            {
                return null;
            }
            var q = p.Next;
            if (q == null)
            {
                return null;
            }
            p.Next = q.Next;
            q.Next = null;
            Length--;
            return q;
        }

        public void Clear()
        {
            var p = First;
            while (p != null)
            {
                var q = p.Next;
                p.Next = null;
                p = q;
            }
            Length = 0;
        }

        public void Reverse()
        {
            if (Length <= 1)
            {
                return;
            }
            Node<T> lastNode = null;
            Node<T> currNode = First;
            Node<T> nextNode = null;
            while (currNode != null)
            {
                nextNode = currNode.Next;
                currNode.Next = lastNode;
                lastNode = currNode;
                currNode = nextNode;
            }
            Head.Next = lastNode;

        }

        /// <summary>
        /// 在指定位置 制造环
        /// </summary>
        /// <param name="loopBeginPosition"></param>
        public void MakeLoop(int loopBeginPosition = 1)
        {
            var endNode = Find(Length);
            var beginNode = Find(loopBeginPosition);
            endNode.Next = beginNode;
        }

        /// <summary>
        /// 检测是否有环
        /// </summary>
        /// <returns></returns>
        public bool HasLoop()
        {
            if (Length < 2)
            {
                return false;
            }
            var slow = First;
            var fast = First;
            while (true)
            {
                slow = slow.Next;
                fast = fast.Next;
                if (fast == null)
                {
                    return false;
                }
                fast = fast.Next;
                if (fast == null)
                {
                    return false;
                }
                if (slow == fast)
                {
                    return true;
                }
            }


        }





















    }



}
