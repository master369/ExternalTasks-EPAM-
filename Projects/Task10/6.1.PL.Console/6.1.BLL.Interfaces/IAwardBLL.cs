using _6._1.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.BLL.Interfaces
{
    public interface IAwardBLL
    {
        IEnumerable<Award> GetAll();
        bool Create(Award award);
        bool Update(Award award);
        bool Delete(int id);
        Award Get(int id);
    }
}
