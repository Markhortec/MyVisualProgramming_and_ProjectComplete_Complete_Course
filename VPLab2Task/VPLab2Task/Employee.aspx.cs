using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace VPLab2Task
{
    public partial class Employee : System.Web.UI.Page
    {
        DBConnect db=new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ddldept.DataSource = DataLoad();
                ddldept.DataValueField = "deptId";
                ddldept.DataBind();
            }
        }
        protected DataTable DataLoad()
        {
           
            string qry = "select * from department";
            SqlDataAdapter sdr = new SqlDataAdapter(qry,db.GetSqlConnection());
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            return dt;
        }
        protected void savebtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtid.Text);
            string name = txtname.Text;
            int age = Convert.ToInt32(txtage.Text);
            int salary = Convert.ToInt32(txtsalary.Text);
            string cnic = txtcnic.Text;
            string contact = txtcontact.Text;
            int deptid = Convert.ToInt32(ddldept.SelectedValue);
            if ((!string.IsNullOrEmpty(txtid.Text))&&(!string.IsNullOrEmpty(name))&&(!string.IsNullOrEmpty(txtage.Text))
                &&(!string.IsNullOrEmpty(txtsalary.Text))&&(!string.IsNullOrEmpty(cnic))&&(!string.IsNullOrEmpty(contact)))
            {

                string Qry = "INSERT INTO Employee VALUES ('" + id + "','" + name + "',' " + age + "',' " + salary + "', '" + cnic + "', '" + contact + "','" + deptid + "')";
                if(db.UDI(Qry))
                {
                    resultlab.Text = "Save Succesfully";
                    Clear();
                }
                else
                {
                    resultlab.Text = "Not Save Succesfully";
                }
            }
            else
            {
                resultlab.Text = "Enter the Credentials";
            }

        }

        protected void searchbtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtid.Text))
            {
                int id = Convert.ToInt32(txtid.Text);
                string query = "SELECT * FROM Employee WHERE empId = " + id;

                SqlDataAdapter adapter = new SqlDataAdapter(query, db.GetSqlConnection());
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                   
                    txtid.Text = dt.Rows[0]["empId"].ToString();
                    txtname.Text = dt.Rows[0]["empName"].ToString();
                    txtage.Text = dt.Rows[0]["empAge"].ToString();
                    txtsalary.Text = dt.Rows[0]["empSalary"].ToString();
                    txtcnic.Text = dt.Rows[0]["empCNIC"].ToString();
                    txtcontact.Text = dt.Rows[0]["empContact"].ToString();
                    ddldept.SelectedValue = dt.Rows[0]["deptId"].ToString();

                    resultlab.Text = "Data retrieved successfully.";
                }
                else
                {
                    resultlab.Text = "No data found for the provided ID.";
                }
            }
            else
            {
                resultlab.Text = "Enter the credentials.";
            }

        }

        protected void deletebtn_Click(object sender, EventArgs e)
        {
            int idToDelete = Convert.ToInt32(txtid.Text);
            string deleteQuery = "DELETE FROM Employee WHERE empId = " + idToDelete;

           if (!string.IsNullOrEmpty(txtid.Text))
            {

                if (db.UDI(deleteQuery))
                {
                    resultlab.Text = "Record Deleted Successfully.";
                }
                else
                {
                    resultlab.Text = "Failed to Delete Record.";
                }

            }
            else
            {
                resultlab.Text = "Enter the ID";
            }

        }
        public void Clear()
        {
            txtid.Text = "";
            txtname.Text = "";
            txtsalary.Text = "";
            txtcontact.Text = "";
            txtcnic.Text = "";
            txtage.Text = "";
        }

        protected void clearbtn_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtname.Text = "";
            txtsalary.Text = "";
            txtcontact.Text = "";
            txtcnic.Text = "";
            txtage.Text = "";
        }

        protected void updatebtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtid.Text);
            string name = txtname.Text;
            int age = Convert.ToInt32(txtage.Text);
            int salary = Convert.ToInt32(txtsalary.Text);
            string cnic = txtcnic.Text;
            string contact = txtcontact.Text;
            int deptid = Convert.ToInt32(ddldept.SelectedValue);
            if ((!string.IsNullOrEmpty(txtid.Text)) && (!string.IsNullOrEmpty(name)) && (!string.IsNullOrEmpty(txtage.Text))
                && (!string.IsNullOrEmpty(txtsalary.Text)) && (!string.IsNullOrEmpty(cnic)) && (!string.IsNullOrEmpty(contact)))
            {

                string updateQuery = "UPDATE Employee SET empName = '" + name + "', empAge = '" + age + "', empSalary = '" + salary + "', empCNIC = '" + cnic + "', empContact = '" + contact + "', deptId = '" + deptid + "' WHERE empId = " + id;

                if (db.UDI(updateQuery))
                {
                    resultlab.Text = "Update Succesfully";
                    Clear();
                }
                else
                {
                    resultlab.Text = "Not Updated Succesfully";
                }
            }
            else
            {
                resultlab.Text = "Enter the Credentials";
            }

        }
    }
}