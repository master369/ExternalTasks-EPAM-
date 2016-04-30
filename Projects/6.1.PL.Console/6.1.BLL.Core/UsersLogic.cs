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
                usersDao.GetAll();
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return usersDao.GetAll();
        }

        public bool Add(User user)
        {
            try
            {
                usersDao.Add(user);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return true;

        }

        public bool AddAward(int userId, int awardId)
        {
            try
            {
                if (usersDao.Get(userId) != null && awardsDao.Get(awardId) != null)
                {
                    usersDao.AddAward(userId, awardId);
                    return true;
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return false;
        }

        public void Delete(int id)
        {
            try
            {
                usersDao.Delete(id);
            }

            catch (Exception e)
            {
                logger.Error(e.Message);
            }
        }

        public bool IsUser(int id)
        {
            try
            {
                return usersDao.Get(id) != null;
            }

            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return usersDao.Get(id) != null;
        }

        public User Get(int id)
        {
            try
            {
                usersDao.Get(id);
            }

            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return usersDao.Get(id);
        }
    }
}