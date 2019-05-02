//Chapter25 + 26

using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter25
{
    class TestChapter25
    {
        static public void Run()
        {


        }


    }


    public class Node
    {
        public int key;
        public int val;
        public Node left;
        public Node right;
        public bool color; //红色true 黑色false

        public Node(int key, int val, bool color)
        {
            this.key = key;
            this.val = val;
            this.color = color;
        }
    }

    public class RedBlackBST
    {
        private Node root;

        private bool IsRed(Node n)
        {
            if (n == null)
            {
                return false;
            }
            return n.color;
        }

        private Node RotateLeft(Node n)
        {
            Node x = n.right;
            n.right = x.left;
            x.left = n;
            x.color = n.color;
            n.color = true;
            return n;
        }

        private Node RotateRight(Node n)
        {
            Node x = n.left;
            n.left = x.right;
            x.right = n;
            x.color = n.color;
            n.color = true;
            return n;
        }

        private void FlipColor(Node n)
        {
            n.color = true;
            n.left.color = false;
            n.right.color = false;
        }

        public void Add(int key, int val)
        {
            root = AddDetail(root, key, val);
            root.color = false; //根节点永远为黑色
        }

        private Node AddDetail(Node n, int key, int val)
        {
            ////插入阶段
            if (n == null)
            {
                //标准插入
                n = new Node(key, val, true);
                return n;
            }
            if (key < n.key)
            {
                n.left = AddDetail(n.left, key, val);
            }
            else if (key > n.key)
            {
                n.right = AddDetail(n.right, key, val);
            }
            else
            {
                n.val = val;
            }
            /////修正阶段
            if (!IsRed(n.left) && IsRed(n.right))
            {
                RotateLeft(n);
            }
            if (IsRed(n.left) && IsRed(n.left.left))
            {
                RotateRight(n);
            }
            if(IsRed(n.left) && IsRed(n.right))
            {
                FlipColor(n);
            }
            return n;
        }


        //...删除没搞懂，先跳过

    }


}
