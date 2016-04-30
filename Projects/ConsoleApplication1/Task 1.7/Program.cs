using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._7
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

        static int Max(int[] arr)
        {
            int max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (max< arr[i])
                {
                    max = arr[i];
                }
            }
            
            return max;
        }
        static int Min(int[] arr)
        {
            int min = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (min > arr[i])
                {
                    min = arr[i];
                }
            }
          
            return min;
           
        }
        static void BubbleSort(int [] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(arr[i]) == -1)
                    {
                        var temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
           
            Console.WriteLine("Введите число элементов массива: ");
           
            int [] arr = new int [int.Parse(Console.ReadLine())];
            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(100);
            }
            ShowArray(arr);
            int max = Max(arr);
            Console.WriteLine("Max: {0}",max);
            int min =  Min(arr);
            Console.WriteLine("Min: {0}", min);
            BubbleSort(arr);
            ShowArray(arr);
        }

     
    }
}
