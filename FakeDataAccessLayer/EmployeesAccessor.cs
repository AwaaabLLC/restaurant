using DataObjectLayer;
using IDataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeDataAccessLayer
{
    public class EmployeesAccessor : IEmployeesAccessor
    {
        private List<Employee> _users;

        public EmployeesAccessor()
        {
            _users = new List<Employee>();
            Employee user = new Employee();
            user.EmployeeId = 1;
            user.FirstName = "a1";
            user.LastName = "b1";
            user.CellPhone = "c1";
            user.EmailAddress = "d1";
            user.Active = true;
            user.Password = "e1";
            _users.Add(user);

            user = new Employee();
            user.EmployeeId = 2;
            user.FirstName = "a2";
            user.LastName = "b2";
            user.CellPhone = "c2";
            user.EmailAddress = "d2";
            user.Active = true;
            user.Password = "e2";
            _users.Add(user);

            user = new Employee();
            user.EmployeeId = 3;
            user.FirstName = "a3";
            user.LastName = "b3";
            user.CellPhone = "c3";
            user.EmailAddress = "d3";
            user.Active = true;
            user.Password = "e3";
            _users.Add(user);

            user = new Employee();
            user.EmployeeId = 4;
            user.FirstName = "a4";
            user.LastName = "b4";
            user.CellPhone = "c4";
            user.EmailAddress = "d4";
            user.Active = true;
            user.Password = "e4";
            _users.Add(user);

            user = new Employee();
            user.EmployeeId = 5;
            user.FirstName = "a5";
            user.LastName = "b5";
            user.CellPhone = "c5";
            user.EmailAddress = "d5";
            user.Active = true;
            user.Password = "e5";
            _users.Add(user);
        }

        public bool inserNewEmployee(Employee user)
        {
            int prevLength = _users.Count;
            _users.Add(user);
            return _users.Count - prevLength == 1;
        }

        public List<Employee> selectAllEmployees()
        {
            throw new NotImplementedException();
        }

        public bool updateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
