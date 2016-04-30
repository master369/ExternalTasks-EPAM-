using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._5
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = sum(3, 1000) + sum(5, 1000) - sum(15, 1000);
            Console.WriteLine("Sum = {0}", result);
            Console.ReadKey();
        }

        public static int sum(int a1, int maxVal)
        {
            int an = (maxVal % a1 == 0) ? maxVal - a1 : maxVal - maxVal % a1;
            int n = an / a1;
            return (a1 + an) * n / 2;
        }
    }
}
