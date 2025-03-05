using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;

namespace ILogicLayer
{
    public interface IEmployeesManager
    {
        bool addNewEmployee(Employee user);
        bool deleteEmployee(int id);
        List<Employee> getAllEmployees();
        Employee getEmployeeById(int? id);
        bool updateEmployee(Employee employee);
       
    }
}
