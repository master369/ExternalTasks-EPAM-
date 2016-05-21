using _6._1.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.DAL.Interfaces
{
   public interface IAccountDAO
    {
        bool AddUser(string login, string password, string name, DateTime birthday, byte[] image);
        bool AddUserToRole(string login, string roleName);
        bool RemoveUserFromRole(string login, string roleName);
        bool IsUserInRole(string login, string roleName);
        bool IsUserRegistrated(string login);
        bool IsUserRegistrated(string login, string password);
        IEnumerable<Account> GetAll();
        string[] GetRolesForUser(string name);
    }
}
