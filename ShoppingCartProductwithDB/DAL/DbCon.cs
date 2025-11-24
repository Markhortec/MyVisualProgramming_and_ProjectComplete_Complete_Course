using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DbCon
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rdr;

        public DbCon()
        {
            try
            {
                con = new SqlConnection(@"Data Source=DESKTOP-IUNEQO8\SQLEXPRESS;Initial Catalog=ShoppingCart;Integrated Security=True;");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void OpenCon()
        {
            try
            {
                con.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void CloseCon()
        {
            try
            {
                con.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool UDI(string qry)
        {
            try
            {
                cmd = new SqlCommand(qry, con);
                if (cmd.ExecuteNonQuery() >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public DataTable Search(string qry)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(qry, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    return dt;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public string Login(string qry)
        {
            try
            {
                cmd = new SqlCommand(qry, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                string val = null;
                if (rdr.HasRows)
                {
                    if (rdr.Read())
                    {
                        val = rdr["Id"].ToString() + ":";
                        val = val + rdr["AccessLevel"].ToString();
                    }
                }
                else
                {
                    val = null;
                }
                rdr.Close();
                con.Close();
                return val;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public SqlConnection getCon()
        {
            return con;
        }
    }
}
