using _6._1.Common.Entities;
using System.Collections.Generic;

namespace _6._1.BLL.Interfaces
{
  public  interface IUsersBLL
    {
        IEnumerable<User> GetAll();

        bool Add(User user);

        void Delete(int id);

        bool AddAward(int userId, int awardId);

        User Get(int id);
    }
}
