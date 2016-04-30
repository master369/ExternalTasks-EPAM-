using _6._1.Common.Entities;
using _6._1.DAL.Abstracty;
using _6._1.BLL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.BLL.Core
{
    public class UsersLogic: 
        //IUsersBLL
    {
        public IUsersDAO usersDao;
        public IAwardsDAO awardsDao;
        private List<User> users;

        public UsersLogic()
        {
            usersDao = DaoContainer.UsersDAO;
            awardsDao = DaoContainer.AwardsDAO;

            users = new List<User>();
            foreach (var item in usersDao.GetAll())
            {
                users.Add(item);
            }
        }

        public IEnumerable<User> GetAll()
        {
            foreach (var item in users)
            {
                yield return item;
            }
        }

        public bool Add(User user)
        {
            int maxId = users.Max(n => n.Id);

            if (users.Any())
                usersDao.MaxId = (maxId + 1 > usersDao.MaxId) ? maxId + 1
                                                              : usersDao.MaxId + 1;
            
            user.Id = usersDao.MaxId;
            users.Add(user);
            usersDao.Add(user);

            return user.Id != default(int);
        }

        public bool AddAward(int userId, int awardId)
        {
            if (usersDao.Get(userId) != null && awardsDao.Get(awardId) != null)
            {
                usersDao.AddAward(userId, awardId);
                return true;
            }
            return false;
        }

        public void Delete(int id)
        {
            users.Remove(Get(id));

            usersDao.Delete(id);
        }

        public bool IsUser(int id)
        {
            return Get(id) != null;
        }

        public User Get(int id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }
    }
}
