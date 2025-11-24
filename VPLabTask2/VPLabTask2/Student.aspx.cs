using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VPLabTask2
{
   
    public partial class Student : System.Web.UI.Page
    {
        DBConnect db = new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataLoad();
                GridLoad();
            }
        }
        public void GridLoad()
        {
            string qry = "select * from Student";
            gridstu.DataSource = db.Search(qry);
            gridstu.DataBind();
        }
        public void DataLoad()
        {
            string qry = "select * from Program";
            ddlprogram.DataSource= db.Search(qry);
            ddlprogram.DataTextField = "pname";
            ddlprogram.DataValueField = "pid";
            ddlprogram.DataBind();

        }
        protected void ddlprogram_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pid = ddlprogram.SelectedValue;
            string qry = "SELECT  pdepartment, pbuilding FROM Program WHERE pid='" +Convert.ToInt32(pid) + "'";
            DataTable dt = db.Search(qry);

            if (dt.Rows.Count > 0)
            {
                string pdepartment = dt.Rows[0]["pdepartment"].ToString();
                string pbuilding = dt.Rows[0]["pbuilding"].ToString();

                txtbuild.Text = pbuilding;
                txtdept.Text = pdepartment;
              
            }
        } 
       
        public void Clear()
        {
            txtName.Text = "";
            txtRollNo.Text = "";
            txtdept.Text = "";
            txtcgpa.Text = "";
            txtbuild.Text = "";
            r1.Checked= false;
            r2.Checked= false;
            ddlsemester.SelectedValue = null;
        }

        protected void addbtn_Click(object sender, EventArgs e)
        {
            string gender;
            if (r1.Checked)
            {
                gender = "Male";
            }
            else if (r2.Checked)
            {
                gender = "Female";
            }
            else
            {
                relab.Text = "Please select the gender.";
                return;
            }

            string semester = ddlsemester.SelectedValue;
            if (string.IsNullOrEmpty(semester))
            {
                relab.Text = "Please select the semester.";
            }
            else
            {
                string InsertQuery = "INSERT INTO Student VALUES ('" + txtName.Text + "','" + Convert.ToInt32(txtRollNo.Text) + "','" + gender + "','" + Convert.ToInt32(ddlprogram.SelectedValue) + "','" + semester + "','" + Convert.ToDecimal(txtcgpa.Text) + "')";
                if (db.UDI(InsertQuery))
                {
                    relab.Text = "Saved successfully.";
                    Clear();
                }
                else
                {
                    relab.Text = "Failed to save.";
                }
            }
        }


        protected void updatbtn_Click(object sender, EventArgs e)
        {
            string gender;
            if (r1.Checked)
            {
                gender = "Male";
            }
            else if (r2.Checked)
            {
                gender = "Female";
            }
            else
            {
                relab.Text = "select the gender";
                return;
            }
            int rollno = Convert.ToInt32(txtRollNo.Text);
            string semester = ddlsemester.SelectedValue;
            string UpdateQuery = "UPDATE Student SET sname = '" + txtName.Text + "', sgender = '" + gender + "', pid = '" + Convert.ToInt32(ddlprogram.SelectedValue) + "', ssemester = '" + semester + "', scgpa = '" + Convert.ToDecimal(txtcgpa.Text) + "' WHERE srollno = '" + rollno + "'";
            if (db.UDI(UpdateQuery)) 
            {
                relab.Text = "update successfully";
                Clear();
            }
            else
            {
                relab.Text = "update not  successfully";
            }
        }

        protected void selectbtn_Click(object sender, EventArgs e)
        {
            int rollno = Convert.ToInt32(txtRollNo.Text);
            string searchqry = "SELECT * FROM Student WHERE srollno = '" + rollno + "'";
            DataTable dt = db.Search(searchqry);
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["sname"].ToString();
                string gender = dt.Rows[0]["sgender"].ToString();
                if (gender == "Male")
                {
                    r1.Checked = true;
                }
                else
                {
                    r2.Checked = true;
                }
                string id = dt.Rows[0]["pid"].ToString();
                if (id != null)
                {
                    string qry = "SELECT  pdepartment, pbuilding FROM Program WHERE pid='" + Convert.ToInt32(id) + "'";
                    DataTable dtt = db.Search(qry);

                    if (dtt.Rows.Count > 0)
                    {
                        string pdepartment = dtt.Rows[0]["pdepartment"].ToString();
                        string pbuilding = dtt.Rows[0]["pbuilding"].ToString();

                        txtbuild.Text = pbuilding;
                        txtdept.Text = pdepartment;

                    }
                }
                    ddlsemester.SelectedValue = dt.Rows[0]["ssemester"].ToString(); 
                txtcgpa.Text = dt.Rows[0]["scgpa"].ToString(); 
            }
        }

        protected void deletebtn_Click(object sender, EventArgs e)
        {
            int rollno = Convert.ToInt32(txtRollNo.Text);
            string DeleteQry = "delete from   Student where srollno ='"+rollno + "'";
            if (db.UDI(DeleteQry))
            {
                relab.Text = "delete successfully";
                Clear();
            }
            else
            {
                relab.Text = "delete not  successfully";
            }
        }
    }
}