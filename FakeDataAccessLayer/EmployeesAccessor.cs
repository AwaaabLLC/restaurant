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
        private List<Employee> employees;

        public EmployeesAccessor()
        {
            employees = new List<Employee>();
            Employee user = new Employee();
            user.EmployeeId = 1;
            user.FirstName = "a1";
            user.LastName = "b1";
            user.CellPhone = "c1";
            user.EmailAddress = "d1";
            employees.Add(user);

            user = new Employee();
            user.EmployeeId = 2;
            user.FirstName = "a2";
            user.LastName = "b2";
            user.CellPhone = "c2";
            user.EmailAddress = "d2";
            employees.Add(user);

            user = new Employee();
            user.EmployeeId = 3;
            user.FirstName = "a3";
            user.LastName = "b3";
            user.CellPhone = "c3";
            user.EmailAddress = "d3";
            employees.Add(user);

            user = new Employee();
            user.EmployeeId = 4;
            user.FirstName = "a4";
            user.LastName = "b4";
            user.CellPhone = "c4";
            user.EmailAddress = "d4";
            employees.Add(user);

            user = new Employee();
            user.EmployeeId = 5;
            user.FirstName = "a5";
            user.LastName = "b5";
            user.CellPhone = "c5";
            user.EmailAddress = "d5";
            employees.Add(user);
        }

        public bool inserNewEmployee(Employee user)
        {
            int prevLength = employees.Count;
            employees.Add(user);
            return employees.Count - prevLength == 1;
        }

        public List<Employee> selectAllEmployees()
        {
            return employees;
        }

        public bool updateEmployee(Employee employee)
        {
            bool result = false;
            foreach (Employee emp in employees) 
            {
                if (emp.EmployeeId == employee.EmployeeId)
                {
                    emp.FirstName = employee.FirstName;
                    emp.LastName = employee.LastName;
                    emp.CellPhone = employee.CellPhone;
                    emp.EmailAddress = employee.EmailAddress;
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}
