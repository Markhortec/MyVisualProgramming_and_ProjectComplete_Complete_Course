using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VPLab2Task
{
    public class DBConnect
    {
        private string connectionString = @"Data Source=DESKTOP-8BL3MIG\SQLEXPRESS;Initial Catalog=VPLab;Integrated Security=True;";
        private SqlConnection con;
        public DBConnect()
        {
            con=new SqlConnection(connectionString);
        }
        public SqlConnection GetSqlConnection()
        {
            return con;
        }
        public bool UDI(string qry)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            bool result = false;
            if (cmd.ExecuteNonQuery() > 0)
            {
                result=true;
                return result;
            }
            con.Close();
            return result;
            

        }
    }
}