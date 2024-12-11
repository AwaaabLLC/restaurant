using ILogicLayer;
using LogicLayer;
using IDataAcessLayer;
using FakeDataAccessLayer;
using DataObjectLayer;
namespace TestLogicLayer
{
    public class EmployeesManagerTest
    {
        private static IEmployeesAccessor _employeesAccessor = new EmployeesAccessor();
        private IEmployeesManager _employeesManager = new EmployeesManager(_employeesAccessor);
        [Fact]
        public void TestAddNewEmployee()
        {
            Employee employee = new();
            employee.FirstName = "Test";
            employee.LastName = "Test";
            employee.CellPhone = "Test";
            employee.EmailAddress = "Test";
            Assert.True(_employeesManager.addNewEmployee(employee));
        }

        [Fact]
        public void TestGetAllEmployees()
        {
            List<Employee> employees = [];
            Assert.Equal(6,_employeesManager.getAllEmployees().Count);
        }

        [Fact]
        public void TestUpdateEmployee()
        {
            Employee employee = new();
            employee.EmployeeId = 1;
            employee.FirstName = "Test";
            employee.LastName = "Test";
            employee.CellPhone = "Test";
            employee.EmailAddress = "Test";
            Assert.True(_employeesManager.updateEmployee(employee));
        }
    }
}