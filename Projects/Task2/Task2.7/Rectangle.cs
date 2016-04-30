using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._7
{
    class Rectangle : Figure, IGiveArea, IGiveLengths
    {
        private double width;
        private double height;

        public double Width
        {
            get { return width; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                width = value;
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                height = value;
            }
        }

        public Rectangle(double x, double y, double height, double width)
        {
            X = x;
            Y = y;
           this.height = height;
            this.width = width;
        }

        public override void Draw()
        {
            Console.WriteLine("Прямоугольник {0} {1} {2} {3}", X, Y, height, width);
        }

        public virtual double Length()
        {
            return (width + height) * 2;
        }


        public double Area()
        {
            return width * height;
        }
    }
}
