using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task3._3
{
    class DynamicArray<T> : IEnumerable, IEnumerable<T>
    {
        private int length;
        private int position = -1;
        protected object[] dynamicArray = new object[0];
        public int Count { get; private set; }
        public int Length
        {
            get
            {
                return length;
            }
        }

        public int Capacity
        {
            get
            {
                return dynamicArray.Length;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Error! Capacity <= 0!!!");

                ResizeArray(ref dynamicArray, dynamicArray.Length, value);

                this.length = dynamicArray.Length / 2;
            }
        }

        public DynamicArray()
        {
            length = 0;
            Capacity = 8;
        }

        public DynamicArray(int capacity)
        {
            this.length = 0;
            Capacity = capacity;
        }

        public DynamicArray(List<object> DList)
        {
            Capacity = DList.Capacity * 2;
            int j = 0;
            foreach (int i in DList)
            {
                dynamicArray[j++] = i;

            }
        }

        public void Add(T  a)
        {
            this.length++;
            if (length >= Capacity)
            {
                ResizeArray(ref dynamicArray, Capacity, Capacity * 2);
                Capacity *= 2;
            }

            dynamicArray[length - 1] = a;
        }

        public void AddRange(IEnumerable<T> DList)
        {
            if (Count > Capacity - Length)
            {
                int newCapacity = (Count + Capacity) * 2;
                ResizeArray(ref dynamicArray, Capacity, newCapacity);
            }
            int j = 0;
            foreach (T i in DList)
            {
                dynamicArray[j++] = i;
            }

        }

        public bool Remove(int value)
        {
            int firstIndex = FirstIndex(value);
            if (firstIndex >= 0)
            {
                for (int i = firstIndex; i < Length; i++)
                {
                    dynamicArray[i] = dynamicArray[i + 1];
                }
                length--;
                return true;
            }

            return false;
        }

        public bool Insert(T x, int pos)
        {
            if (OutOfRange(pos))
            {
                throw new ArgumentOutOfRangeException("Error! Out Of Range!");
            }

            if (pos == Length + 1)
            {
                Add(x);
            }

            if (Length >= Capacity)
            {
                ResizeArray(ref dynamicArray, Capacity, Capacity * 2);
            }

            for (int i = length; i > pos; i--)
            {
                dynamicArray[i] = dynamicArray[i - 1];
            }
            dynamicArray[pos] = x;
            length++;

            return true;
        }

        public int FirstIndex(object x)
        {
            for (int i = 0; i <= Length; i++)
            {
                if (Equals(dynamicArray[i], x))
                {
                    return i;
                }
            }

            return -1;
        }

        protected bool OutOfRange(int i)
        {
            return i > length;
        }

        public T this[int i]
        {
            get 
            {
                if (i < 0 && i > Length) { throw new IndexOutOfRangeException(); }
                return (T)dynamicArray[i]; 
            }
            set 
            {
                if (i < 0 && i > Length) { throw new IndexOutOfRangeException(); }
                dynamicArray[i] = value;
            }
        }


        private void ResizeArray(ref object[] Arr, int oldCapacity, int newCapacity)
        {
            var bufferArray = new object[oldCapacity];
            for (int i = 0; i < oldCapacity; i++)
                bufferArray[i] = Arr[i];

            Arr = new object[newCapacity];

            if (oldCapacity < newCapacity)
                for (int i = 0; i < oldCapacity; i++)
                    Arr[i] = bufferArray[i];
            else
                for (int i = 0; i < newCapacity; i++)
                    Arr[i] = bufferArray[i];
            length = newCapacity / 2;
        }



        private int currentCounter = -1;
        public T Current
        {
            get { return this [currentCounter]; }
        }



        public void Dispose()
        {
        }

      
        public bool MoveNext()
        {
            currentCounter++;
            if (currentCounter >= length)
            {
                Reset();
                return false;
            }
            return true;
        }

        public void Reset()
        {
            currentCounter = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < length; i++)
            {
                yield return dynamicArray[i];
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (var item in this)
            {
                yield return item;
            }
        }
    }
}
