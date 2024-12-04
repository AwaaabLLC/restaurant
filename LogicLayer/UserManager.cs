using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;
using ILogicLayer;

namespace LogicLayer
{
    public class UserManager : IUsersManager
    {
        public bool addNewUser(User user)
        {
            return true;
        }
    }
}
