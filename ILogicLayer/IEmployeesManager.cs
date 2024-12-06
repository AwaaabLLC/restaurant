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
        bool addNewUser(Employee user);
        List<Employee> getAllEmployees();
        bool updateEmployee(Employee employee);
    }
}
