using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task3._4
{
    class DynamicArray<T> : ICloneable, IEnumerable<T>, IEnumerator<T>
    {
        private int length;
        private int position = -1;
        public int Count { get; private set; }
        protected T[] dynamicArray = new T[0];

        protected int ConvertToPlus(int i)
        {
            if (i < 0) i = length + (i);
            return i;
        }

        protected bool OutOfRange(int i)
        {
            return i > length;
        }
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

                ResizeArray(ref  dynamicArray, dynamicArray.Length, value);

                this.length = dynamicArray.Length / 2;
            }
        }

        public T Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        object IEnumerator.Current
        {
            get
            {
                throw new NotImplementedException();
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

        public DynamicArray(T[] DList)
        {
            Capacity = Capacity * 2;
            int j = 0;
            foreach (T i in DList)
            {
                dynamicArray[j++] = i;

            }
        }

 

        private void ResizeArray(ref T[] Arr, int oldCapacity, int newCapacity)
        {
            var bufferArray = new T[oldCapacity];
            for (int i = 0; i < oldCapacity; i++)
                bufferArray[i] = Arr[i];

            Arr = new T[newCapacity];

            if (oldCapacity < newCapacity)
                for (int i = 0; i < oldCapacity; i++)
                    Arr[i] = bufferArray[i];
            else
                for (int i = 0; i < newCapacity; i++)
                    Arr[i] = bufferArray[i];
            length = newCapacity / 2;
        }

        public void Add(T a)
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


        public bool Remove(T value)
        {
            int firstIndex = FirstIndex(value);
            if (firstIndex >= 0)
            {
                for (int i = firstIndex; i < length; i++)
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

            if (pos == length + 1)
            {
                Add(x);
            }

            if (length >= Capacity)
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

        public int FirstIndex(T x)
        {
            for (int i = 0; i <= length; i++)
            {
                if (Equals(dynamicArray[i], x))
                {
                    return i;
                }
            }

            return -1;
        }

        public T[] ToArray()
        {
            return dynamicArray;
        }

        public DynamicArray<T> Clone()
        {
            var clonedArray = new DynamicArray <T>(dynamicArray);

            return clonedArray;
        }

       IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < length; i++)
            {
                yield return dynamicArray[i];
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i <= length; i++)
            {
                if (Equals(dynamicArray[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void RemoveAt(int index)
        {
            int firstIndex = index;
            if (firstIndex >= 0)
            {
                for (int i = firstIndex; i < length; i++)
                {
                    dynamicArray[i] = dynamicArray[i + 1];
                }
                length--;
            }
        }

        public T this[int index]
        {
            get
            {
                index = ConvertToPlus(index);
                return dynamicArray[index];
            }
            set
            {
                index = ConvertToPlus(index);
                dynamicArray[index] = value;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (var item in this)
            {
                yield return item;
            }
        }

        object ICloneable.Clone()
        {
            return dynamicArray.Clone();
        }

        private int currentCounter = -1;
   
        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            currentCounter++;
            if (currentCounter >= Count)
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
    }
}
