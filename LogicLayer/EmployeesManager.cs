using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;
using ILogicLayer;
using IDataAcessLayer;
using DataAccessLayer;

namespace LogicLayer
{
    public class EmployeesManager : IEmployeesManager
    {
        private IEmployeesAccessor employeesAccessor;

        public EmployeesManager()
        {
            employeesAccessor = new EmployeesAccessor();
        }

        public EmployeesManager(IEmployeesAccessor userAccessor)
        {
            this.employeesAccessor = userAccessor;
        }

        public bool addNewEmployee(Employee user)
        {
            bool result = false;
            try
            {
                result = employeesAccessor.inserNewEmployee(user);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool deleteEmployee(int id)
        {
            bool result = false;
            try
            {
                result = employeesAccessor.deleteEmployee(id);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public List<Employee> getAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                employees = employeesAccessor.selectAllEmployees();
            }
            catch (Exception)
            {

                throw;
            }
            return employees;
        }

        public Employee getEmployeeById(int? id)
        {
            Employee employee = new Employee();
            employee = employeesAccessor.selectEmployeeById(id);
            return employee;
        }

        public bool updateEmployee(Employee employee)
        {
            try
            {
                return employeesAccessor.updateEmployee(employee);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
