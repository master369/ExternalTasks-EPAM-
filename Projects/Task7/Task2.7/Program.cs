using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task7._2
{
    class Program
    {
        static void Main()
        {
            string a = Regex.Replace("<b>Это</b> текст <i>с</i> <font color='red'>HTML</font> кодами", @"(<.+?>)", "_");
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
