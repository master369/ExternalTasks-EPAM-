using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._3
{
    class Program
    {



        static void Main(string[] args)
        {
            string str;
            
            Console.Write("Size: ");
            int size = int.Parse(Console.ReadLine());
            int count = size/2;
            if (size % 2 == 0) size++;

            for (int i = 1; i <= size; i += 2)
            {
                string s = new string('*', i);
                str = string.Format("{0," + (size - count--) + "}", s);
                Console.Write(str);
                Console.WriteLine();

            }
            Console.ReadKey();
        }
    }
}
