using System.Collections.Generic;
using _6._1.BLL.Interfaces;
using _6._1.Common.Entities;
using _6._1.DAL.Interfaces;
using System.Linq;
using System;

namespace _6._1.BLL.Core
{
   public class AccountLogic: IAccountBLL
    {
        private IAccountDAO accountDAO;

        public AccountLogic()
        {
            accountDAO = DaoContainer.AccountDAO;
        }

        public bool AddUser(string username, string password, string name, DateTime birthday, byte[] image)
        {
            return accountDAO.AddUser(username, password, name, birthday, image);
        }

        public bool AddUserToRole(string username, string password)
        {
            return accountDAO.AddUserToRole(username, password);
        }

        public IEnumerable<Account> GetAll()
        {
            return accountDAO.GetAll();
        }

        public string[] GetRolesForUser(string username)
        {
            return accountDAO.GetRolesForUser(username);
        }

        public bool IsUserInRole(string username, string password)
        {
            return accountDAO.IsUserInRole(username, password);
        }

        public bool IsUserRegistrated(string username)
        {
            return accountDAO.IsUserRegistrated(username);
        }

        public bool IsUserRegistrated(string username, string password)
        {
            return accountDAO.IsUserRegistrated(username, password);
        }

        public bool RemoveUserFromRole(string username, string password)
        {
            return accountDAO.RemoveUserFromRole(username, password);
        }
    }
}
