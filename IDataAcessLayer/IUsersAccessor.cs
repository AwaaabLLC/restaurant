using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;
namespace IDataAcessLayer
{
    public interface IUsersAccessor
    {
        bool deactiveActiveUser(User user);
        bool insertNewUser(User user);
        bool isAutherize(string username, string password);
        List<string> selectAllRoles();
        List<User> selectAllUsers();
        string selectEmployeeRole(string username);
        bool updateEmployeeRole(int employeeId, string? roleId);
    }
}
