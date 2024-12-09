using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILogicLayer;
using DataObjectLayer;
using DataAccessLayer;
using IDataAcessLayer;

namespace LogicLayer
{
    public class UsersManager : IUsersManager
    {
        private IUsersAccessor usersAccessor;
        public UsersManager() 
        {
            usersAccessor = new UsersAccessor();
        }
        public UsersManager(IUsersAccessor usersAccessor) 
        {
            this.usersAccessor = usersAccessor;
        }

        public List<User> getAllUsers()
        {
            List<User> users = new List<User>();
            try
            {
                users = usersAccessor.selectAllUsers();
            }
            catch (Exception)
            {

                throw;
            }
            return users;
        }

        public bool deactiveActiveUser(User user)
        {
            bool result = false;
            try
            {
                result = usersAccessor.deactiveActiveUser(user);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool addNewUser(User user)
        {
            bool result = false;
            try
            {
                result = usersAccessor.insertNewUser(user);
            }
            catch (Exception)
            {

                throw;
            }
            return result ;
        }

        public List<string> getAllRoles()
        {
            List<string> roles = new List<string>();
            try
            {
                roles = usersAccessor.selectAllRoles();
            }
            catch (Exception)
            {

                throw;
            }
            return roles;
        }

        public bool updateEmployeeRole(int employeeId, string? RoleId = "Admin")
        {
            bool result = false ;
            try
            {
                result = usersAccessor.updateEmployeeRole(employeeId, RoleId);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool isAutherize(string username, string password)
        {
            bool result = false;
            try
            {
                result = usersAccessor.isAutherize(username, HelpTools.EncryptSHA256(password));
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public string getEmployeeRole(string username)
        {
            string role = string.Empty;
            try
            {
                role = usersAccessor.selectEmployeeRole(username);
            }
            catch (Exception)
            {

                throw;
            }
            return role;
        }
    }
}
