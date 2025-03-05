using DataObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAcessLayer
{
    public interface IEmployeesAccessor
    {
        bool deleteEmployee(int id);
        bool inserNewEmployee(Employee user);
        List<Employee> selectAllEmployees();
        Employee selectEmployeeById(int? id);
        bool updateEmployee(Employee employee);
    }
}
