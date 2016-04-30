using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._8
{
    class Program
    {
        static void ShowArray(int[,,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        Console.Write("{0,4}", arr[i, j, k]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
            static void NoPositive (int[,,] arr)
        {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        for (int k = 0; k < arr.GetLength(2); k++)
                        {
                        if (arr[i, j, k]> 0)
                        {
                            arr[i, j, k] = 0;
                        }
                            
                        }
                      
                    }
                   
                }


            }

            static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива: ");
            int n = int.Parse(Console.ReadLine());
            int[,,] arr = new int [n,n,n];
            Random r = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        arr[i,j,k] = r.Next(-99,99);
                    }

                }
              
            }
            ShowArray(arr);
            NoPositive(arr);
            Console.WriteLine("Измененнный массив");
            ShowArray(arr);
        }
    }
}
