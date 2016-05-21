using _6._1.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _6._1.BLL.Interfaces
{
   public interface IRelationBLL
    {

        bool Create(Relation relation);
        bool DeleteRelation(Relation relation); 
        IEnumerable<Award> GetAwardsAtUser(int id);
        IEnumerable<User> GetUsersAtAward(int id);
        bool DeleteAwardFromUsers(int id);
        bool Create(int userId, int awardId);
    }
}
