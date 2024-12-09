using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;
using IDataAcessLayer;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class EmployeesAccessor : IEmployeesAccessor
    {
        public bool inserNewEmployee(Employee employee)
        {
            bool result = false;
            SqlConnection conn = DBConnection.GetDBConnection();
            SqlCommand cmd = new SqlCommand("sp_add_new_employee",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName",employee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", employee.LastName);
            cmd.Parameters.AddWithValue("@PhoneNumber", employee.CellPhone);
            cmd.Parameters.AddWithValue("@Email", employee.EmailAddress);
            cmd.Parameters.AddWithValue("@role", "Employee");
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 2;
                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public List<Employee> selectAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            SqlConnection conn = DBConnection.GetDBConnection();
            SqlCommand cmd = new SqlCommand("sp_select_all_employees", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) 
                {
                    while (reader.Read()) 
                    {
                        Employee employee = new Employee();
                        employee.EmployeeId = reader.GetInt32(0);
                        employee.FirstName = reader.GetString(1);
                        employee.LastName = reader.GetString(2);
                        employee.CellPhone = reader.GetString(3);
                        employee.EmailAddress = reader.GetString(4);
                        employees.Add(employee);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return employees;
        }

        public bool updateEmployee(Employee employee)
        {
            bool result = false;
            SqlConnection conn = DBConnection.GetDBConnection();
            SqlCommand cmd = new SqlCommand("sp_update_employee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmd.Parameters.AddWithValue("@LastName", employee.LastName);
            cmd.Parameters.AddWithValue("@PhoneNumber", employee.CellPhone);
            cmd.Parameters.AddWithValue("@Email", employee.EmailAddress);
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }
}
