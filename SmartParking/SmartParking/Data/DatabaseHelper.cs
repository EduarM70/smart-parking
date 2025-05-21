using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Data
{
    public static class DatabaseHelper
    {
        private static string connectionString = @"Data Source=MYDESKTOPMARTIN\MYSQLSERVER;Initial Catalog=SmartParkingDB;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
