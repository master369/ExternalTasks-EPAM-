using _6._1.BLL.Core;
using _6._1.BLL.Interfaces;
using System;
using System.Configuration;

namespace _6._1
{
    class BLLContainer
    {
        public static IUsersBLL UsersBLL { get; private set; }
        public static IAwardsBLL AwardsBLL { get; private set; }

        static BLLContainer()
        {
            var dal = ConfigurationManager.AppSettings["dal"];
            switch (dal)
            {
                case "txt":
                    UsersBLL = new UsersLogic();
                    AwardsBLL = new AwardsLogic();
                    break;

                default:
                    throw new Exception("Ошибка! Должен быть текстовый DAL!");
            }

        }
    }
}
