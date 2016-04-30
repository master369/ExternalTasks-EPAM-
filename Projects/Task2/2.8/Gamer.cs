using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8
{
    class Gamer: Unit, IMove
    {
        private int health;

        public int Health
        {
            get
            {
                return health;
            }
        }

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        private Field f;


        private void Move(Field f, int x, int y)
        {
            if (x > 0 && y > 0 || x < f.Width && y < f.Height) //если игрок не упал с площадки
            {
                switch (f[x, y])
                {
                    case 0:
                        {//у каждого бонуса должен быть метод, определяющий, что будет делать игрок или монстр
                            Jump(f, x, y);
                        } break;
                    case 1://яблоко
                        {
                            Jump(f, x, y);
                            health *= 2;

                        } break;
                    case 2://вишня
                        {
                            Jump(f, x, y);
                            health += 50;

                        } break;
                    case 3://стена
                        {
                            health -= 20;

                        } break;
                    case 4://монстр
                        {
                            health -= 100;

                        } break;
                    case 5://игрок
                        {//пока неизвестно
                        } break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Game over");
                //удаляем угрока
            }
        }

        private void Jump(Field f, int x, int y)
        {
            f[X, Y] = 0; //ушли с позиции
            f[x, y] = 5; //перешли
            X = x;
            Y = y;
        }

        public void Up()
        {
            Move(f, X, Y + 1);
        }

        public void Down()
        {
            Move(f, X, Y - 1);
        }

        public void Left()
        {
            Move(f, X - 1, Y);
        }

        public void Right()
        {
            Move(f, X + 1, Y);
        }

        public Gamer(Field field)
        {
            f = field;
            health = 100;
            for (int i = 0; i < field.Width; i++)
                for (int j = 0; j < field.Height; j++)
                    if (f[i,j] == 5)
                    {
                        X = i;
                        Y = j;
                        break;
                    }

        }

        public bool GameOver()
        {
            return (health <= 0);
        }
    }
}
