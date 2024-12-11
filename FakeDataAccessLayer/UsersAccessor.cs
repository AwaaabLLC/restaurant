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
        public class EmployeeRole
        {
            public int Id { get; set; }
            public string? Role { get; set; }
        }
        private List<User> users = [];
        private List<string> Roles = [];
        private List<EmployeeRole> employeeRoles = [];
        
        public UsersAccessor() 
        {
            addFiveSamplesData();
        }

        private void addFiveSamplesData()
        {
            for (int i = 1; i < 6; i++)
            {
                User user = new();
                user.EmployeeId = i;
                user.EmailAddress = "test" + i + "@test.com";
                user.Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8";
                user.Active = true;
                users.Add(user);
                Roles.Add("role" + i);
                EmployeeRole role = new EmployeeRole();
                role.Id = i;
                role.Role = Roles[i-1];
                employeeRoles.Add(role);
            }
        }

        public bool deactiveActiveUser(User user)
        {
            foreach (User temp in users)
            {
                if (user.EmailAddress == temp.EmailAddress)
                {
                    temp.Active = !temp.Active;
                    return true;
                }
            }
            return false;
        }

        public bool insertNewUser(User user)
        {
            int prev = users.Count;
            users.Add(user);
            return users.Count - prev == 1;
        }

        public bool isAutherize(string username, string password)
        {
            foreach (User user in users)
            {
                if (user.EmailAddress.Equals(username) && (user.Password.Equals(password)))
                {
                    return true;
                }
            }
            return false;
        }

        public List<string> selectAllRoles()
        {
            return Roles;
        }

        public List<User> selectAllUsers()
        {
            return users;
        }

        public string selectEmployeeRole(string username)
        {
            foreach (User user in users) 
            {
                if (user.EmailAddress.Equals(username))
                {
                    foreach (EmployeeRole role in employeeRoles)
                    {
                        if (role.Id == user.EmployeeId)
                        {
                            return role.Role;
                        }
                    }
                }
            }
            return string.Empty;
        }

        public bool updateEmployeeRole(int employeeId, string? roleId)
        {
            foreach (EmployeeRole employeeRole in employeeRoles)
            {
                if (employeeRole.Id == employeeId)
                {
                    employeeRole.Role = roleId;
                    return true;
                }
            }
            return false;
        }
    }
}
