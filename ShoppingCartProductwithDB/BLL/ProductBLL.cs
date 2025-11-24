using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AppProps;
using DAL;

namespace BLL
{
    public class ProductBLL
    {
        ProductDAL productDAL = new ProductDAL();
        public DataTable GetAllProducts()
        {
            return productDAL.GetAllProductsDal();
        }
        public DataTable SearchProduct(Product product)
        {
            return productDAL.SearchProductDAL(product);
        }
    }
}
