using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2._7
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите количество фигур ");
                int n = int.Parse(Console.ReadLine());
                int _type;
                double x;
                double y;
                double x1;
                double y1;
                double height;
                double width;
                double r;
                double r1;


                Figure[] figures = new Figure[n];

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Выберите тип фигуры:");
                    Console.WriteLine("         1. Линия");
                    Console.WriteLine("         2. Окружность");
                    Console.WriteLine("         3. Прямоугольник");
                    Console.WriteLine("         4. Круг");
                    Console.WriteLine("         5. Кольцо");
                    _type = int.Parse(Console.ReadLine());


                    Console.Write("Введите координаты фигуры ");

                    switch (_type)
                    {
                        case 1:
                            {
                                Console.WriteLine(" (начала и конца): ");
                                Console.Write("Введите х ");
                                x = double.Parse(Console.ReadLine());
                                Console.Write("Введите y ");
                                y = double.Parse(Console.ReadLine());
                                Console.Write("Введите х1 ");
                                x1 = double.Parse(Console.ReadLine());
                                Console.Write("Введите y1 ");
                                y1 = double.Parse(Console.ReadLine());
                                figures[i] = new Line(x, y, x1, y1);
                            } break;
                        case 2:
                            {
                                Console.WriteLine("и радиус: ");
                                Console.Write("Введите х ");
                                x = double.Parse(Console.ReadLine());
                                Console.Write("Введите y ");
                                y = double.Parse(Console.ReadLine());
                                Console.Write("Введите r ");
                                r = double.Parse(Console.ReadLine());
                                figures[i] = new Circle(x, y, r);
                            } break;
                        case 3:
                            {
                                Console.WriteLine(", а также ширину и высоту: ");
                                Console.Write("Введите х ");
                                x = double.Parse(Console.ReadLine());
                                Console.Write("Введите y ");
                                y = double.Parse(Console.ReadLine());
                                Console.Write("Введите height ");
                                height = double.Parse(Console.ReadLine());
                                Console.Write("Введите width ");
                                width = double.Parse(Console.ReadLine());
                                figures[i] = new Rectangle(x, y, height, width);
                            } break;
                        case 4:
                            {
                                Console.WriteLine("и радиус: ");
                                Console.Write("Введите х ");
                                x = double.Parse(Console.ReadLine());
                                Console.Write("Введите y ");
                                y = double.Parse(Console.ReadLine());
                                Console.Write("Введите r ");
                                r = double.Parse(Console.ReadLine());
                                figures[i] = new Round(x, y, r);
                            } break;
                        case 5:
                            {
                                Console.WriteLine("внутренний и внешний радиусы: ");
                                Console.Write("Введите х ");
                                x = double.Parse(Console.ReadLine());
                                Console.Write("Введите y ");
                                y = double.Parse(Console.ReadLine());
                                Console.Write("Введите inR ");
                                r = double.Parse(Console.ReadLine());
                                Console.Write("Введите outR ");
                                r1 = double.Parse(Console.ReadLine());
                                figures[i] = new Ring(x, y, r, r1);
                            }
                            break;
                        default: break;
                    }

                }

                Console.WriteLine("Список фигур:");
                for (int i = 0; i < n; i++)
                {
                    Console.Write("\t");
                    figures[i].Draw();
                }
            }
            catch (Exception) { }


        }
    }
}
