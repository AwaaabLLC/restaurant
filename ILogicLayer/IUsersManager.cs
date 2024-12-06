using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;
namespace ILogicLayer
{
    public interface IUsersManager
    {
        List<User> getAllUsers();
        bool deactiveActiveUser(User user);
        bool addNewUser(User user);
        List<string> getAllRoles();
        bool updateEmployeeRole(int employeeId, string? RoleId);
    }
}
