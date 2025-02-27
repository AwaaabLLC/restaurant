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
    public class ProductsAccessor : IProductsAccessor
    {
        public Product selectProductById(int? id)
        {
            Product product = new Product();
            SqlConnection conn = DBConnection.GetDBConnection();
            SqlCommand cmd = new SqlCommand("sp_select_product_by_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        product.Id = reader.GetInt32(0);
                        product.Name = reader.GetString(1);
                        product.QTY = reader.GetString(2);
                        product.Price = reader.GetString(3);
                        product.UPC = reader.GetString(4);
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }finally { conn.Close(); }
            return product;
        }

        public bool inserProduct(Product product)
        {
            bool result = false;
            SqlConnection conn = DBConnection.GetDBConnection();
            SqlCommand cmd = new SqlCommand("sp_insert_product", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@QTY", product.QTY);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@UPC", product.UPC);
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

        public List<Product> selectAllProducts()
        {
            List<Product> products = new List<Product>();
            SqlConnection conn = DBConnection.GetDBConnection();
            SqlCommand cmd = new SqlCommand("sp_select_all_products", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.Id = reader.GetInt32(0);
                        product.Name = reader.GetString(1);
                        product.QTY = reader.GetString(2);
                        product.Price = reader.GetString(3);
                        product.UPC = reader.GetString(4);
                        products.Add(product);
                    }

                }
            }
            catch
            {
                throw;
            }
            finally { conn.Close(); }
            return products;
        }

        public int updateProduct(Product product)
        {
            int result = 0;
            SqlConnection conn = DBConnection.GetDBConnection();
            SqlCommand cmd = new SqlCommand("sp_update_product", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", product.Id);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@QTY", product.QTY);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@UPC", product.UPC);
            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }finally { conn.Close(); }
            return result;
        }

        public bool deleteProductById(int id)
        {
            bool result = false;
            SqlConnection conn = DBConnection.GetDBConnection();
            SqlCommand cmd = new SqlCommand("sp_delete_product", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", id);
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
