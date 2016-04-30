using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._6
{
    public class Ring
    {  //поля заприватить и проверки
      
        private Round INR;
        private Round OUTR;
        public int x { get; set; }
        public int y { get; set; }

        public Ring(int x,int y,int innerR,int outerR )
        {
            if (innerR <0 && outerR<0)
            {
                throw new ArgumentException();
            }
            INR = new Round(x, y, innerR);
            OUTR = new Round(x, y, outerR);
        }

        public int innerR
        {
            get { return INR.Radius; }
            set
            {
                if (value > OUTR.Radius)
                {
                    throw new ArgumentException();
                }
                INR.Radius = value;
            }
        }


        public int outterR
        {
            get { return OUTR.Radius; }
            set
            {
                if (value < INR.Radius)
                {
                    throw new ArgumentException();
                }
                OUTR.Radius = value;
            }
        }

        public double Area
        {
            get
            {
                return OUTR.GetArea() - INR.GetArea();
            }
        }

    }
}
