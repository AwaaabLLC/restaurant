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
        public List<EmployeeUser> getAllEmployeesUsers()
        {
            List<EmployeeUser> empUsers = [];
            List<User> users = getAllUsers();
            foreach (User u in users)
            {
                EmployeeUser empUser = new();
                empUser.Id = u.EmployeeId;
                empUser.EmailAddress = u.EmailAddress;
                empUser.Active = u.Active;
                empUsers.Add(empUser);
            }
            return empUsers;
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
        User getUserById(int? id)
        {
            User user = new();
            user = usersAccessor.selectUserByID(id);
            return user;
        }

        User IUsersManager.getUserById(int? id)
        {
            return getUserById(id);
        }

        public bool addNewEmployeeUser(EmployeeUser employeeUser)
        {
            User user = new User();
            user.EmployeeId = employeeUser.Id;
            user.EmailAddress = employeeUser.EmailAddress;
            user.Active = employeeUser.Active; 
            bool result = addNewUser(user);
            return result;
        }

        public bool updateEmployeeUser(EmployeeUser employeeUser)
        {
            bool result = false;
            User user = new User();
            user.EmployeeId = employeeUser.Id;
            user.EmailAddress = employeeUser.EmailAddress;
            user.Active = employeeUser.Active;
            result = usersAccessor.updateUser(user);
            return result;
        }

        public EmployeeUser getEmployeesUserById(int? id)
        {
            User user = getUserById(id);
            EmployeeUser emp = new EmployeeUser();
            emp.Id = user.EmployeeId;
            emp.EmailAddress = user.EmailAddress;
            emp.Active = user.Active;
            return emp;
        }

        public bool deactiveActiveUser(EmployeeUser employeeUser)
        {
            User user = new User();
            user.EmployeeId = employeeUser.Id;
            user.EmailAddress = employeeUser.EmailAddress;
            user.Active = employeeUser.Active;
            bool result = deactiveActiveUser(user);
            return result;
        }
    }
}
