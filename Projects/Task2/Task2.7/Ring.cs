using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._7
{
    class Ring : Figure, IGiveArea, IGiveLengths
    {
        private double r_out;
        private double r_in;

        public override void Draw()
        {
            Console.WriteLine("Кольцо {0} {1} {2} {3}", X, Y, R_in, R_out);
        }

        public Ring(double x, double y, double r_in, double r_out)
        {
            if (r_in < r_out)
            {
                X = x;
                Y = y;
                this.r_in = r_in;
                this.r_out = r_out;
            }
            else
                throw new ArgumentException("Ошибка! Внутренний радиус должен быть строго меньше внешнего!");
        }
        
        public double R_in
        {
            get
            {
                return r_in;
            }

            set
            {
                if (value >= this.r_out)
                {
                    throw new ArgumentException("Ошибка! Внутренний радиус должен быть строго меньше внешнего!");
                }

                r_in = value;
            }
        }

        public double R_out
        {
            get
            {
                return r_out;
            }

            set
            {
                if (value <= this.r_in)
                {
                    throw new ArgumentException("Ошибка! Внешний радиус должен быть строго больше внутреннего!");
                }

                r_out = value;
            }
        }

        public double Length()
        {
            return 2 * Math.PI * (this.R_out + R_in);
        }

        public double Area()
        {
            return Math.PI * (this.R_out * this.R_out - R_in * R_in);
        }
    }
}
