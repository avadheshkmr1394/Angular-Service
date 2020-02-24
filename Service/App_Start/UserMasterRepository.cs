using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Models;

namespace Service.App_Start
{
    public class UserMasterRepository : IDisposable
    {
        // SECURITY_DBEntities it is your context class
        Service.Models.SECURITY_DBEntities context = new SECURITY_DBEntities();

        //This method is used to check and validate the user credentials
        public UserMaster ValidateUser(string username, string password)
        {
            return context.UserMasters.FirstOrDefault(user =>
            user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.UserPassword == password);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}