using _6._1.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.DAL.Interfaces
{
  public  interface IAwardsDAO
    {
        IEnumerable<Award> GetAllAwards();
        bool Create(Award award);
        bool Update(Award award);
        bool DeleteAward(int id);
        Award Get(int id);
    }
}
