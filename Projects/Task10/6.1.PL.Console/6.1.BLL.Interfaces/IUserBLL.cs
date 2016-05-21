using _6._1.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.BLL.Interfaces
{
   public interface IUserBLL
    {
        IEnumerable<User> GetAll();
        bool Create(User user);
        bool Update(User user);
        bool Delete(int id);
        bool IsUser(int id);
        User Get(int id);
    }
}
