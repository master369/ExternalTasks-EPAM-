using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2._3;

namespace Task2._5
{
    class Program
    {
        static void Main(string[] args)
        {
            User a = new User();
            Console.WriteLine("Name = {0}, Surname = {1}, Secondname = {2}", a.NAME, a.SURNAME, a.SECONDNAME);

            DateTime day = new DateTime(1995, 10, 05);
            Employee user = new Employee("Anton", "Ilyin", "Sergeevich", day, "Junior", 5);
            Console.WriteLine("Name = {0}, Surname = {1}, Secondname = {2}, birthday = {3}, Age = {4}, Post = {5}, Exp = {6}", user.NAME, user.SURNAME, user.SECONDNAME, user.Birthday, user.AGE, user.POST, user.EXP);
        }
    }
}
