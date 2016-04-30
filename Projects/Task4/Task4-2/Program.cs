using System;

namespace _5._2
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

        public static int Compare(string s1, string s2)
        {
            if
                (s1.Length != s2.Length)
            {
                return s1.Length - s2.Length;
            }
            else
            {
                for (int i = 0; i < s1.Length; i++)
                {
                    if (s1[i] == s2[i])
                    {
                        continue;
                    }

                    return s1[i] - s2[i];
                }
            }

            return 0;
        }

        public static void Sort<T>(T[] s_arr, Func<T, T, int> compare)
        {
            Qs(s_arr, 0, s_arr.Length - 1, compare);
        }

        public static void Qs<T>(T[] s_arr, int first, int last, Func<T, T, int> compare)
        {
            int i = first, j = last;
            T x = s_arr[(first + last) / 2];
            do
            {
                while (compare(s_arr[i], x) < 0)
                {
                    i++;
                }

                while (compare(s_arr[j], x) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    if (i < j)
                    {
                        Swap(ref s_arr[i], ref s_arr[j]);
                        i++;
                        j--;
                    }
                }
            }
            while (i < j);
            { 
            if (i < last)
            {
                Qs(s_arr, i, last, compare);
            }

            if (first < j)
            {
                Qs(s_arr, first, j, compare);
            }
        }
        }

        public static void Main(string[] args)
        {
            ////double[] arr = {1, 2, 3.34, 4, 2.34, 1 };
            string[] arr = { "22222", "11111", "111", "33333" };

            ////for (int i = 0; i < arr.Length; i++)
            ////{
            ////    Console.WriteLine(arr[i].ToString(), " ");
            ////}
            Sort(arr, Compare);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i] + " ");
            }

             Console.ReadLine();
        }
    }
}
