using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8
{
    class Stone: Obstacles
    {

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                    x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                    y = value;
            }
        }
    }
}
