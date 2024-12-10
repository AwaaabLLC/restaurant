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
    public class OrdersAccessor : IOrdersAccessor
    {
        public bool insertOrder(Order order)
        {
            bool result = false;
            SqlConnection conn = DBConnection.GetDBConnection();
            SqlCommand cmd = new SqlCommand("sp_insert_order", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductName", order.ProductName);
            cmd.Parameters.AddWithValue("@CustomerName", order.CustomerName);
            cmd.Parameters.AddWithValue("@TableNumber", order.TableNumber);
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

        public List<Order> selectAllOrders()
        {
            List<Order> orders = [];
            SqlConnection conn = DBConnection.GetDBConnection();
            SqlCommand cmd = new SqlCommand("sp_select_all_orders", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open ();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Order order = new();
                        order.Id = reader.GetInt32(0);
                        order.ProductName = reader.GetString(1);
                        order.CustomerName = reader.GetString(2);
                        order.TableNumber = reader.GetInt32(3);
                        orders.Add(order);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }finally { conn.Close(); }
            return orders;
        }
    }
}
