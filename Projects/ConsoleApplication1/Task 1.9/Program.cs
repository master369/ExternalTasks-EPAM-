using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._9
{
    class Program
    {
        static void ShowArray(int[] arr)
        {
            Console.WriteLine("Элементы массива:");
            foreach (var item in arr)
            {
                Console.WriteLine("{0}", item);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите число элементов массива: ");

            int[] arr = new int[int.Parse(Console.ReadLine())];
            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(-100,100);
            }
            ShowArray(arr);
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]>0)
                {
                    sum += arr[i];
                }
            }
            Console.WriteLine("Сумма положительных элементов: {0}", sum);
        }
    }
}
