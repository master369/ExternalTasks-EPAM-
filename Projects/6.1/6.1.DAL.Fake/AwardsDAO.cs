using System;
using System.Collections.Generic;
using System.Linq;
using _6._1.Common.Entities;
using System.IO;
using _6._1.DAL.Abstracty;
using System.Configuration;

namespace _6._1.DAL.TextFiles
{
    public class AwardsDAO : IAwardsDAO
    {
        public  List<Award> awards;
        private int maxId;
        private string awardsstore;

        public int MaxId
        {
            get
            {
                return maxId;
            }
            set
            {
                if (value <= maxId) throw new ArgumentException("Ошибка! Новый id должен быть больше maxId!!!");
                else maxId = value;
            }
        }

        public AwardsDAO()
        {
            awardsstore = ConfigurationManager.AppSettings["awardsstore"];

            awards = new List<Award>();
            string str;

            using (StreamReader sr = File.OpenText(awardsstore))
            {
                Console.WriteLine("Получили доступ к файлу с наградами!");

                string[] spltStr = sr.ReadToEnd().Split(new Char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
                maxId = int.Parse(spltStr[0]);
                int awardCount = int.Parse(spltStr[1]);

                for (int i = 0; i < awardCount; i++)
                {
                    str = spltStr[i+2];
                    awards.Add(StringToAward(str));                   
                }

            }

            FillAwards();
        }

        private Award StringToAward(string str)
        {
            string[] spltStr;

            spltStr = str.Split(new Char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            int id = int.Parse(spltStr[0]);
            string name = spltStr[1];     
            return new Award(id, name);
        }

        private void FillAwards()
        {
            Award award;
            string[] spltStr;
            int idUser;
            int idAwards;
            foreach (string line in File.ReadLines(@"UserAward.txt"))
            {
                spltStr = line.Split(new Char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                idUser = int.Parse(spltStr[0]);
                idAwards = int.Parse(spltStr[1]);
                award = awards.FirstOrDefault(a => a.Id == idAwards);
                if (award != null)
                {
                    award.ListOfUsers.Add(idUser);
                }
            }
        }

        public void SaveAll()
        {
            using (var sw = new StreamWriter(awardsstore))
            {
                Console.WriteLine("ПОЛУЧИЛИ ДОСТУП К ФАЙЛУ");
                sw.Write("{0} ^ ", maxId);
                sw.Write("{0} ^  ", awards.Count);
                for (int i = 0; i < awards.Count; i++)
                {
                    sw.Write(String.Format(" {0} {1} 0 ^ ", awards[i].Id, awards[i].Name));
                }
            }
        }

        public bool IsAward(int id)
        {
            foreach (var item in awards)
            {
                if (item.Id == id)
                {
                    return true;
                }
            }

            return false;
        }

        public Award Get(int id)
        {
            return awards.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Award> GetAll()
        {
            foreach (var item in awards)
            {
                yield return item;
            }
        }

        public int Add(Award award)
        {
            awards.Add(award);
            SaveAll();
            return award.Id;
        }

        public void Delete(int id)
        {
            foreach (var item in awards)
            {
                if (item.Id == id)
                {
                    awards.Remove(item);
                    break;
                }
            }
            SaveAll();
        }

    }
}
