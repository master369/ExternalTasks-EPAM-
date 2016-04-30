using System;

namespace Task4_3
{
    public class Program
    {
        private static bool done;
        private static int[] arr = new int[30];

        public static int Compare(int first, int second)
        {
            return first - second;
        }

        public static void Main(string[] args)
        {
            WriteArrayRandomly(arr);
            ShowArray(arr);
            var sorter = new ModuleSort<int>();
            sorter.Finished += Sorter_Finished;
            sorter.SortInSeparateThread(arr, Compare);
            ////ShowArray(arr);
        }

        public static void Sorter_Finished(object sender, SortFinishedEventArgs<int> e)
        {
            Console.WriteLine("Finished sorting!");
            ShowArray(arr);
        }

        private static void ShowArray<T>(T[] arr)
        {
            Console.WriteLine("Conclusion of the array:");
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("_______________________");
        }

        private static void WriteArrayRandomly(int[] arr)
        {
            var rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(1000);
            }
        }
    }
}
