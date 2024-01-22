using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012_Floyd10
{
    internal class Program
    {
        static int V = 10; //vertex 수 10개의 도시
        const int Inf = 100; //무한대 생성
        static string[] city = { "서울", "천안", "원주", "강릉", "논산", "대전", "대구", "포항", "광주", "부산" };

        static void Main(string[] args)
        {
            int[,] graph =
            {
                { Inf, 12, 15, Inf, Inf, Inf, Inf, Inf, Inf, Inf },
                { 12, Inf, Inf, Inf, 4, 10, Inf, Inf, Inf, Inf },
                { 15, Inf, Inf, 21, Inf, Inf, 7, Inf, Inf, Inf },
                { Inf, Inf, 21, Inf, Inf, Inf, Inf, 25, Inf, Inf },
                { Inf, 4, Inf, Inf, Inf, 3, Inf, Inf, 13, Inf },
                { Inf, 10, Inf, Inf, 3, Inf, 10, Inf, Inf, Inf },
                { Inf, Inf, 7, Inf, Inf, 10, Inf, 19, Inf, 9 },
                { Inf, Inf, Inf, 25, Inf, Inf, 19, Inf, Inf, 5 },
                { Inf, Inf, Inf, Inf, 13, Inf, Inf, Inf, Inf, 15 },
                { Inf, Inf, Inf, Inf, Inf, Inf, 9, 5, 15, Inf }

            };

            FloydWarshall(graph, V);
        }

        private static void FloydWarshall(int[,] graph, int v)
        {
            Console.WriteLine("Graph");
            PrintGraph(graph, V);

            for (int k = 0; k < v; k++)
            {
                for (int i = 0; i < v; i++)
                {
                    for (int j = 0; j < v; j++)
                    {
                        if (i != j && graph[i, k] != Inf && graph[k, j] != Inf &&
                            (graph[i, j] == Inf || graph[i, k] + graph[k, j] < graph[i, j]))
                        {
                            graph[i, j] = graph[i, k] + graph[k, j];
                            Console.WriteLine("Change: [{0},{1}] = [{2},{3}] +" +
                                " [{4},{5}] = {6}", i, j, i, k, k, j, graph[i, j]);
                        }
                    }
                }
                PrintGraph(graph, V);
            }
        }



        private static void PrintGraph(int[,] graph, int v)
        {

            Console.Write("\t");
            for (int i = 0; i < v; i++)
            {
                Console.Write("{0}\t", city[i]);
            }
            Console.WriteLine();

            for (int i = 0; i < v; i++)
            {
                Console.Write("{0}\t", city[i]);
                for (int j = 0; j < v; j++)
                {
                    Console.Write("{0}\t", graph[i, j] == Inf ? 0 : graph[i, j]);
                }
                Console.WriteLine();
            }
        }


    }

}