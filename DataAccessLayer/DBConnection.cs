using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DataAccessLayer
{
    class DBConnection
    {
        // The connection's string to DB (localhost\sqlexpress.hotelDb)
        private static string connectionString = @"Data Source=localhost;Initial Catalog=hotelDb;Integrated Security=True";
        //public static SqlConnection GetDBConnection()
        //{
        //    SqlConnection conn = new SqlConnection(connectionString);
        //    return conn;
        //}

    }
}
