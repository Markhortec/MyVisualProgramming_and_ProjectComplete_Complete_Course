using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DbCon
    {
        private SqlConnection conn;
        private SqlDataReader reader;
        public DbCon()
        {
            conn= new SqlConnection("Data Source=DESKTOP-8BL3MIG\\SQLEXPRESS;Initial Catalog=EmpDb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
        }
        public void OpenConnection()
        {
            conn.Open();
        }
        public void CloseConnection()
        { 
            conn.Close();
        }
        public SqlDataReader SrchByReader(string qry)
        {
            SqlCommand cmd = new SqlCommand(qry,conn);
            reader = cmd.ExecuteReader();
            return reader;

        }
    }
}
