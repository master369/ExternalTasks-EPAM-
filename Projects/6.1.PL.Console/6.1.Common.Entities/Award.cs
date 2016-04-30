using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.Common.Entities
{
    public class Award
    {
        public int Id { get; set; }
        public string name { get; set; }
        public IList<int> ListOfUsers { get; set; }

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

        public Award(int id, string name, IList<int> listOfUsers)
        {
            Id = id;
            Name = name;
            ListOfUsers = listOfUsers;
        }

        public Award(int id, string name)
        {
            Id = id;
            Name = name;
            ListOfUsers = new List<int>();
        }
    }
}
