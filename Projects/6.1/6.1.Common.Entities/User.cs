using System;
using System.Collections.Generic;

namespace _6._1.Common.Entities
{
    public class User
    {
        public User(int id, string name, DateTime dateOfBirth, List<int> awards)
        {
            Id = id;
            Name = name;
            DoB = dateOfBirth;
            Awards = awards;
        }

        public User(int id, string name, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            DoB = dateOfBirth;
            Awards = new List<int>();
        }

        public int Id { get; set; }
        public string name;
        public DateTime dob;
        public IList<int> Awards { get; private set; }


        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public DateTime DoB
        {
            get
            {
                return dob;
            }
            set
            {
                dob = value;
            }
        }

        public int Age
        {
            get
            {
                return DifferenceInYears(DoB);
            }
        }

        public int DifferenceInYears(DateTime dateFrom)
        {
            return DifferenceInYears(dateFrom, DateTime.Now);
        }

        public int DifferenceInYears(DateTime dateFrom, DateTime dateTo)
        {
            return ((dateFrom.Month >= dateTo.Month && dateFrom.Day > dateTo.Day) ?
                      dateTo.Year - dateFrom.Year - 1 :
                      (dateTo.Year - dateFrom.Year));
        }
    }
}
