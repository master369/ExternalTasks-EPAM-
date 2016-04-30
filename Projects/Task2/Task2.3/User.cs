using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2._3
{
    public class User
    {
        //поля заприватить и проверки

        private string name;
        private string surname;
        private string secondName;
        private DateTime birthDay;


        public string NAME
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception();
                }
                name = value;
            }
        }

        public string SURNAME
        {
            get { return surname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception();
                }
                surname = value;
            }
        }

        public string SECONDNAME
        {
            get { return secondName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception();
                }
                secondName = value;
            }
        }

        public User(string name, string surname, string secondName, DateTime birthday)
        {
            
                this.NAME = name;
                this.SURNAME = surname;
                this.SECONDNAME = secondName;
                this.Birthday = birthday;
    
        }

        public User(string name, DateTime birthday)
        {
               this.NAME = name;
               this.SURNAME = null;
               this.SECONDNAME = null;
                this.Birthday = birthday;
        
        }

        public User(string name, string surname, DateTime birthday)
        {
                this.NAME = name;
                this.SURNAME = surname;
                this.SECONDNAME = null;
                this.Birthday = birthday;
        }




        public DateTime Birthday
        {
            get { return birthDay; }
            set { birthDay = value; }
        }


        public int AGE
      => GetAge(Birthday);



        public static int GetAge(DateTime birthday)
        {
            if ((birthday.Day > 0) && (birthday.Month > 0) && (birthday.Year > 0))
            {
                DateTime dateNow = DateTime.Now;
                int year = dateNow.Year - birthday.Year;
                if (dateNow.Month < birthday.Month ||
                    (dateNow.Month == birthday.Month && dateNow.Day < birthday.Day)) year--;
                return year;
            }
            else { return 0; }
        }

    }
}
