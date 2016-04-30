using System;

namespace Task4_1
{
    public class Program
    {
        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        public static void Sort<T>(T[] arr, Func<T, T, int> compare)
        {
            Qs(arr, 0, arr.Length - 1, compare);
        }

        public static void Qs<T>(T[] arr, int first, int last, Func<T, T, int> compare)
        {
            int i = first, j = last;
            T x = arr[(first + last) / 2];
            do
            {
                while (compare(arr[i], x) < 0)
                {
                    i++;
                }

                while (compare(arr[j], x) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    if (i < j)
                    {
                        Swap(ref arr[i], ref arr[j]);
                        i++;
                        j--;
                    }
                }
            }
            while (i < j);
            if (i < last)
            {
                Qs(arr, i, last, compare);
            }

            if (first < j)
            {
                Qs(arr, first, j, compare);
            }
        }

        public static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 2, 1 };
            ////string[] arr = { "123", "jkl", "1234" };
            ////for (int i = 0; i < arr.Length; i++)
            ////{
            ////    Console.WriteLine(arr[i].ToString(), " ");
            ////}
            ////Sort(arr, (s1, s2) => s1.Length - s2.Length);
            Sort(arr, (s1, s2) => s1 - s2);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i] + " ");
            }
        }
    }
}
