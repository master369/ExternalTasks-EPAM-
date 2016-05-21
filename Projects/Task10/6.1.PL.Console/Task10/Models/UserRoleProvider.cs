using System;
using System.Linq;
using System.Web.Security;
using Task10.Models;
using _6._1.Common.Entities;
using _6._1.BLL.Interfaces;
using System.Collections.Generic;
using _6._1.BLL.Core;

namespace Task10.Models
{
    public class UserRoleProvider : RoleProvider
    {
  AccountLogic logic = new AccountLogic();

       

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            logic.AddUserToRole(usernames[0], roleNames[0]);
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return logic.IsUserInRole(username, roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            logic.RemoveUserFromRole(usernames[0], roleNames[0]);
        }

        public override string[] GetRolesForUser(string username)
        {
            return logic.GetRolesForUser(username);
        }


        #region Not Implemented
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}