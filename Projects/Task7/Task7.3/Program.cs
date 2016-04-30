using System;
using System.Text.RegularExpressions;

namespace Task7._3
{
    class Program
    {                 /*может начинать со знака подчеркивания*/
        static void Main()
        {
            Regex r = new Regex(@"\b^([^_.=]{1})([A-z0-9]+)[\w]+@([A-z0-9][-A-z0-9]+\.)+[A-z]{2,6}\b");
            Console.Write("Введите email: ");
            string a = Console.ReadLine();
            MatchCollection dig = r.Matches(a);
            foreach (var item in dig)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey(); 
        }
    }
}
