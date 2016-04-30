using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._1
{
    class Program
    {
        static void Main(string[] args)
        {

            Round round = new Round(5, 4, 3);
            Console.WriteLine("x = {0}, y = {1}, radius = {2} ", round.X, round.Y, round.Radius);
            Console.WriteLine("Length = {0}", round.GetLength());
            Console.WriteLine("Area = {0}", round.GetArea());
            round.Radius = 8;
            Console.WriteLine("x = {0}, y = {1}, radius = {2} ", round.X, round.Y, round.Radius);
            Console.WriteLine("Length = {0}", round.GetLength());
            Console.WriteLine("Area = {0}", round.GetArea());
        }
    }
}
