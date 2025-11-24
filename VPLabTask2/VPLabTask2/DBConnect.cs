using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VPLabTask2
{
    public class DBConnect
    {
        private string connectionString = @"Data Source=DESKTOP-8BL3MIG\SQLEXPRESS;Initial Catalog=VPLab;Integrated Security=True;";
        private SqlConnection con;
        public DBConnect()
        {
            con = new SqlConnection(connectionString);
        }
        public bool UDI(string qry)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            bool result = false;
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            con.Close();
            return result;
        }
        public DataTable Search(string qry)
        {
            con.Open();
            SqlDataAdapter sda=new SqlDataAdapter(qry,con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;
        }

    }
}
