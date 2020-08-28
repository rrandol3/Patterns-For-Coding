using System;
using System.Collections.Generic;

namespace _00___Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static List<int> TopoSort(int vertices, int[][] edges)
        {
            List<int> sortedOrder = new List<int>();
            if (vertices <= 0)
            {
                return sortedOrder;
            }

            Dictionary<int, int> inDegree = new Dictionary<int, int>();
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < vertices; i++)
            {
                inDegree.Add(i, 0);
                graph.Add(i, new List<int>());
            }

            for (int i = 0; i < edges.Length; i++)
            {
                var src = edges[i][0];
                var dst = edges[i][0];
                inDegree[dst]++;
                graph[src].Add(dst);
            }

            Queue<int> sources = new Queue<int>();
            foreach (var item in inDegree)
            {
                if (item.Value == 0)
                {
                    sources.Enqueue(item.Key);
                }
            }

            while (sources.Count != 0)
            {
                var src = sources.Dequeue();
                sortedOrder.Add(src);
                var children = graph[src];
                foreach (var child in children)
                {
                    inDegree[child]--;
                    if (inDegree[child] == 0)
                    {
                        sources.Enqueue(child);
                    }
                }
            }

            if (sortedOrder.Count != vertices)
            {
                throw new Exception("Graph has Cycle");
            }

            var test = int.Parse('s')

            return sortedOrder;
        }
    }
}
