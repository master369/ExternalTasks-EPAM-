using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._12
{
    class Program
    {
        static void Main(string[] args)
        {
            string strFirst = "написать программу, которая ";
            StringBuilder sb = new StringBuilder(strFirst.Length);           
            string strSecond = "описание";
            for (int i = 0; i < strFirst.Length; i++)
            {
                sb.Append(strFirst[i]);
                if (strSecond.Contains(strFirst[i]))
                {
                    sb.Append(strFirst[i]);
                }
            }

            Console.WriteLine("Итог:{0}", sb.ToString());

            
         
           
        }
    }
}
