using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._1
{
    public class Round
    {
        public int X { get; set; }
        public int Y { get; set; }

        private int r;

        public int Radius
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

        public Round (int x, int y, int r)
        {
            X = x;
            Y = y;
            Radius = r;

        }

        

        public double GetLength()
        {
            return 2 * Math.PI * Radius;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
