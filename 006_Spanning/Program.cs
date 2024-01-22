using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Prim_MST 그래프

namespace _006_Spanning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph();
            g.ReadGraph("graph1.txt");
            g.PrintGraph();

            g.Prim(0);      //0번 버텍스부터 시작하는 MST
        }
    }

}