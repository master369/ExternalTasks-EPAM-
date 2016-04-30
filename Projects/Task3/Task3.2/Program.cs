using System;
using System.Collections.Generic;

namespace Task3._3
{
    internal class Program
    {
       public static void Main(string[] args)
        {
            string str = "Blah Blah......................Blahhhhh!";
            int count = 0;
            foreach (var item in str)
            {
                if (char.IsPunctuation(item) || char.IsSeparator(item))
                {
                    count++;
                }
            }
            char[] separator = new char[count];
            count = 0;
            foreach (var item in str)
            {
                if (char.IsPunctuation(item) || char.IsSeparator(item))
                {
                    separator[count] = item;
                    count++;
                }
            }
            string[] words = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            var dict = new Dictionary<string, int>();
            foreach (var word in words)
                if (dict.ContainsKey(word)) dict[word]++;
                else dict.Add(word, 1);
            foreach (var item in dict)
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
        }
    }
}