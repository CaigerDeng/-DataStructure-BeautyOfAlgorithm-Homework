using System;
using System.Collections.Generic;
using System.Text;
using Chapter23;

namespace Chapter24
{
    class TestChapter24
    {
        static public void Run()
        {
            BinarySearchTree bb = new BinarySearchTree();
            bb.Insert(5);
            bb.Insert(3);
            bb.Insert(7);
            bb.Insert(6);
            bb.Insert(9);
            bb.PrintPre(bb.root);
            Console.WriteLine();
            bb.Delete(7);
            bb.PrintPre(bb.root);
            Console.WriteLine();

        }

    }

    public class BinarySearchTree
    {
        public Node root;

        public Node Find(int val)
        {
            Node p = root;
            while (p != null)
            {
                if (val < p.val)
                {
                    p = p.left;
                }
                else if (val > p.val)
                {
                    p = p.right;
                }
                else
                {
                    return p;
                }
            }
            return null;
        }

        public void Insert(int val)
        {
            if (root == null)
            {
                root = new Node(val);
                return;
            }
            Node p = root;
            while (p != null)
            {
                if (val < p.val)
                {
                    if (p.left == null)
                    {
                        p.left = new Node(val);
                        return;
                    }
                    p = p.left;
                }
                else
                {
                    if (p.right == null)
                    {
                        p.right = new Node(val);
                        return;
                    }
                    p = p.right;
                }
            }

        }

        public void Delete(int val)
        {
            Node p = root; //要删除节点
            Node pp = null; //要删除节点的父节点
            while (p != null && p.val != val)
            {
                pp = p;
                if (val < p.val)
                {
                    p = p.left;
                }
                else
                {
                    p = p.right;
                }
            }
            if (p == null) //没找到
            {
                return;
            }
            //要删除的节点有左右子节点
            if (p.left != null && p.right != null)
            {
                Node n = p.right;
                Node nn = p;
                //找右子树最小子节点(或者左子树最大节点)
                while (n.left != null)
                {
                    nn = n;
                    n = n.left;
                }
                p.val = n.val;
                p = n;
                pp = nn;
            }
            //要删除节点是叶子节点或只有一个子节点
            Node child; //要删除节点的子节点
            if (p.left != null)
            {
                child = p.left;
            }
            else if (p.right != null)
            {
                child = p.right;
            }
            else
            {
                child = null;
            }
            //////开始删除
            if (pp == null) //删除的是根节点
            {
                root = null;
            }
            else if (pp.left == p)
            {
                pp.left = child;
            }
            else
            {
                pp.right = child;
            }
        }

        public void PrintPre(Node n)
        {
            if (n == null)
            {
                return;
            }
            Console.Write(n.val + " ");
            PrintPre(n.left);
            PrintPre(n.right);
        }

    }


}
