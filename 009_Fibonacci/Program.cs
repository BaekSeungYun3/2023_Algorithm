using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _009_Fibonacci
{
    internal class Program
    {

        static long[] f = new long[51];       //static함수에서 쓰기 때문에 static 필요 - DP 프로그램이 되기 위해 추가
        static void Main(string[] args)
        {
            for(int i = 1; i<= 50; i++)
                Console.WriteLine("{0}항 = {1}", i, Fibo(i));
        }

        private static long Fibo(int n)
        {
            if (n == 1 || n == 2)
                return f[n] =  1;               //return 1;이었음 원래
            if (f[n] != 0)
                return f[n];                    //DP 프로그램이 되기 위해 2줄 추가
            return f[n] = Fibo(n - 1) + Fibo(n - 2);

        }
    }
}
