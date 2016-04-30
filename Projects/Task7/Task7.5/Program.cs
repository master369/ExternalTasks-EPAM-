using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task7._5
{
    class Program
    {
        static void Main()
        {
            Regex r = new Regex(@"(([0-1]?[0-9])|[2][0-3]|0?0):[0-5][0-9]");
            string a = "В 7:00 я встал, позавтракал и к 11:70  пошёл на работу.";
            MatchCollection sum = r.Matches(a);
            Console.WriteLine(sum.Count);
            Console.ReadKey();
        }
    }
}
