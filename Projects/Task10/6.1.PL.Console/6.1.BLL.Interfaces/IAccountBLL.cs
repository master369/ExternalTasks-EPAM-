using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6._1.Common.Entities;

namespace _6._1.BLL.Interfaces
{
   public interface IAccountBLL
    {
        bool AddUser(string login, string password, string name, DateTime birthday, byte[] image);
        bool AddUserToRole(string login, string roleName);
        bool RemoveUserFromRole(string login, string roleName);
        bool IsUserInRole(string login, string roleName);
        bool IsUserRegistrated(string login);
        bool IsUserRegistrated(string login, string password);
        IEnumerable<Account> GetAll();
        string[] GetRolesForUser(string login);
    }
}
