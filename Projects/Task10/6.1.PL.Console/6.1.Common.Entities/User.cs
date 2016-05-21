using System;
using System.Collections.Generic;

namespace _6._1.Common.Entities
{
    public class User
    {
        public User( string name, DateTime dateOfBirth, List<int> awards)
        {
           
            Name = name;
            DoB = dateOfBirth;
            Awards = awards;
        }

        public User(int id,string name, DateTime dateOfBirth, List<int> awards)
        {
            Id = id;
            Name = name;
            DoB = dateOfBirth;
            Awards = awards;
        }

        public User( string name, DateTime dateOfBirth, List<int> awards, byte[] image)
        {
          
            Name = name;
            DoB = dateOfBirth;
            Awards = awards;
            Image = image;
        }
        public User(int id, string name, DateTime dateOfBirth, List<int> awards, byte[] image)
        {
            Id = id;
            Name = name;
            DoB = dateOfBirth;
            Awards = awards;
            Image = image;
        }
        public User(string name, DateTime dateOfBirth, byte[] image)
        {

            Name = name;
            DoB = dateOfBirth;
            Image = image;
        }
        public User(int id, string name, DateTime dateOfBirth, byte[] image)
        {
            Id = id;
            Name = name;
            DoB = dateOfBirth;
            Image = image;
        }
        public User(string name, DateTime dateOfBirth)
        {
            Name = name;
            DoB = dateOfBirth;
        }
        public User(int id, string name, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            DoB = dateOfBirth;
        }
        public int Id { get; set; }
        public string name;
        public DateTime dob;

        public IList<int> Awards { get; set; }
        public byte[] Image;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception();
                }
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

            if ((dateFrom.Day > 0) && (dateFrom.Month > 0) && (dateFrom.Year > 0))
            {
                return ((dateFrom.Month >= dateTo.Month && dateFrom.Day > dateTo.Day) ?
                  dateTo.Year - dateFrom.Year - 1 :
                  (dateTo.Year - dateFrom.Year));
            }
            else { return 0; }
        }
    }
}
