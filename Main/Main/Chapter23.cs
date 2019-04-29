using System;
using System.Collections.Generic;
using System.Text;


namespace Chapter23
{
    class TestChapter23
    {
        static public void Run()
        {
            //int[] arr = { 1, 2, 3, 4, 5, 6 };
            //CompleteBinaryTree_LinkedList tree = new CompleteBinaryTree_LinkedList();
            //tree.Create(arr);
            //Console.WriteLine("前序打印:");
            //tree.PrintPre(tree.root);
            //Console.WriteLine();

            //Console.WriteLine("中序打印:");
            //tree.PrintIn(tree.root);
            //Console.WriteLine();

            //Console.WriteLine("后序打印:");
            //tree.PrintPost(tree.root);
            //Console.WriteLine();

            //Console.WriteLine("层次打印:");
            //tree.PrintLevel(tree.root);
            //Console.WriteLine();

            int[] arr = { 1, 2, 3, 4, 5, 6 };
            CompleteBinaryTree_Arr tree = new CompleteBinaryTree_Arr();
            tree.Create(arr);
            Console.WriteLine("前序打印:");
            tree.PrintPre(0);
            Console.WriteLine();

            Console.WriteLine("中序打印:");
            tree.PrintIn(0);
            Console.WriteLine();

            Console.WriteLine("后序打印:");
            tree.PrintPost(0);
            Console.WriteLine();

            Console.WriteLine("层次打印:");
            tree.PrintLevel(0);
            Console.WriteLine();


        }
    }

    public class Node
    {
        public int val;
        public Node left;
        public Node right;

        public Node(int value)
        {
            val = value;
        }

    }

    //完全二叉树_链表
    public class CompleteBinaryTree_LinkedList
    {
        public Node root;

        //按从左到右，从上到下的阅读顺序 创建
        public void Create(int[] arr)
        {
            CreateDetail(root, arr, 0);
        }

        public void CreateDetail(Node node, int[] arr, int index)
        {
            if (node == null)
            {
                node = new Node(arr[index]);
                root = node;
            }
            int leftIndex = index * 2 + 1;
            int rightIndex = index * 2 + 2;

            if (leftIndex < arr.Length)
            {
                node.left = new Node(arr[leftIndex]);
                CreateDetail(node.left, arr, leftIndex);
            }
            if (rightIndex < arr.Length)
            {
                node.right = new Node(arr[rightIndex]);
                CreateDetail(node.right, arr, rightIndex);
            }

        }

        //打印 前序遍历 
        public void PrintPre(Node node)
        {
            if (node == null)
            {
                return;
            }
            Console.Write(node.val + " ");
            PrintPre(node.left);
            PrintPre(node.right);
        }

        //打印中序遍历 （会先打印左下方结点）
        public void PrintIn(Node node)
        {
            if (node == null)
            {
                return;
            }
            PrintIn(node.left);
            Console.Write(node.val + " ");
            PrintIn(node.right);
        }

        //打印后序遍历 （会先打印左下方结点）
        public void PrintPost(Node node)
        {
            if (node == null)
            {
                return;
            }
            PrintPost(node.left);
            PrintPost(node.right);
            Console.Write(node.val + " ");
        }

        //打印 层级遍历
        public void PrintLevel(Node node)
        {
            //借助队列
            Queue<Node> qu = new Queue<Node>();
            qu.Enqueue(node);
            while (qu.Count > 0)
            {
                Node temp = qu.Dequeue();
                Console.Write(temp.val + " ");
                if (temp.left != null)
                {
                    qu.Enqueue(temp.left);
                }
                if (temp.right != null)
                {
                    qu.Enqueue(temp.right);
                }
            }
        }

    }

    //完全二叉树_数组
    public class CompleteBinaryTree_Arr
    {
        int[] data;
        public void Create(int[] arr)
        {
            data = new int[arr.Length];
            Array.Copy(arr, data, arr.Length);
        }

        //打印 前序遍历 
        public void PrintPre(int index)
        {
            if (index >= data.Length)
            {
                return;
            }
            int leftIndex = index * 2 + 1;
            int rightIndex = index * 2 + 2;
            Console.Write(data[index] + " ");
            PrintPre(leftIndex);
            PrintPre(rightIndex);
        }

        //打印中序遍历 （会先打印左下方结点）
        public void PrintIn(int index)
        {
            if (index >= data.Length)
            {
                return;
            }
            int leftIndex = index * 2 + 1;
            int rightIndex = index * 2 + 2;
            PrintIn(leftIndex);
            Console.Write(data[index] + " ");
            PrintIn(rightIndex);
        }

        //打印后序遍历 （会先打印左下方结点）
        public void PrintPost(int index)
        {
            if (index >= data.Length)
            {
                return;
            }
            int leftIndex = index * 2 + 1;
            int rightIndex = index * 2 + 2;
            PrintPost(leftIndex);
            PrintPost(rightIndex);
            Console.Write(data[index] + " ");
        }

        //打印 层级遍历
        public void PrintLevel(int index)
        {
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(data[i] + " ");
            }
        }



    }








}
