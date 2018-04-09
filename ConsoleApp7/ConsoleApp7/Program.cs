using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = new int[,] {{0, 1, 1, 100, 0, 0},
                               {1, 0, 1, 0, 0, 0},
                               {1, 1, 0, 0, 0, 0},
                               {100, 0, 0, 0, 2, 2},
                               {0, 0, 0, 2, 0, 2},
                               {0, 0, 0, 2, 2, 0}};

            int csot =new Graph().FindCost(5, graph);
            Console.WriteLine(csot);

            Console.ReadKey();
        }

    }

    public class Graph
    {
    
        public int FindCost(int v,int[,] adj)
        {
            bool[] vertices = new bool[v];
            int[] parents = new int[v];
            int[] keys = new int[v];

            for (int i = 0; i < v; i++)
            {
                keys[i] = int.MaxValue;
                parents[i] = -1;
            }

            keys[0] = 0;
            parents[0] = 0;
            for (int i = 0; i < v; i++)
            {
                int MinIndex = FindMin(vertices, keys);
                vertices[MinIndex] = true;

                for (int j = 0; j < v; j++)
                {
                    if (adj[MinIndex,j] != 0 && adj[MinIndex,j] < keys[j] && vertices[j] ==false)
                    {
                        keys[j] = adj[MinIndex, j];
                        parents[j] = MinIndex;
                    }
                }
            }
            int sum = 0;

            for (int i = 0; i < v; i++)
            {
                Console.WriteLine($"{parents[i]} - {i} => {adj[parents[i],i]}");
            }

            for (int i = 0; i < v; i++)
            {
                sum += adj[parents[i], i];
            }

            return sum;
        }

        public void PrintGraph(int n,int[,] graph)
        {
          
        }

        private int FindMin(bool[] vertices,int [] keys)
        {
            int n = vertices.Length;
            int minKey = int.MaxValue;
            int minIndex = 0;

            for (int i = 0; i < n; i++)
            {
                if (vertices[i] == false && keys[i]<minKey)
                {
                    minKey = keys[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }
   }
}
