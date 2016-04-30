using System;
using System.Text.RegularExpressions;

namespace Task7._1
{
    class Program
    {// 31 февраля или число 00м
        static void Main()
        {
            Regex r = new Regex(@"((0[1-9]|[12][0-8])-(02)|(0[1-9]|[12][0-9]|3[1])-(0[135789]|1[02])|(0[1-9]|[12][0-9]|30)-(0[46]|11]))-(19|20)[0-9][0-9]");
            string a = "2008 год наступит 30-04-2016";
            Console.WriteLine(r.IsMatch(a));
            Console.ReadKey();
        }
    }
}
