using _6._1.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6._1.Common.Entities;
using _6._1.DAL.Interfaces;
using _6._1.DAL.DataBase;

namespace _6._1.BLL.Core
{
   public class RelationBLL: IRelationBLL
    {
        private IRelationDAO relationDAO;
        private IAwardsDAO awardDAO;
        private IUserDAO userDAO;
        private object logger;
        public RelationBLL()
        {
            userDAO = DaoContainer.UsersDAO;
            awardDAO = DaoContainer.AwardsDAO;
            relationDAO = DaoContainer.RelationDAO;
        }
        public bool Create(Relation relation)
        {
            return relationDAO.Create(relation);
        }

        public bool DeleteAwardFromUsers(int id)
        {
            return relationDAO.DeleteAwardFromUsers(id);

        }

        public bool DeleteRelation(Relation relation)
        {
            return relationDAO.DeleteRelation(relation);
        }

        public IEnumerable<Award> GetAwardsAtUser(int id)
        {
                return relationDAO.GetAll().Where(x => x.UserId == id).Join(awardDAO.GetAllAwards(), x => x.AwardId, y => y.Id, (x, y) => y).ToArray();
        }

        public IEnumerable<User> GetUsersAtAward(int id)
        {
            return relationDAO.GetAll().Where(x => x.AwardId == id).Join(userDAO.GetAllUsers(), x => x.UserId, y => y.Id, (x, y) => y).ToArray();

        }

        public bool Create(int userId, int awardId)
        {
            
                if (userDAO.Get(userId) != null && awardDAO.Get(awardId) != null)
                {
                    relationDAO.Create(userId, awardId);
                    return true;
                }
            
            return false;
        }
    }
}
