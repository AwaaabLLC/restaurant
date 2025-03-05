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

        public bool isAutherize(string username, string password)
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

        public string selectEmployeeRole(string username)
        {
            throw new NotImplementedException();
        }

        public User selectUserByID(int? id)
        {
            throw new NotImplementedException();
        }

        public bool updateEmployeeRole(int employeeId, string? roleId)
        {
            throw new NotImplementedException();
        }

        public bool updateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
