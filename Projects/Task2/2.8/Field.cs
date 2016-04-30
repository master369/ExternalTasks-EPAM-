using System;
using System.IO;
using System.Linq;

namespace _2._8
{
    class Field
    {
        private int width;
        private int height;
        private int[,] field; 

        public Field()
        {
            using (StreamReader fileInput = new StreamReader("input.txt"))
            {
                width = int.Parse(fileInput.ReadLine());
                height = int.Parse(fileInput.ReadLine());
                string[] mas;
                field = new int[width, height];
                for (int i = 0; i < width; i++)
                {
                    string line = fileInput.ReadLine();
	                mas = line.Split(' ');
                    for (int j = 0; j < height; j++)
                    {
                        field[i, j] = int.Parse(mas[j]);
                    }

                }
            }
        }
        public int Width 
        { 
            get
            {
                return width;
            }  
        }
        public int Height
        {
            get
            {
                return height;
            }
        }

        public void Show()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Console.Write(field[i,j]);   
                }
                Console.WriteLine();
            }
        }

        public int this[int i, int j]
        {
            get
            {
                return field[i, j];
            }
            set
            {
                field[i, j] = value;
            }
        }



    }
}
