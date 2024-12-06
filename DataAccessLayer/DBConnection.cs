using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
namespace DataAccessLayer
{
    class DBConnection
    {
        private static string connectionString = @"Data Source=localhost;Initial Catalog=ResturantBD;TrustServerCertificate=True;Integrated Security=True";
        public static SqlConnection GetDBConnection() { 
            return new SqlConnection(connectionString);
        }
    }
}
