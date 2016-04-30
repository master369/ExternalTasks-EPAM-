using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            User a = new User();
            //Console.WriteLine("Name = {0}, Surname = {1}, Secondname = {2}", a.Name, a.Surname, a.SecondName);

            DateTime day = new DateTime(1995, 10, 05);
            User user = new User("Anton", "ilin", "Sergeevich", day);
            Console.WriteLine("Name = {0}, Surname = {1}, Secondname = {2}, birthday = {3}, Age = {4}",user.NAME,  user.SURNAME, user.SECONDNAME, user.Birthday, user.AGE);


        }
    }
}
