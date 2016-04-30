using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2._3;

namespace Task2._5
{
    public class Employee : User
    {
        private string post;
        private int exp;

        public string Post
        {
            get { return post; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception();
                }
                post = value;
            }
        }
        public int Exp
        {
            get { return exp; }
            set
            {
                exp = value;
            }
        }

        public Employee(string name, DateTime birthday, string post, int exp) : base(name, birthday)
        {
            if (exp < AGE - 14 && exp >= 0 && AGE > 14)
            {
                this.Post = post;
                this.Exp = exp;
            }
        } 
    

        public Employee(string name, string surname, DateTime birthday,string post, int exp) : base(name, surname, birthday)
        {
            if (exp<AGE - 14 && exp >= 0 && AGE> 14)
            {
                this.Post = post;
                this.Exp = exp;
            }
        }

        public Employee(string name, string surname, string secondname, DateTime birthday, string post, int exp) : base(name, surname, secondname, birthday)
        {
            if (exp < AGE - 14 && exp >= 0 && AGE > 14)
            {
                this.Post = post;
                this.Exp = exp;
            }
        }


    }
}
