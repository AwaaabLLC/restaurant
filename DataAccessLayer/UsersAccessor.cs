using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;
using IDataAcessLayer;
using Microsoft.Data.SqlClient;
namespace DataAccessLayer
{
    public class UsersAccessor : IUsersAccessor
    {

        public bool deactiveActiveUser(User user)
        {
            bool result = false;
            SqlConnection conn = DBConnection.GetDBConnection();
            SqlCommand cmd = new SqlCommand("sp_active_deactive_user", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeId", user.EmployeeId);
            cmd.Parameters.AddWithValue("@Email", user.EmailAddress);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Active", user.Active);
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

        public bool insertNewUser(User user)
        {
            bool result = false;
            SqlConnection conn = DBConnection.GetDBConnection();
            SqlCommand cmd = new SqlCommand("sp_insert_users", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeId", user.EmployeeId);
            cmd.Parameters.AddWithValue("@Email", user.EmailAddress);
            try
            {
                conn.Open() ;
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return result;
        }

        public bool isAutherize(string username, string password)
        {
            bool result = false;
            SqlConnection conn = DBConnection.GetDBConnection();
            SqlCommand cmd = new SqlCommand("sp_is_autherize", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            try
            {
                conn.Open();
                result = (int)cmd.ExecuteScalar() == 1;
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return result;
        }

        public List<string> selectAllRoles()
        {
            List<string> roles = new List<string>();
            SqlConnection conn = DBConnection.GetDBConnection();
            SqlCommand cmd = new SqlCommand("sp_select_all_roles", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string role = reader.GetString(0);
                        roles.Add(role);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return roles;
        }

        public List<User> selectAllUsers()
        {
            List<User> users = new List<User>();
            SqlConnection conn = DBConnection.GetDBConnection();
            SqlCommand cmd = new SqlCommand("sp_select_all_users", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.EmployeeId = reader.GetInt32(0);
                        user.EmailAddress = reader.GetString(1);
                        user.Password = reader.GetString(2);
                        user.Active = reader.GetBoolean(3);
                        users.Add(user);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }finally { conn.Close(); }
            return users;
        }

        public string selectEmployeeRole(string username)
        {
            string role = string.Empty;
            SqlConnection conn = DBConnection.GetDBConnection();
            SqlCommand cmd = new SqlCommand("sp_select_employee_role", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        role = reader.GetString(0);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return role;
        }

        public bool updateEmployeeRole(int employeeId, string? roleId)
        {
            bool result = false;
            SqlConnection conn = DBConnection.GetDBConnection();
            SqlCommand cmd = new SqlCommand("sp_update_employee_role", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
            cmd.Parameters.AddWithValue("@RoleId", roleId);
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return result;
        }
    }
}
