using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._4
{
    class MyString
    { 
        // больше логических операций
        // не все перегрузки
        private char[] arr;


        public MyString()
        {
            arr = null;
        }

        public override string ToString()
        {
            return new String(arr);
        }

        public MyString(String str)
        {
            arr = str.ToCharArray();
        }

        public String Arr
        {
            get
            {
                return new String(arr);
            }
            set
            {
                arr = value.ToCharArray();
            }
        }
        public int Length
        {
            get { return arr.Length; }
        }

        public char this[int i]
        {
            get
            {
                return arr[i];
            }

            set
            {
                arr[i] = value;
            }
        }

        public static int Compare(MyString strA, MyString strB, bool ignoreCase)
        {
            if (ignoreCase)
            {
                if (strA.Length == strB.Length)
                {
                    for (int i = 0; i < strA.Length; i++)
                    {
                        if (strA[i] != strB[i])
                        { return -1; }
                    }
                    return 0;
                }
                else { return (strA.Length < strB.Length) ? -1 : 1; }
            }

            else
            {
                if (strA.Length == strB.Length)
                {
                    for (int i = 0; i < strA.Length; i++)
                    {
                        if (strA[i] != strB[i] && Char.ToUpper(strB[i]) != Char.ToUpper(strA[i]))
                        { return -1; }
                    }
                    return 0;
                }
                else { return (strA.Length < strB.Length) ? -1 : 1; }

            }
        }
        public int CompareTo(MyString strB)
        {
            if (Length == strB.Length)
            {
                for (int i = 0; i < Length; i++)
                {
                    if (this[i] != strB[i])
                    {
                        return (this[i] < strB[i]) ? -1 : 1;
                    }
                }
                return 0;
            }
            else
            {
                return (Length < strB.Length) ? -1 : 1;
            }
        }

        public static MyString Copy(MyString str)
        {
            return new MyString(str);
        }


        public MyString Remove(int index)
        {
            if (index >= 0 && index < arr.Length)
            {
                char[] temp = new char[index];
                Array.Copy(arr, temp, index);
                return new MyString(new String(temp));
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public MyString Insert(int index, MyString str)
        {
            if (str.arr != null)
            {
                if (index >= 0 && index < arr.Length)
                {
                    char[] temp = new char[arr.Length + str.arr.Length];
                    Array.Copy(arr, temp, index);
                    Array.Copy(str.arr, 0, temp, index, str.arr.Length);
                    Array.Copy(arr, index, temp, str.arr.Length + index, arr.Length - index);
                    return new MyString(new String(temp));
                }
                else { throw new ArgumentOutOfRangeException(); }
            }
            else { throw new ArgumentNullException(); }
        }

        public static implicit operator String(MyString a)
        {
            return new String(a.arr);
        }


        public static explicit operator MyString(String a)
        {
            return new MyString(a);
        }

        public static bool operator ==(MyString a, MyString b)
        {
            return (a.CompareTo(b) == 0) ? true : false;
        }

        public static bool operator ==(MyString a, String b)
        {
            return (a.CompareTo(new MyString(b)) == 0) ? true : false;
        }

        public static bool operator ==(String a, MyString b)
        {
            return (new MyString(a).CompareTo(b) == 0) ? true : false;
        }

        public static bool operator !=(MyString a, MyString b)
        {
            return !(a == b);
        }

        public static bool operator !=(MyString a, String b)
        {
            return !(a == b);
        }

        public static bool operator !=(String a, MyString b)
        {
            return !(a == b);
        }
        public override int GetHashCode()
        {
            return arr.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public static bool operator >(MyString a, MyString b)
        {
            return (a.Length > b.Length) ? true : false;
        }
        public static bool operator <(MyString a, MyString b)
        {
            return (a.Length < b.Length) ? true : false;
        }

        public static bool operator >=(MyString a, MyString b)
        {
            return (a.Length >= b.Length) ? true : false;
        }
        public static bool operator <=(MyString a, MyString b)
        {
            return (a.Length <= b.Length) ? true : false;
        }

      

    }
}
