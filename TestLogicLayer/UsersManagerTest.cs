using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;
using FakeDataAccessLayer;
using IDataAcessLayer;
using ILogicLayer;
using LogicLayer;

namespace TestLogicLayer
{
    public class UsersManagerTest
    {
        private static IUsersAccessor usersAccessor = new UsersAccessor();
        private IUsersManager usersManager = new UsersManager(usersAccessor);

        [Fact]
        public void GetAllUsersTest() 
        {
            Assert.Equal(6, usersManager.getAllUsers().Count);
        }

        [Fact]
        public void DeactiveActiveUserTest()
        {
           User user = new User();
            user.Active = false;
            user.EmailAddress = "test1@test.com";
            user.EmployeeId = 1;
            Assert.True(usersManager.deactiveActiveUser(user));
        }

        [Fact]
        public void AddNewUserTest()
        {
            User user = new User();
            user.Active = true;
            user.EmailAddress = "test10@test.com";
            user.EmployeeId = 10;
            user.Password = "password";
            Assert.True(usersManager.addNewUser(user));
        }

        [Fact]
        public void GetAllRolesTest()
        {
           Assert.Equal(5, usersManager.getAllRoles().Count);
        }

        [Fact]
        public void UpdateEmployeeRoleTest()
        {
            Assert.True(usersManager.updateEmployeeRole(1,"role3"));
        }

        [Fact]
        public void IsAutherizeTest()
        {
            Assert.True(usersManager.isAutherize("test1@test.com","password"));
        }

    }
}
