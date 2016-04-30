using _6._1.BLL.Interfaces;
using _6._1.Common.Entities;
using _6._1.DAL.Abstracty;
using System.Collections.Generic;
using System.Linq;
using System;

namespace _6._1.BLL.Core
{
    public class AwardsLogic
    //  :        IAwardsBLL
    { // лист наград не должен тут хранится, это не задача логики.
        private List<Award> awards;
        public IUsersDAO usersDao;
        public IAwardsDAO awardsDao;

        public AwardsLogic()
        {
            usersDao = DaoContainer.UsersDAO;
            awardsDao = DaoContainer.AwardsDAO;
            awards = awardsDao.GetAll().ToList();
        }
        
        public IEnumerable<Award> GetAll()
        {
            foreach (var item in awards)
            {
                yield return item;
            }  
        }

        public bool Add(Award award)
        {
            int maxId = awards.Max(n => n.Id);

            if (awards.Any())
                awardsDao.MaxId = (maxId + 1 > awardsDao.MaxId) ? maxId + 1
                                                                : awardsDao.MaxId + 1;
            award.Id = awardsDao.MaxId;
            awards.Add(award);

            awardsDao.Add(award);

            return award.Id != default(int);
        }


        public void Delete(int id)
        {
            foreach (var item in awards)
            {
                if (item.Id == id)
                {
                    awards.Remove(item);
                    break;
                }
            }
            awardsDao.Delete(id);
        }

        public Award Get(int id)
        {
            return awards.FirstOrDefault(x => x.Id == id);
        }
        
    }
}
