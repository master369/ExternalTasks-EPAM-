using System;
using System.Collections.Generic;
using System.Linq;


namespace Task3._1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] listPerson = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Queue<int> list = new Queue<int>(listPerson);

            while (list.Count != 1)
            {
                list.Enqueue(list.Dequeue());
                list.Dequeue();
            }
            Console.WriteLine(list);
            Console.ReadKey();
        }
    }
}
