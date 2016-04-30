using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._7
{
    class Circle : Figure, IGiveLengths
    {
        private double r;

        public virtual double Radius
        {
            get
            {
                return r;
            }
            set
            {
                if (value > 0)
                    r = value;
                else
                {
                    throw new ArgumentException("Ошибка! Радиус должен быть больше нуля!!!");
                }

            }
        }

        public Circle(double x, double y, double r)
        {
            X = x;
            Y = y;
            Radius = r;
        }

        public virtual double Length()
        {
            return 2 * Math.PI * Radius;
        }

        public override void Draw()
        {
            Console.WriteLine("Окружность {0} {1} {2}", X, Y, Radius); ;
        }

        
    }
}
