using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._10
{
    class Program
    {
        static void ShowArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                   
                        Console.Write("{0,4}", arr[i, j]);
                  
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите N: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите M: ");
            int m = int.Parse(Console.ReadLine());
            int[,] arr = new int[n,m];
            Random r = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                   
                        arr[i, j] = r.Next(100);
                   
                }

            }
            ShowArray(arr);
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {

                    if ((i+j) % 2 ==0)
                    {
                        Console.WriteLine("Элемент стоящий на четной позиции {0}",arr[i, j]);
                        sum += arr[i, j];
                    }

                }

            }
            Console.WriteLine("Сумма элементов стоящих на четных позициях: {0}", sum);
            Console.ReadKey();
        }
    }
}
