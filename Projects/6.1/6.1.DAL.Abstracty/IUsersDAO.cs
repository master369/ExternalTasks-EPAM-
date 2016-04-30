using _6._1.Common.Entities;
using System.Collections.Generic;

namespace _6._1.DAL.Abstracty
{
    public interface IUsersDAO
    {
        int MaxId { get; set; }
                
        IEnumerable<User> GetAll();

        int Add(User user);

        void Delete(int id);

        void AddAward(int userId, int awardId);

        User Get(int id);
    }
}
