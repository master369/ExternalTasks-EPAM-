using _6._1.Common.Entities;
using _6._1.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.IO;
using System.Globalization;

namespace _6._1.DAL.TextFiles
{
    public class UsersDAO : IUserDAO
    {

        public List<User> users;
        private string usersstore;
        public int Count;

        //private int maxId;
        //public int MaxId
        //{
        //    get
        //    {
        //        return maxId;
        //    }
        //    set
        //    {
        //        if (value <= maxId) throw new ArgumentException("Ошибка! Новый id должен быть больше maxId!!!");
        //        else maxId = value;
        //    }
        //}

        public UsersDAO()
        {
            usersstore = ConfigurationManager.AppSettings["usersstore"];

            users = new List<User>();
            string str;
            using (StreamReader sr = File.OpenText(usersstore))
            {
                Console.WriteLine("Получили доступ к файлу с пользователями!");

                string[] spltStr = sr.ReadToEnd().Split(new Char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
                Count = int.Parse(spltStr[0]);
                int userCount = int.Parse(spltStr[1]);

                for (int i = 0; i < userCount; i++)
                {
                    str = spltStr[i + 2];
                    users.Add(StringToUser(str));
                }
            }
            FillAwards();
        }

        private void SaveAll()
        {
            using (var sw = new StreamWriter(usersstore))
            {
                sw.Write("{0} ^ ", Count);
                sw.Write("{0} ^ ", users.Count);
                for (int i = 0; i < users.Count; i++)
                {
                    //sw.Write(String.Concat(users[i].Id, " ", users[i].Name, " ", users[i].DoB.Day, ".", users[i].DoB.Month, ".",
                    //                        users[i].DoB.Year," "));

                    sw.Write(String.Format(" {0} {1} {2}.{3}.{4} ",
                                    users[i].Id, users[i].Name,
                                    users[i].DoB.Day, users[i].DoB.Month, users[i].DoB.Year));

                    if (users[i].Awards != null)
                    {
                        sw.Write(String.Format(" {0} ", users[i].Awards.Count));
                        for (int j = 0; j < users[i].Awards.Count; j++)
                        {
                            sw.Write(String.Format(" {0} ", users[i].Awards[j]));
                        }
                    }
                    else sw.Write("0");

                    sw.Write("^");
                }
            }
        }

        private User StringToUser(string str)
        {
            string[] spltStr;
            spltStr = str.Split(new Char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int id = int.Parse(spltStr[0]);
            string name = spltStr[1];
            DateTime DoB = DateTime.Parse(spltStr[2], CultureInfo.InvariantCulture);

            User buf = new User(id, name, DoB);
            return buf;
        }

        private void FillAwards()
        {
            User user;
            string[] spltStr;
            int idUser;
            int idAwards;
            foreach (string line in File.ReadLines(@"UserAward.txt"))
            {
                spltStr = line.Split(new Char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                idUser = int.Parse(spltStr[0]);
                idAwards = int.Parse(spltStr[1]);
                user = users.FirstOrDefault(u => u.Id == idUser);
                if (user != null)
                {
                    user.Awards.Add(idAwards);
                }
            }
        }


        public IEnumerable<User> GetAll()
        {
            foreach (var item in users)
            {
                yield return item;
            }
        }

        public int Add(User user)
        {
            users.Add(user);
            SaveAll();
            return user.Id;
        }

        public void AddAward(int userId, int awardId)
        {
            Get(userId).Awards.Add(awardId);

            SaveAll();
        }

        public bool IsUser(int id)
        {
            return Get(id) != null;
        }

        public void Delete(int id)
        {
            foreach (var item in users)
            {
                if (item.Id == id)
                {
                    users.Remove(item);
                    break;
                }
            }
            SaveAll();
        }

        public User Get(int id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }
    }


}