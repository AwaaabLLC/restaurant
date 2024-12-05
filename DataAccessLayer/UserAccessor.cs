using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;
using IDataAcessLayer;

namespace DataAccessLayer
{
    public class UserAccessor : IUserAccessor
    {
        public bool inserNewUser(User user)
        {
            return true;
        }
    }
}
