using _6._1.DAL.Interfaces;
using _6._1.DAL.TextFiles;
using System;
using System.Configuration;

namespace _6._1.BLL.Core
{
    class DaoContainer 
    {
        public static IUserDAO UsersDAO { get; private set; }
        public static IAwardsDAO AwardsDAO { get; private set; }

        static DaoContainer()
        {
            var dal = ConfigurationManager.AppSettings["dal"];
            switch (dal)
            {
                case "txt":
                    UsersDAO = new UsersDAO();
                    AwardsDAO = new AwardsDAO();
                    break;

                default:
                    throw new Exception("Ошибка! Должен быть текстовый DAL!");
            }

        }
    }
}