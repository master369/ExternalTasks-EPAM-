using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._2
{
    public class Triangle
    {
        private double a;
        private double b;
        private double c;

        public double A 

        {
            get
            {
                return a;
            }

            set
            {
                if (!(IsCorrectTriangle(value, b, c)))
                    throw new ArgumentException("Ошибка! Треугольника с такими сторонами не существует!!!");

                a = value;
            }
        }

        private static bool IsCorrectTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        public double B
        {
            get
            {
                return b;
            }

            set
            {
                if (value <= 0 || !(IsCorrectTriangle(a, value, c)))
                    throw new ArgumentException("Ошибка! Треугольника с такими сторонами не существует!!!");

                b = value;
            }
        }

        public double C
        {
            get
            {
                return c;
            }

            set
            {
                if (value <= 0 || !(IsCorrectTriangle(a, b, value)))
                    throw new ArgumentException("Ошибка! Треугольника с такими сторонами не существует!!!");

                c = value;
            }
        }

        public Triangle(double a, double b, double c)
        {
            SetSides(a, b, c);

        }

        public void SetSides(double a, double b, double c)
        {
            if (!(IsCorrectTriangle(a, b, c)))
                throw new ArgumentException("Ошибка! Треугольника с такими сторонами не существует!!!");

            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double Length()
        {
            return a + b + c;
        }

        public double Area()
        {
            double p = this.Length() / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

    }
}
