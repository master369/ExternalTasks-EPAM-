using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._7
{
    class Line : Figure, IGiveLengths
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }

        public Line(double x1, double y1, double x2, double y2)
        {
            X = x1;
            Y = y1;
            X1 = x2;
            Y1 = y2;
        }

        public virtual double Length()
        {
            return Math.Sqrt((X1*X1 - X*X)+ (Y1*Y1 - Y*Y));
        }

        public override void Draw()
        {
            Console.WriteLine("Линия {0} {1} {2} {3}", X, Y, X1, Y1);
        }
    }
}
