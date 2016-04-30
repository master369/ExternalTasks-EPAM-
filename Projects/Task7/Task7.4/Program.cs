using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task7._4
{
    class Program
    {
        static void Main(string[] args)
        {
            //разбить на две явные регулярки и число может начинаться с +-.9 или .9 в начале должен быть 0 всегда
            Regex regex1 = new Regex(@"^-?[0-9]+(\.[0-9]+)?$");

            Regex regex2 = new Regex(@"^[-+]?[0-9](\.[0-9]+)?([eE][-+]?[0-9]+)$");
            string input = Console.ReadLine();
            if (regex1.IsMatch(input))
                Console.WriteLine("Это число в обычной нотации");
            else if (regex2.IsMatch(input))
                Console.WriteLine("Это число в научной нотации");
            else
                Console.WriteLine("Это не число!");
        }
    }
}
