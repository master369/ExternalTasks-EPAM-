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
                awardsDao.GetAllAwards().ToArray();
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return awardsDao.GetAllAwards().ToArray();
        }

        public bool Create(Award award)
        {
            try
            {
                awardsDao.Create(award);
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
                awardsDao.DeleteAward(id);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return true;
        }

        public bool Update(Award award)
        {
           return awardsDao.Update(award);
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
