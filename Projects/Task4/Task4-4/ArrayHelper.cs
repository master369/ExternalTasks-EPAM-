using System;

namespace Task4_4
{ 
    public static class ArrayHelper
    {
        public static int Sum(this int[] arr)
        {
            return Sum(arr, (a, b) => a + b);
        }

        public static uint Sum(this uint[] arr)
        {
            return Sum(arr, (a, b) => a + b);
        }

        public static long Sum(this long[] arr)
        {
            return Sum(arr, (a, b) => a + b);
        }

        public static ulong Sum(this ulong[] arr)
        {
            return Sum(arr, (a, b) => a + b);
        }

        public static decimal Sum(this decimal[] arr)
        {
            return Sum(arr, (a, b) => a + b);
        }

        public static short Sum(this short[] arr)
        {
            return Sum(arr, (a, b) => (short)(a + b));
        }

        public static ushort Sum(this ushort[] arr)
        {
            return Sum(arr, (a, b) => (ushort)(a + b));
        }

        public static byte Sum(this byte[] arr)
        {
            return Sum(arr, (a, b) => (byte)(a + b));
        }

        public static sbyte Sum(this sbyte[] arr)
        {
            return Sum(arr, (a, b) => (sbyte)(a + b));
        }

        public static double Sum(this double[] arr)
        {
            return Sum(arr, (a, b) => a + b);
        }

        public static float Sum(this float[] arr)
        {
            return Sum(arr, (a, b) => a + b);
        }

        private static T Sum<T>(this T[] arr, Func<T, T, T> add)
        {
            var sum = default(T);
            foreach (var item in arr)
            {
                sum = add(sum, item);
            }

            return sum;
        }
    }
}