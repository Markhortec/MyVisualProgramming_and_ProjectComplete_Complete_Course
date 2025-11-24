using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace VPLab2Task
{
    public partial class Department : System.Web.UI.Page
    {
        DBConnect db = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void  Clear()
        {
            txtId.Text=string.Empty;
            txtName.Text=string.Empty;  
            r1.Checked= false;
            r2.Checked= false;
        }
        protected void addbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text) && string.IsNullOrEmpty(txtName.Text))
            {
                resultLabel.Text = "Enter the Credentials";
            }
            else
            {
                int id = Convert.ToInt32(txtId.Text);
                string name = txtName.Text;
                string selectedStatus = "";

                if (r1.Checked)
                {
                    selectedStatus = "Active";
                }
                else if (r2.Checked)
                {
                    selectedStatus = "Inactive";
                }


                if (!string.IsNullOrEmpty(selectedStatus))
                {

                    string Qry = "INSERT INTO department (deptId, deptName, deptStatus) VALUES ('" + id + "','" + name + "','" + selectedStatus + "')";

                    if (db.UDI(Qry))
                    {
                        resultLabel.Text = "Save Succesfully";
                        Clear();
                    }
                    else
                    {
                        resultLabel.Text = "Not Save Succesfully";
                    }
                }
                else
                {
                    resultLabel.Text = "enter the credentials";
                }


            }
        }


        protected void updatebtn_Click(object sender, EventArgs e)
        {
            int id= Convert.ToInt32(txtId.Text);
            string name = txtName.Text;
            string Status = "";

            if (r1.Checked)
            {
                Status = "Active";
            }
            else if (r2.Checked)
            {
                Status = "Inactive";
            }
            if   (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(Status))
            {
                string updateqry = "UPDATE department SET deptName = '" + name + "', deptStatus = '" + Status + "' WHERE deptId = " + id;

                
                if (db.UDI(updateqry))
                {
                    resultLabel.Text = "Update Successfully";
                    Clear();
                }
                else
                {
                    resultLabel.Text = "Not Update Successfully";
                }
            }
            else
            {
                resultLabel.Text = "Enter the credentials";
            }
        }

        protected void searchbtn_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtId.Text))
            {
                int id = Convert.ToInt32(txtId.Text);
                string query = "SELECT * FROM Department WHERE deptId = " + id;

                SqlDataAdapter adapter = new SqlDataAdapter(query, db.GetSqlConnection());
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    txtId.Text = dt.Rows[0]["deptId"].ToString();
                    txtName.Text = dt.Rows[0]["deptName"].ToString();
                    string s = dt.Rows[0]["deptStatus"].ToString();
                    if(s == "Active")
                    {
                        r1.Checked = true;
                    }
                    else
                    {
                        r2.Checked= true;
                    }

                    resultLabel.Text = "Data retrieved successfully.";
                }
                else
                {
                    resultLabel.Text = "No data found for the provided ID.";
                }
            }
            else
            {
                resultLabel.Text = "Enter the credentials.";
            }
        }
    }
}
    