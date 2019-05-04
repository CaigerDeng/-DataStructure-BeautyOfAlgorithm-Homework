using System;
using System.Collections.Generic;
using System.Text;
using Chapter06;

namespace Chapter30
{
    class TestChapter30
    {
        static public void Run()
        {
            //Graph_AdjMatrix g = new Graph_AdjMatrix(4);
            ////测试顶点0 ,1，2，3
            //g.Follow(0, 1);
            //g.Follow(1, 2);
            //g.Follow(2, 0);
            //g.Follow(2, 1);
            //g.Follow(3, 1);
            //g.Follow(3, 2);
            //g.PrintAll();

            Graph_AdjList g = new Graph_AdjList(4);
            //测试顶点0, 1，2，3
            g.Follow(0, 1);
            g.Follow(1, 2);
            g.Follow(2, 0);
            g.Follow(2, 1);
            g.Follow(3, 1);
            g.Follow(3, 2);
            g.PrintAll();

        }
    }

    //图 用邻接矩阵存储 
    public class Graph_AdjMatrix
    {
        private int v; //顶点个数
        private int[,] data;

        public Graph_AdjMatrix(int v)
        {
            this.v = v;
            data = new int[v, v];
        }

        public void Follow(int source, int des)
        {
            data[source, des] = 1;
        }

        public void UnFollow(int source, int des)
        {
            data[source, des] = 0;
        }

        public void PrintAll()
        {
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    Console.Write(data[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }



    }

    //图 用邻接表存储
    public class Graph_AdjList
    {
        public int v; //顶点个数
        public SingleLinkedList<int>[] data;

        public Graph_AdjList(int v)
        {
            this.v = v;
            data = new SingleLinkedList<int>[v];
            for (int i = 0; i < v; i++)
            {
                data[i] = new SingleLinkedList<int>();
            }

        }

        public void Follow(int source, int des)
        {
            data[source].Insert(data[source].Length, des);
        }

        public void Follow(int source, int[] des)
        {
            for (int i = 0; i < des.Length; i++)
            {
                data[source].Insert(data[source].Length, des[i]);
            }
        }

        public void UnFollow(int source, int des)
        {
            data[source].Remove(des);
        }

        public void PrintAll()
        {
            for (int i = 0; i < v; i++)
            {
                Console.WriteLine("[{0}]:", i + 1);
                data[i].PrintAll();
            }
            Console.WriteLine();
        }


    }


}
