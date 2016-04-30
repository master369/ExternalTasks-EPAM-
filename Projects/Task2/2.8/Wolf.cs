using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8
{
    class Wolf: Monster
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


        private Field f;

        public Wolf(ref Field field, int x, int y)
        {
            f = field;
            X = x;
            Y = y;
            field[x, y] = 4;
        }

        private void Move(ref Field f, int x, int y)
        {
            if (this.x > 0 && this.y > 0 || this.x < f.Width && this.y < f.Height) //если монстр не упал с площадки
            {
                switch (f[x, y])
                {
                    case 0:
                        {
                            Jump(f, x, y);
                        } break;
                    case 1://яблоко
                        {
                            Jump(f, x, y);

                        } break;
                    case 2://вишня
                        {
                            Jump(f, x, y);
                        } break;
                    case 3://стена
                        {

                        } break;
                    case 4://монстр
                        {
                        } break;
                    case 5://игрок
                        {
                            Console.WriteLine("Game over");
                            //удаляем угрока
                        } break;
                    default:
                        break;
                }
            }
            else
            {
                //Jump(f, x, y);
                f[this.x, this.y] = 0; //ушли с позиции
                //удаляем монстра
            }
        }

        private void Jump(Field f, int x, int y)
        {
            f[this.x, this.y] = 0; //ушли с позиции
            f[x, y] = 4; //перешли
            X = x;
            Y = y;
        }

        public void Up()
        {
            Move(ref f,X,Y+1);
        }

        public void Down()
        {
            Move(ref f, X, Y - 1);
        }

        public void Left()
        {
            Move(ref f, X - 1, Y);
        }

        public void Right()
        {
            Move(ref f, X + 1, Y);
        }
    }
}
