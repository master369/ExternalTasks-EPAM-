﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество строк: ");
            int kol = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("");

            for (int i = 1; i <= kol; i++)
            {

                string s = new string('*', i);
                Console.Write(s);

                Console.WriteLine("");
            }
            Console.ReadLine();
        }
    }
}
