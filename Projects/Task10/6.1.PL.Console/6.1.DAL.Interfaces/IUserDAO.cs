using _6._1.Common.Entities;
using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.DAL.Interfaces
{
    public interface IUserDAO
    {
        IEnumerable<User> GetAllUsers();
        bool Create(User user);
        bool Update(User user);
        bool DeleteUser(int id);
        User Get(int id);
    }
}
