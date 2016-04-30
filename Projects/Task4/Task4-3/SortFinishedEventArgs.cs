using System;

namespace Task4_3
{
    public class SortFinishedEventArgs<T> : EventArgs
    {
        public SortFinishedEventArgs(T[] arr)
        {
            this.Arr = arr;
        }

        public T[] Arr { get; private set; }
    }
}