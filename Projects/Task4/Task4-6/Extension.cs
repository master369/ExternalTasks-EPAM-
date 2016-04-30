using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_6
{
    public static class Extension
    {
        public static IEnumerable<T> FindAllNeeded<T>(this T[] arr, Predicate<T> condition)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (condition(arr[i]))
                {
                    yield return arr[i];
                }
            }
        }

        public static IEnumerable<int> FindAllPositive(this int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    yield return arr[i];
                }
            }
        }
    }
}