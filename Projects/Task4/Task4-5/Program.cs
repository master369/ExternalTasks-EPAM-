using System;
using System.Linq;

namespace Task4_5
{
    public class Program
    {
        public static void Main()
        {
            byte i = 1;
            while (i != 0)
            {
                Console.Write("Введите строку для проверки ее на положительное челое число: ");
                string str = Console.ReadLine();
                if (str.IsNumber())
                {
                    Console.WriteLine("Строка число.");
                }
                else
                {
                    Console.WriteLine("Строка не число.");
                }

                Console.WriteLine("Проверить еще 1 строку? \r\n 0 - нет    1 - да");
                byte.TryParse(Console.ReadLine(), out i);
            }

            Console.ReadKey();
        }
    }
}
