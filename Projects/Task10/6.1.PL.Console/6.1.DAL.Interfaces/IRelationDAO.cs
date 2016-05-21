using _6._1.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.DAL.Interfaces
{
   public interface IRelationDAO
    {
        bool Create(Relation relation);
        bool DeleteRelation(Relation relation);
        IEnumerable<Relation> GetAll();
        bool DeleteAwardFromUsers(int id);
        bool Create(int userId, int awardId);
    }
}
