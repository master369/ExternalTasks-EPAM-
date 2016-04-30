using _6._1.BLL.Core;
using _6._1.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using log4net;

namespace _6._1
{
    class Program
    {// вынести методы(трай кэтч), больше трай кэтчев,
        //для  блл свои интерфейсы, задача блл не хранение(кэширование), логично использовать третий файл при награждении(имя id id),  )
      // много ломать? еще проверки на имена, даты и прочеее, а то грустно . 
        private static UsersLogic usersLogic;
        private static AwardsLogic awardsLogic;
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static Program()
        {
            awardsLogic = new AwardsLogic();
            usersLogic = new UsersLogic();
            //log4net.Util.LogLog.InternalDebugging = true;
            log4net.Config.XmlConfigurator.Configure();
        }

        static void Main(string[] args)
        {
            string userChoice;
            while (true)
            {
                Console.WriteLine("Выберите один из пунктов:");
                Console.WriteLine("\t 0. Выход");
                Console.WriteLine("\t 1. Добавить нового пользователя");
                Console.WriteLine("\t 2. Просмотреть всех пользователей");
                Console.WriteLine("\t 3. Удалить пользователя по id");
                Console.WriteLine("\t 4. Добавить новую награду");
                Console.WriteLine("\t 5. Наградить пользователя");
                Console.WriteLine("\t 6. Просмотреть список наград пользователя");
                Console.Write(">");
                
                userChoice = Console.ReadLine();

                switch (userChoice)
                {
                
                    case "0": { return; }
                    case "1":
                        CreateNewUser();
                        break;
                    case "2":
                        ShowAllUsers();
                        break;
                    case "3":
                        DeleteUser();
                        break;
                    case "4":
                        CreateNewAward();
                        break;
                    case "5":
                        AddAwardToUser();
                        break;
                    case "6":
                        ShowThisUser();
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }

        private static void CreateNewAward()
        {
            Console.WriteLine("Введите название награды:");
            try
            {
                string name = Console.ReadLine();

                Award award = new Award(0, name, new List<int>(0));
                Console.WriteLine((awardsLogic.Add(award)) ?
                                    "Награда добавлена!" :
                                    "Ошибка! Не удалось добавить награду...");
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                Console.WriteLine("Ошибка! Не удалось создать новую награду...");
            }
        }

        private static void AddAwardToUser()
        {
            Console.Write("Введите id пользователя: ");
            int userId = int.Parse(Console.ReadLine());

            Console.Write("Введите id награды: ");
            int awardId = int.Parse(Console.ReadLine());
            try
            {
                if (usersLogic.AddAward(userId, awardId))
                    Console.WriteLine("Пользователь награжден!");
                else
                    Console.WriteLine("Ошибка! Пользователь или награда не найдены!");
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                Console.WriteLine("Ошибка! Не удалось наградить этого пользователя...");
            }
            Console.WriteLine("===============================");

        }

        private static void ShowThisUser()
        {
            Console.WriteLine("Введите id пользователя:");
            try
            {
                int id = int.Parse(Console.ReadLine());
                var users = usersLogic.GetAll().ToList();
                var awards = awardsLogic.GetAll().ToList();

                if (usersLogic.IsUser(id))
                    for (int i = 0; i < users.Count; i++)
                        if (users[i].Id == id)
                        {
                            Console.WriteLine(" Id пользователя: {0}\n Имя: {1}\n Дата рождения (день, месяц, год): {2}, {3}, {4}\n Возраст: {5}",
                                            users[i].Id, users[i].Name, users[i].DoB.Day, users[i].DoB.Month, users[i].DoB.Year, users[i].Age);

                            Console.WriteLine("Список его наград:");
                            bool flag = true;
                            if (users[i].Awards != null)
                            {
                                foreach (var item in users[i].Awards)
                                {
                                    if (awardsLogic.Get(item) != null)
                                    {
                                        Console.WriteLine("Id награды: {0}; Название награды: {1};",
                                            awardsLogic.Get(item).Id, awardsLogic.Get(item).Name);
                                        flag = false;
                                    }
                                }
                            }

                            if (flag) Console.WriteLine("Награды отсутствуют...");
                        }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                Console.WriteLine("Ошибка! Не удалось показать этого пользователя...");
            }
            Console.WriteLine("===============================");
        }


        private static void DeleteUser()
        {
            try
            {
                Console.WriteLine("Введите id пользователя для удаления: ");
                int id = int.Parse(Console.ReadLine());
                usersLogic.Delete(id);
                Console.WriteLine("===============================");
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                Console.WriteLine("Ошибка! Не удалось удалить пользователей...");
            }

        }

        private static void ShowAllUsers()
        {
            var users = usersLogic.GetAll().ToList();
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine(" Id пользователя: {0}\n Имя: {1}\n Дата рождения: {2}\n Возраст: {3}",
                                users[i].Id, users[i].Name, users[i].DoB.ToShortDateString(), users[i].Age);
                Console.WriteLine("_______________________________");
            }
            Console.WriteLine("===============================");
        }

        private static void CreateNewUser()
        {
            Console.WriteLine("Введите имя пользователя:");
            try
            {
                //throw new Exception("egoeerugeri423423423gbeirgb test exeption");
                string name = Console.ReadLine();
                if (name.IndexOf(" ") >= 0 || name.IndexOf("^") >= 0 || name.IndexOf("\t") >= 0)
                    throw new Exception("В имени не должно быть пробелов и символов '^' !!!");
                Console.WriteLine("Введите дату рождения в формате (день.месяц.год):");

                string strDOB = Console.ReadLine();
                DateTime DoB = DateTime.Parse(strDOB);
                User user = new User(0, name, DoB, new List<int>(0));
                Console.WriteLine((usersLogic.Add(user)) ?
                                "Пользователь добавлен!" :
                                "Ошибка! Не удалось добавить пользователя...");
            }

            catch (Exception e)
            {
                logger.Error(e.Message);
                Console.WriteLine("Ошибка! Не удалось добавить пользователя...");
            }

        }
    }
}
