using DataObjectLayer;
using IDataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeDataAccessLayer
{
    public class UsersAccessor : IUserAccessor
    {
        private List<User> _users;

        public UsersAccessor()
        {
            _users = new List<User>();
            User user = new User();
            user.UserId = 1;
            user.FirstName = "a1";
            user.LastName = "b1";
            user.CellPhone = "c1";
            user.EmailAddress = "d1";
            user.UserName = "d1";
            user.Password = "e1";
            _users.Add(user);

            user = new User();
            user.UserId = 2;
            user.FirstName = "a2";
            user.LastName = "b2";
            user.CellPhone = "c2";
            user.EmailAddress = "d2";
            user.UserName = "d2";
            user.Password = "e2";
            _users.Add(user);

            user = new User();
            user.UserId = 3;
            user.FirstName = "a3";
            user.LastName = "b3";
            user.CellPhone = "c3";
            user.EmailAddress = "d3";
            user.UserName = "d3";
            user.Password = "e3";
            _users.Add(user);

            user = new User();
            user.UserId = 4;
            user.FirstName = "a4";
            user.LastName = "b4";
            user.CellPhone = "c4";
            user.EmailAddress = "d4";
            user.UserName = "d4";
            user.Password = "e4";
            _users.Add(user);

            user = new User();
            user.UserId = 5;
            user.FirstName = "a5";
            user.LastName = "b5";
            user.CellPhone = "c5";
            user.EmailAddress = "d5";
            user.UserName = "d5";
            user.Password = "e5";
            _users.Add(user);
        }

        public bool inserNewUser(User user)
        {
            int prevLength = _users.Count;
            _users.Add(user);
            return _users.Count - prevLength == 1;
        }
    }
}
