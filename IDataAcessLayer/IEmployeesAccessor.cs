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
       bool inserNewUser(Employee user);
        List<Employee> selectAllEmployees();
        bool updateEmployee(Employee employee);
    }
}
