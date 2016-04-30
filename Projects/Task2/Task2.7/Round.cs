using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._7
{
    class Round : Circle, IGiveArea
    {
        public Round(double x, double y, double r)
            : base(x,y,r)
        {
        
        }

        

        public double Area()
        {
            return Math.PI * Radius * Radius;
        }

        public override void Draw()
        {
            Console.WriteLine("Круг {0} {1} {2}", X, Y, Radius);
        }
    }
}
