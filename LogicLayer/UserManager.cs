using DataObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace LogicLayer
{
    public class UserManager
    {
        public int ValidateUser(string userName, string password)
        {
            int result = 0;
            List<User> users = UserAccessor.GetUsers(userName, password);

            foreach (User item in users)
            {
                if (userName == item.UserName && password == item.Password)
                {
                    result = item.UserId;
                    break;
                }

            }
            return result;
        }
    }
}
