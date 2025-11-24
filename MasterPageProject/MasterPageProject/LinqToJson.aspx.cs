using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageProject
{
    public partial class LinqToJson : System.Web.UI.Page
    {
        List<Dictionary<string, object>> rows;
        JavaScriptSerializer serializer;
        string jsonData;
        string path;

        protected void Page_Load(object sender, EventArgs e)
        {
            serializer=new JavaScriptSerializer();
            path = Server.MapPath("users.json");
            StreamReader reader= new StreamReader(path);
            jsonData=reader.ReadToEnd();
            reader.Close();
            rows = serializer.Deserialize<List<Dictionary<string, object>>>(jsonData);
            if (!IsPostBack)
            {
                LoadGridData();
            }

        }
        public void btnSave_Click(object sender, EventArgs e)
        {
            Dictionary<string,object> row= new Dictionary<string,object>();
            row.Add("name", TxtName.Text);
            row.Add("email", TxtEmail.Text);
            row.Add("cnic", TxtCNIC.Text);
            rows.Add(row);
            SaveDataToJsonFile();
            LoadGridData();
            ClearText();
        }
        public void SaveDataToJsonFile()
        {
            jsonData = serializer.Serialize(rows);
            StreamWriter streamWriter = new StreamWriter(path);
            if(jsonData != null)
            {
                streamWriter.WriteLine(jsonData);
            }
            streamWriter.Close();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Dictionary<string,object> row=new Dictionary<string,object>();
            row.Add("email",TxtEmail.Text);
            row = rows.SingleOrDefault(x => row.All(x.Contains));
            //row = rows.FirstOrDefault(x => row.All(x.Contains));
            row["name"]=TxtName.Text;
            row["email"]=TxtEmail.Text;
            row["cnic"]=TxtCNIC.Text;
            SaveDataToJsonFile();
            LoadGridData();
            ClearText();
        }

        public  void ClearText()
        {
            TxtEmail.Text = "";
            TxtCNIC.Text = "";
            TxtName.Text = "";
        }
        public void LoadGridData()
        {
           
            var data = rows.Select(x => new User
            {
                Name = x["name"].ToString(),
                Email = x["email"].ToString(),
                CNIC = x["cnic"].ToString()
            }) ;
            GridUser.DataSource = data;
            GridUser.DataBind();


        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string emailSearch=TxtEmail.Text;

            int searchEmail=rows.FindIndex(x => x["email"].ToString() == emailSearch);

            if (searchEmail>0)
            {
                Dictionary<string, object> frow = rows[searchEmail];
                TxtName.Text=frow["name"].ToString() ;
                TxtEmail.Text =frow["email"].ToString();
                TxtCNIC.Text=frow["cnic"].ToString();
                SaveDataToJsonFile();
                LoadGridData();
            }
            else
            {
                 
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
           string emailToDelete=TxtEmail.Text;

            int  deleteIndex=rows.FindIndex(x => x["email"].ToString()==emailToDelete);

            if(deleteIndex != -1)
            {
                rows.RemoveAt(deleteIndex);
                SaveDataToJsonFile();
                LoadGridData();
                ClearText();
            }
            else
            {

            }
        }
    }
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CNIC { get; set; }
    }
}