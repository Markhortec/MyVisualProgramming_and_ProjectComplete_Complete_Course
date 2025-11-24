using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AppProps;

namespace DAL
{
    public class ProductDAL
    {
        public DataTable SearchProductDAL(Product product)
        {
            string qry = "SELECT * FROM Ball WHERE Id='" + product.Id + "'";
            DbCon db = new DbCon();
            DataTable dt;
            db.OpenCon();
            dt = db.Search(qry);
            db.CloseCon();
            return dt;
        }
        public DataTable GetAllProductsDal()
        {
            string qry = "SELECT * FROM Ball";
            DbCon db = new DbCon();
            DataTable dt;
            db.OpenCon();
            dt = db.Search(qry);
            db.CloseCon();
            return dt;
        }
    }
}
