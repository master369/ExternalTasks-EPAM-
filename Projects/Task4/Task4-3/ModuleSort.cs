using System;
using System.Threading;

namespace Task4_3
{
    public class ModuleSort<T>
    {
        public event EventHandler<SortFinishedEventArgs<T>> Finished;

        public static void Swap(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        public static void Qs(T[] arr, int first, int last, Func<T, T, int> compare)
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
            {
                if (i < last)
                {
                    Qs(arr, i, last, compare);
                }

                if (first < j)
                {
                    Qs(arr, first, j, compare);
                }
            }
        }

        public void SortInSeparateThread(T[] arr, Func<T, T, int> compare)
        {
            var thread = new Thread(
                () =>
                {
                    Sort(arr, compare);
                    OnCompleted(new SortFinishedEventArgs<T>(arr));
                });
            thread.Start();
        }

        internal static void Sort(T[] arr, Func<T, T, int> compare)
        {
            Qs(arr, 0, arr.Length - 1, compare);
        }

        protected void OnCompleted(SortFinishedEventArgs<T> e)
        {
            if (this.Finished != null)
            {
                this.Finished(this, e);
            }
        }
    }
}
