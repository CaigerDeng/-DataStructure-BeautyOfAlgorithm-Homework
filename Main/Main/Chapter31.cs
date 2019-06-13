using System;
using System.Collections.Generic;
using System.Text;
using Chapter30;

namespace Chapter31
{
    class TestChapter31
    {
        static public void Run()
        {
            //测试迷宫如下：起点0，终点6，求路径
            //   0 - 1 - 2
            //   |   |   |
            //   3 - 4 - 5
            //       |   |
            //       6 - 7

            Graph_AdjList graph = new Graph_AdjList(8);
            graph.Follow(0, 1);
            graph.Follow(0, 3);
            graph.Follow(1, 0);
            graph.Follow(1, 2);
            graph.Follow(1, 4);
            graph.Follow(2, 1);
            graph.Follow(2, 5);
            graph.Follow(3, 0);
            graph.Follow(3, 4);
            graph.Follow(4, 1);
            graph.Follow(4, 3);
            graph.Follow(4, 5);
            graph.Follow(4, 6);
            graph.Follow(5, 2);
            graph.Follow(5, 4);
            graph.Follow(5, 7);
            graph.Follow(6, 4);
            graph.Follow(6, 7);
            graph.Follow(7, 5);
            graph.Follow(7, 6);

            BFS(graph, 0, 6);
            //DFS(graph,0,6);

        }


        //广度优先搜索
        static public void BFS(Graph_AdjList graph, int begin, int end)
        {
            if (begin == end)
            {
                return;
            }
            int[] prev = new int[graph.v];
            for (int i = 0; i < graph.v; i++)
            {
                prev[i] = -1;
            }
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(begin);
            bool[] visited = new bool[graph.v];
            visited[begin] = true;
            while (queue.Count > 0)
            {
                int num = queue.Dequeue();
                for (int i = 1; i <= graph.data[num].Length; i++)
                {
                    var node = graph.data[num].Find(i);
                    if (node != null)
                    {
                        int content = node.Val;
                        if (!visited[content])
                        {
                            prev[content] = num;
                            if (content == end)
                            {
                                PrintPath(prev, begin, end);
                                return;
                            }
                            queue.Enqueue(content);
                            visited[content] = true;
                        }
                    }
                }
            }
            PrintPath(prev, begin, end);

        }

        //打印从begin到end的路径
        static public void PrintPath(int[] prev, int begin, int end)
        {
            if (prev[end] != -1 && begin != end)
            {
                PrintPath(prev, begin, prev[end]);
            }
            Console.Write(end + " ");
        }

        static private bool found_DFS = false;
        //深度优先搜索
        static public void DFS(Graph_AdjList graph, int begin, int end)
        {
            if (begin == end)
            {
                return;
            }
            int[] prev = new int[graph.v];
            for (int i = 0; i < graph.v; i++)
            {
                prev[i] = -1;
            }
            bool[] visited = new bool[graph.v];
            visited[begin] = true;
            found_DFS = false;
            DFSDetail(graph, prev, visited, begin, end);
            PrintPath(prev, begin, end);
        }

        static private void DFSDetail(Graph_AdjList graph, int[] prev, bool[] visited, int begin, int end)
        {
            if (found_DFS)
            {
                return;
            }
            if (begin == end)
            {
                found_DFS = true;
                return;
            }
            for (int i = 1; i <= graph.data[begin].Length; i++)
            {
                var node = graph.data[begin].Find(i);
                if (node != null)
                {
                    int content = node.Val;
                    if (!visited[content])
                    {
                        prev[content] = begin;
                        visited[content] = true;
                        DFSDetail(graph, prev, visited, content, end);
                    }
                }
            }
        }

    }




}
