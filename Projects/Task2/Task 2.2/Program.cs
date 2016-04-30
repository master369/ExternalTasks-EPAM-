using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._2
{
    class Program
    {
        static int Input(out double a, out double b, out double c)
        {
            a = double.Parse(Console.ReadLine());
            b = double.Parse(Console.ReadLine());
            c = double.Parse(Console.ReadLine());
            return 0;
        }
        static void Main(string[] args)
        {
            double a, b, c;
            try
            {
                Console.WriteLine("Введите A, B, C: ");
                Input(out a, out b, out c);
                Triangle Triangle1 = new Triangle(a, b, c);
                //Triangle1.A = 0;
                Console.WriteLine("\nДлина периметр и площадь треугольника: {0} {1}", Triangle1.Length(), Triangle1.Area());
                Console.WriteLine("{0}", Triangle1.A);
            }
            catch (Exception)
            { }
        }
    }
}