using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VPLabTask2
{
    public partial class Program : System.Web.UI.Page
    {
        DBConnect db=new DBConnect();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addbtn_Click(object sender, EventArgs e)
        {
            string insertQry = "insert into Program Values ('" + txtname.Text + "','" + txtdept.Text + "','" + txtbuild.Text + "')";
            if(db.UDI(insertQry))
            {
                resultlab.Text = "save Successfully";
                txtname.Text = "";
                txtdept.Text = "";
                txtbuild.Text = "";
            }
            else
            {
                resultlab.Text = "save not Successfully";
            }
        }

        protected void updatebtn_Click(object sender, EventArgs e)
        {
            string updateQry = "update   Program set pdepartment ='" + txtdept.Text + "', pbuilding ='" + txtbuild.Text + "' where pname = '" + txtname.Text+"'";
            if (db.UDI(updateQry))
            {
                resultlab.Text = "Update Successfully";
                txtname.Text = "";
                txtdept.Text = "";
                txtbuild.Text = "";
            }
            else
            {
                resultlab.Text = "Update not Successfully";
            }
        }
    }
}