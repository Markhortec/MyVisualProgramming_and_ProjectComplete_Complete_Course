using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VPLabTask5
{
    public partial class Product : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-8BL3MIG\\SQLEXPRESS;Initial Catalog=VPLab;Integrated Security=True;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }
        private void LoadGrid()
        {
            pgrid.DataSource=LoadProductsData();
            pgrid.DataBind();
        }
        private DataTable LoadProductsData()
        {
            
            SqlCommand cmd = new SqlCommand("pdselectproducts", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;
            
        }
        private void ClearAll()
        {
            txtid.Text = "";
            txtname.Text = "";
            txtprice.Text = "";
            txtquantity.Text = "";
            ddlcategory.SelectedValue = null;
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "dbo.pdselectproduct";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(txtid.Text)));
            SqlDataAdapter sda=new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            txtid.Text = dt.Rows[0]["id"].ToString();
            txtname.Text = dt.Rows[0]["name"].ToString();
            ddlcategory.SelectedValue = dt.Rows[0]["category"].ToString();
            txtprice.Text = dt.Rows[0]["price"].ToString();
            txtquantity.Text = dt.Rows[0]["quantity"].ToString();
            labresult.Text = "id is present in database";
            LoadGrid();

        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
           if((!string.IsNullOrEmpty(txtid.Text))&&(!string.IsNullOrEmpty(txtname.Text))&&
                (!string.IsNullOrEmpty(ddlcategory.SelectedValue))&&
                (!string.IsNullOrEmpty(txtprice.Text))&&(!string.IsNullOrEmpty(txtquantity.Text)))
           {
                con.Open();
                SqlCommand cmd = new SqlCommand("dbo.pdInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(txtid.Text)));
                cmd.Parameters.Add(new SqlParameter("@name", txtname.Text));
                cmd.Parameters.Add(new SqlParameter("@category", ddlcategory.SelectedValue));
                cmd.Parameters.Add(new SqlParameter("@price", Convert.ToInt32(txtprice.Text)));
                cmd.Parameters.Add(new SqlParameter("@quantity", Convert.ToInt32(txtquantity.Text)));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    labresult.Text = "Data Inserted Successfully";
                    LoadGrid();
                    ClearAll();
                    con.Close();
                }
                else
                {
                    labresult.Text = "Data Not Inserted Successfully";
                }
            }
            else
            {
                labresult.Text = "Enter the Credentials";
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(txtid.Text)) && (!string.IsNullOrEmpty(txtname.Text)) &&
                (!string.IsNullOrEmpty(ddlcategory.SelectedValue)) &&
                (!string.IsNullOrEmpty(txtprice.Text)) && (!string.IsNullOrEmpty(txtquantity.Text)))
            {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("dbo.pdUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(txtid.Text)));
                    cmd.Parameters.Add(new SqlParameter("@name", txtname.Text));
                    cmd.Parameters.Add(new SqlParameter("@category", ddlcategory.SelectedValue));
                    cmd.Parameters.Add(new SqlParameter("@price", Convert.ToInt32(txtprice.Text)));
                    cmd.Parameters.Add(new SqlParameter("@quantity", Convert.ToInt32(txtquantity.Text)));
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        labresult.Text = "Data Updated Successfully";
                        LoadGrid();
                        ClearAll();
                    }
                    else
                    {
                        labresult.Text = "Data Not Updated Successfully";
                    }
            }
            else
            {
                labresult.Text = "Enter the Credentials";
            }
        }


        protected void btndelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtid.Text))
            {    
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "pdDelete";
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(txtid.Text)));
                int rowsAffected = cmd.ExecuteNonQuery();
                  if (rowsAffected > 0)
                  {
                    labresult.Text = "Data Deleted Successfully";
                    LoadGrid();
                    ClearAll();
                  }
                  else
                  {
                    labresult.Text = "Data Not Deleted Successfully";
                  }
                      
                  }
            else
            {
                labresult.Text = "Enter the ID to delete";
            }
        }


        protected void btnclear_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtname.Text = "";
            txtprice.Text = "";
            txtquantity.Text = "";
            ddlcategory.SelectedValue = null;
            labresult.Text = "Clear";
        }
    }
}