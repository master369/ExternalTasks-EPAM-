using _6._1.BLL.Interfaces;
using _6._1.BLL.Core;
using _6._1.Common.Entities;
using System.Collections.Generic;

namespace Task10.Models
{
    public class Commons
    {
        public static IAwardBLL awardsLogic = new AwardsLogic();

        public static IUserBLL userLogic = new UsersLogic();

        public static IAccountBLL accountLogic = new AccountLogic();
        public static IRelationBLL relationLogic = new RelationBLL();


    }
}