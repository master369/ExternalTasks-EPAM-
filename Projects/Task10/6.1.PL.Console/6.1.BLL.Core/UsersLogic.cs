using _6._1.BLL.Interfaces;
using _6._1.Common.Entities;
using _6._1.DAL.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._1.BLL.Core
{
    public class UsersLogic : IUserBLL
    {
        private IUserDAO usersDao;
        private IAwardsDAO awardsDao;
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public UsersLogic()
        {
            usersDao = DaoContainer.UsersDAO;
            awardsDao = DaoContainer.AwardsDAO;
        }
        public IEnumerable<User> GetAll()
        {
            try
            {
                usersDao.GetAllUsers();
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return usersDao.GetAllUsers();
        }

        public bool Create(User user)
        {
            try
            {
                usersDao.Create(user);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return true;

        }


        public bool Delete(int id)
        {
            try
            {
                usersDao.DeleteUser(id);
            }

            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return true;
        }

        public bool Update(User user)
        {
            return usersDao.Update(user);
        }

        public bool IsUser(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
           return usersDao.Get(id);
        }
    }
}