using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;
using IDataAcessLayer;

namespace FakeDataAccessLayer
{
    public class UsersAccessor : IUsersAccessor
    {
        public bool deactiveActiveUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool insertNewUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<string> selectAllRoles()
        {
            throw new NotImplementedException();
        }

        public List<User> selectAllUsers()
        {
            throw new NotImplementedException();
        }

        public bool updateEmployeeRole(int employeeId, string? roleId)
        {
            throw new NotImplementedException();
        }
    }
}
