using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.Common.Entities
{
   public class Account
    {
        public Account(string name, string Password, byte[] image , List<string> roles)
        {
            Name = name;
            Password = password;
            Image = image;
            Roles = new List<string>();
            Roles = roles;
        }
        public Account()
        {
            Roles = new List<string>();
        }

        public Account(int id, string login, string Password, string name, byte[] image, List<string> roles)
        {
            Id = id;
            Login = login;
            Password = password;
            Name = name;
            Image = image;
            Roles = roles;
        }

        public Account(string login, string Password, string name, DateTime birthday, byte[] image = null)
        {
            Login = login;
            Password = password;
            Name = name;
            Image = image;
            Roles = new List<string>();
            Birthday = birthday;
        }

        public Account(int id, string login, string Password, string name, DateTime birthday, byte[] image, List<string> roles)
        {
            Id = id;
            Login = login;
            Password = password;
            Name = name;
            Image = image;
            Roles = roles;
            Birthday = birthday;
            Roles = roles;
        }

        public string Name { get; set; }
        public int Id { get; set; }
        public string password { get; set; }

        public List<string> Roles { get; set; }
        public DateTime Birthday { get; private set; }
        public byte[] Image;
        public string Login { get; set; }
        public string Password { get; set; }

        private List<string> list;
        public DateTime birthday;
    }
}

