using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._11
{
    class Program
    {
        static void Main(string[] args)
        {
            {

                string str = "Бла бла......................блаблааааааа!";
                char ch;
                int count = 0;
                foreach (var item in str)
                {
                    if (Char.IsPunctuation(item) || Char.IsSeparator(item))
                    {
                        count++;
                    }
                }
                char[] separator = new char[count];
                count++;
                foreach (var item in str)
                {
                    if (Char.IsPunctuation(item) || Char.IsSeparator(item))
                    {
                        separator[count] = item;
                        count++;
                    }
                }
                string[] words = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine("Средняя длина строки: {0}", AverageLenght(words));
                Console.ReadLine();
            }
        }

        static int AverageLenght(string[] words)
        {
            int sumLength = 0;
            int wordsCount = words.Length;
            for (int i = 0; i < wordsCount; i++)
            {
                sumLength += words[i].Length;
            }
            return sumLength / wordsCount;
        }
    }
}
