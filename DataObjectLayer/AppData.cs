using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer
{
    public  class AppData
    {
        public static string DataPath { get; set; }
        public static string UsersFileName = "userList.csv";
        public static string OrdersFileName = "accounts" +
            ".csv";
    }
}
