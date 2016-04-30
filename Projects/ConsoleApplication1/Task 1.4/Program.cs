using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._4
{
    class Program
    {
        static void Main(string[] args)
        {

            string str;
            int size = 11;
            int count;
            if (size % 2 == 0) size++;


            for (int i = 1; i <= size; i += 2)
            {
                count = size /2;
                for (int j = 1; j <= i; j += 2)
                {


                  
                    string s = new string('*', j);
                    str = string.Format("{0,"+ (size - count--) + "}", s);
                    Console.Write(str);
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
