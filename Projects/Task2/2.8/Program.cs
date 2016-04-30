using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8
{//большееееееееееее
    class Program
    {
        static void Main(string[] args)
        {
            
            Field field = new Field();
            Gamer name1 = new Gamer(field);
            //Console.WriteLine(name1.Health);
            //Console.WriteLine(field[1, 1]);
            Wolf wolf = new Wolf(ref field, 3, 3);
            //field.Show();
            name1.Left();
            field.Show();
            



            
        }
    }
}
