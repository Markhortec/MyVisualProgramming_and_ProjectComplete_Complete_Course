using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VPLab2Task
{
    public partial class Details : System.Web.UI.Page
    {
        DBConnect db= new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                EmployeeLoadGrid();
            }
        }

        protected void Empbtn_Click(object sender, EventArgs e)
        {
            EmployeeLoadGrid();
        }
        public void EmployeeLoadGrid()
        {
            string grid = "select * from Employee";
            SqlDataAdapter sdr = new SqlDataAdapter(grid, db.GetSqlConnection());
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            detail.DataSource = dt;
            detail.DataBind();
        }
        public void DeptLoadGrid()
        {
            string grid = "select * from department";
            SqlDataAdapter sdr = new SqlDataAdapter(grid, db.GetSqlConnection());
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            detail.DataSource = dt;
            detail.DataBind();
        }

        protected void Deptbtn_Click(object sender, EventArgs e)
        {
            DeptLoadGrid();
        }
    }
}