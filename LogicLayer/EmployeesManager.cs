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

        public EmployeesManager(IEmployeesAccessor employeesAccessor)
        {
            this.employeesAccessor = employeesAccessor;
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
