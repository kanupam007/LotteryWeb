using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LotteryWeb.Models
{
    public class DataConnection
    {
        private DataConnection()
        {

        }
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }
        public static SqlConnection GetConnectionForBackOffice()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringForBackOffice"].ConnectionString);
        }
        public static SqlConnection GetConnectionCMS()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["GetConnectionCMS"].ConnectionString);
        }
        public static SqlConnection GetConnectionFareCaching()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringForFareCaching"].ConnectionString);
        }
        public static SqlConnection TestGetConnectionFareCaching()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["TEST"].ConnectionString);
        }
    }
}