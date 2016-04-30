using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Task4_6
{
    public class Program
    {
        public static int[] CreateArray()
        {
            int n = 500;
            if (/*int.TryParse(Console.ReadLine(), out n)*/n == 500)
            {
                int[] array = new int[n];

                Random r = new Random();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = r.Next(int.MinValue, int.MaxValue);
                }

                return array;
            }
            else
            {
                throw new InvalidCastException("Неверно введен размер массива");
            }
        }

        public static double FindPositiveElements(Stopwatch sw, int[] array)
        {
            double[] arrTester = new double[1001];
            for (int i = 0; i < arrTester.Length; i++)
            {
                sw.Start();
                Extension.FindAllPositive(array).ToArray();
                sw.Stop();
                arrTester[i] = sw.Elapsed.TotalMilliseconds;
            }

            Array.Sort(arrTester);
            sw.Reset();
            return arrTester[arrTester.Length / 2];
        }

        public static double StartTest(Stopwatch sw, int[] arr, Predicate<int> pred)
        {
            double[] arrTester = new double[1001];
            for (int i = 0; i < arrTester.Length; i++)
            {
                sw.Start();
                Extension.FindAllNeeded(arr, pred).ToArray();
                sw.Stop();
                arrTester[i] = sw.Elapsed.TotalMilliseconds;
            }

            Array.Sort(arrTester);
            sw.Reset();
            return arrTester[arrTester.Length / 2];
        }

        public static double StartTestForLinq(Stopwatch sw, int[] arr)
        {
            ////var allPositive = arr.Where(x => x > 0);
            var allPositive = from item in arr
                              where item > 0
                              select item;
            double[] arrTester = new double[1001];

            for (int i = 0; i < arrTester.Length; i++)
            {
                sw.Start();
                allPositive.ToArray();
                sw.Stop();
                arrTester[i] = sw.Elapsed.TotalMilliseconds;
            }

            Array.Sort(arrTester);
            sw.Reset();
            return arrTester[arrTester.Length / 2];
        }

        public static bool Condition(int item)
        {
            return item > 0;
        }

        public static void Main()
        {
            double[] poisk = new double[50];
            double[] poiskDelegate = new double[50];
            double[] poiskAnon = new double[50];
            double[] poiskLAmbda = new double[50];
            double[] poiskLINQ = new double[50];
            var sw = new Stopwatch();
            for (int i = 0; i < 50; i++)
            {
                var array = CreateArray();
                poisk[i] = FindPositiveElements(sw, array);
                Predicate<int> pred = Condition;
                poiskDelegate[i] = StartTest(sw, array, pred);
                Predicate<int> predAnon = delegate(int x) { return x > 0; };
                poiskAnon[i] = StartTest(sw, array, predAnon);
                Predicate<int> predLambda = (int x) => { return x > 0; };
                poiskLAmbda[i] = StartTest(sw, array, predLambda);
                poiskLINQ[i] = StartTestForLinq(sw, array);
            }

            Console.WriteLine("Test (directly):");
            Array.Sort(poisk);
            Console.WriteLine("Milliseconds: {0}", poisk[poisk.Length / 2]);
            Console.WriteLine("Test (delegate):");
            Array.Sort(poiskDelegate);
            Console.WriteLine("Milliseconds: {0}", poiskDelegate[poiskDelegate.Length / 2]);
            Console.WriteLine("Test (Anon. method):");
            Array.Sort(poiskAnon);
            Console.WriteLine("Milliseconds: {0}", poiskAnon[poiskAnon.Length / 2]);
            Console.WriteLine("Test (Lambda):");
            Array.Sort(poiskLAmbda);
            Console.WriteLine("Milliseconds: {0}", poiskLAmbda[poiskLAmbda.Length / 2]);
            Console.WriteLine("Test (LINQ):");
            Array.Sort(poiskLINQ);
            Console.WriteLine("Milliseconds: {0}", poiskLINQ[poiskLINQ.Length / 2]);
            Console.ReadKey();
        }
    }
}