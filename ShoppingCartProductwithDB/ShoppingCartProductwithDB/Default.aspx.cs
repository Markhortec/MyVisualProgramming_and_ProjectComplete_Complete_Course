using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using AppProps;

namespace ShoppingCartProductwithDB
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //DataTable dt = new DataTable();
                //dt.Columns.Add("Id");
                //dt.Columns.Add("Name");
                //dt.Columns.Add("Image");
                //dt.Columns.Add("Price");
                //dt.Rows.Add("1", "Apples", "apple.png", "15");
                //dt.Rows.Add("2", "Broccoli", "broccoli.jpg", "25");
                //dt.Rows.Add("3", "Grapes", "grape.png", "35");
                //dt.Rows.Add("4", "Oranges", "orange.jpg", "45");
                //dt.Rows.Add("5", "Pears", "pear.jpg", "55");
                //dt.Rows.Add("6", "Red Chillies", "red-chilli.jpg", "65");
                //dt.Rows.Add("7", "Water Melon", "water-melon.jpg", "75");
                //DataList1.DataSource = dt;
                //DataList1.DataBind();
                ProductBLL productBLL = new ProductBLL();
                DataTable dt = productBLL.GetAllProducts();
                DataList1.DataSource = dt;
                DataList1.DataBind();
            }
        }

        protected void btnAddtoCart_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "viewdetails")
            {
                //Response.Write(@"<script language='javascript'>alert('" + e.CommandArgument.ToString() + "');</script>");
                int id = Int16.Parse(e.CommandArgument.ToString());
                Product p = new Product();
                p.Id = id;
                ProductBLL productBLL = new ProductBLL();
                DataTable dt = productBLL.SearchProduct(p);
                p.Name = dt.Rows[0]["Name"].ToString();
                p.Image = dt.Rows[0]["Image"].ToString();
                p.Price = float.Parse(dt.Rows[0]["Price"].ToString());
                p.Description = dt.Rows[0]["Description"].ToString();
                Cart cart = null;
                if (Session["cart"] != null)
                {
                    cart = (Cart)Session["cart"];
                }
                Cart newCart = new Cart(cart);
                if (newCart.AddToCart(p, 1))
                {
                    //Response.Write(@"<script language='javascript'>alert('Item Added to Cart');</script>");
                    Session["cart"] = newCart;
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Item not Added to Cart');</script>");
                }
            }
        }
    }
}