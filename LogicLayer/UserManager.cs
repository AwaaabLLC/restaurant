using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;
using ILogicLayer;
using IDataAcessLayer;
using DataAccessLayer;

namespace LogicLayer
{
    public class UserManager : IUsersManager
    {
        private IUserAccessor userAccessor;

        public UserManager()
        {
            userAccessor = new UserAccessor();
        }

        public UserManager(IUserAccessor userAccessor)
        {
            this.userAccessor = userAccessor;
        }

        public bool addNewUser(User user)
        {
            bool result = false;
            try
            {
                result = userAccessor.inserNewUser(user);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
