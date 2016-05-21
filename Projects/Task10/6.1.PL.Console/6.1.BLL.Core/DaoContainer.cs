using _6._1.DAL.Interfaces;
using _6._1.DAL.TextFiles;
using _6._1.DAL.DataBase;
using System;
using System.Configuration;

namespace _6._1.BLL.Core
{
    class DaoContainer 
    {
        public static IUserDAO UsersDAO { get; private set; }
        public static IAwardsDAO AwardsDAO { get; private set; }
        public static IAccountDAO AccountDAO { get; private set; }
        public static IRelationDAO RelationDAO { get; private set; }

        static DaoContainer()
        {
            var dal = ConfigurationManager.AppSettings["dal"];
            switch (dal)
            {
                case "txt":
                    UsersDAO = new DAL.TextFiles.UsersDAO();
                    AwardsDAO = new DAL.TextFiles.AwardsDAO();
                    break;

                case "database":
                    UsersDAO = new DAL.DataBase.UsersDAO();
                    AwardsDAO = new DAL.DataBase.AwardsDAO();
                    AccountDAO = new AccountDAO();
                    RelationDAO = new RelationDAO();
                    break;


                default:
                    throw new Exception("Ошибка! Должен быть текстовый DAL!");
            }

        }
    }
}