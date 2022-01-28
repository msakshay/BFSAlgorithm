using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFSAlgorithm
{
    /// <summary>
    /// BFS with dictionary 
    /// </summary>
    public class BFSGraph
    {
        readonly Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        readonly Dictionary<int, bool> visited = new Dictionary<int, bool>();

        public void AppendEdge(int vertice, int newEdge)
        {
            if (graph.ContainsKey(vertice))
            {
                graph[vertice].Add(newEdge);
            }
            else
            {
                graph.Add(vertice, new List<int>() { newEdge });
                
            }
            if (!visited.ContainsKey(vertice))
                visited.Add(vertice, false);
            if (!visited.ContainsKey(newEdge))
                visited.Add(newEdge, false);
        }

        public void BFS(int startVertex)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startVertex);

            while (queue.Count > 0)
            {
                int vertice = queue.Dequeue();
                if (visited[vertice])
                    continue;
                foreach (int v in graph[vertice])
                {
                    queue.Enqueue(v);
                }
                visited[vertice] = true;
                Console.Write(vertice + " ");

            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BFSGraph g = new BFSGraph();
            g.AppendEdge(0, 1);
            g.AppendEdge(0, 2);
            g.AppendEdge(1, 2);
            g.AppendEdge(2, 0);
            g.AppendEdge(2, 3);
            g.AppendEdge(3, 3);
            g.BFS(3);
            Console.ReadLine();
        }

    }
}
