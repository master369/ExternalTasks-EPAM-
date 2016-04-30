using _6._1.BLL.Interfaces;
using _6._1.Common.Entities;
using _6._1.DAL.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._1.BLL.Core
{
    public class AwardsLogic : IAwardBLL
    {
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IUserDAO usersDao;
        private IAwardsDAO awardsDao;
        public AwardsLogic()
        {
            usersDao = DaoContainer.UsersDAO;
            awardsDao = DaoContainer.AwardsDAO;
        }

        public IEnumerable<Award> GetAll()
        {
            try
            {
                awardsDao.GetAll().ToArray();
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return awardsDao.GetAll().ToArray();
        }

        public bool Add(Award award)
        {
            try
            {
                awardsDao.Add(award);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return true;
        }


        public void Delete(int id)
        {
            try
            {
                awardsDao.Delete(id);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
        }

        public Award Get(int id)
        {
            try
            {
                awardsDao.Get(id);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return awardsDao.Get(id);
        }

    }
}
