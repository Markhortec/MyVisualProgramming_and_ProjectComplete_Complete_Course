using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppProps;

namespace ShoppingCartProductwithDB
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["cart"] != null)
                {
                    Cart cart = (Cart)Session["cart"];
                    DataList1.DataSource = cart.items;
                    DataList1.DataBind();
                }
            }
        }

        protected void btnRemoveFromCart_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "removeFromCart")
            {
                int id = Int16.Parse(e.CommandArgument.ToString());
                Product p = new Product();
                p.Id = id;
                Cart cart = null;
                if (Session["cart"] != null)
                {
                    cart = (Cart)Session["cart"];
                }
                Cart newCart = new Cart(cart);
                if (newCart.RemoveFromCart(p, -1))
                {
                    Session["cart"] = newCart;
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Item not removed to Cart');</script>");
                }
            }
        }
    }
}