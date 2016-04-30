using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Введите строку(а) =  ");
            MyString a = new MyString(Console.ReadLine());
            Console.Write("Введите строку(b) =  ");
            MyString b = new MyString(Console.ReadLine());
            MyString c = a.Remove(4);
            Console.WriteLine("a.Remove(2) = {0}", c.Arr);
            MyString z = new MyString();
            z = a.Insert(2, b);
            Console.WriteLine("a.Insert(2,b) = {0}", z.Arr);
            int comp = MyString.Compare(a, b, false);
            Console.WriteLine("Compare(a,b,false) = {0}", comp);
            Console.WriteLine("a.CompareTo(b) = {0}", a.CompareTo(b));
            MyString zz = MyString.Copy(a);
            Console.WriteLine("copy(a) = {0}", zz.Arr);

        }
    }
}
