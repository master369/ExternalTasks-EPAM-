using _6._1.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.DAL.Interfaces
{
    public interface IUserDAO
    {

        IEnumerable<User> GetAll();

        int Add(User user);

        void Delete(int id);

        void AddAward(int userId, int awardId);

        User Get(int id);
    }
}
