using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._6
{
    class Program
    {
        [Flags]
        public enum Font
        {
            None = 0x00,
            Bold = 0x01,
            Italic = 0x02,
            Underline = 0x04,
        }

        static void Main(string[] args)
        {
            Font currentFont = 0x00;
            ConsoleKeyInfo key;

            do
            {
                Console.Write("Параметры надписи: ");
                Console.WriteLine(currentFont);

                Console.WriteLine("Введите:");
                Console.WriteLine("\t 1: bold");
                Console.WriteLine("\t 2: italic");
                Console.WriteLine("\t 3: underline");
                Console.WriteLine("\t Esc: выход");

                key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.D1: currentFont ^= Font.Bold; break;
                    case ConsoleKey.D2: currentFont ^= Font.Italic; break;
                    case ConsoleKey.D3: currentFont ^= Font.Underline; break;
                    default:
                        break;
                }


            } while (key.Key != ConsoleKey.Escape);
        }
    }
}
