using _6._1.Common.Entities;
using System.Collections.Generic;

namespace _6._1.BLL.Interfaces
{
  public  interface IAwardsBLL
    {
        IEnumerable<Award> GetAll();

        bool Add(Award award);

        void Delete(int id);

        Award Get(int id);
    }
}
