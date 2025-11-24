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
    public partial class Doctor : System.Web.UI.Page
    {
        private List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

        JavaScriptSerializer serializer;
        string jsonData;
        string path;

        protected void Page_Load(object sender, EventArgs e)
        {
            serializer = new JavaScriptSerializer();
            path=Server.MapPath("doctor.json");
            StreamReader sr = new StreamReader(path);
            jsonData=sr.ReadToEnd();
            sr.Close();
            rows=serializer.Deserialize<List<Dictionary<string, object>>>(jsonData);
            if (!IsPostBack)
            {
                LoadGrid();
            }

        }
        public void SaveToJsonFile()
        {
            jsonData=serializer.Serialize(rows);
            StreamWriter sw= new StreamWriter(path);
            if(jsonData != null )
            {
                sw.WriteLine(jsonData);
            }
            sw.Close();
        }

        public void LoadGrid()
        {
            var data = rows.Select(x => new doctorRecord {
                Id = x["id"].ToString(),
                Name = x["name"].ToString(),
                Speciality = x["speciality"].ToString(),
                Age = x["age"].ToString(),
                Email = x["email"].ToString(),
                Phone = x["phone"].ToString(),
                Experience = x["experience"].ToString(),
                Hospital = x["hospital"].ToString()
            });
            GridUser.DataSource = data;
            GridUser.DataBind();
        }
        public void ClearField()
        {
            TxtAge.Text = "";
            TxtEmail.Text = "";
            TxtExperience.Text = "";
            TxtHospital.Text = "";
            TxtId.Text = "";
            TxtName.Text = "";
            TxtPhone.Text = "";
            TxtSpecialty.Text = "";
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Dictionary<string,object> row=new Dictionary<string, object>();
            row.Add("id",TxtId.Text);
            row.Add("name", TxtName.Text);
            row.Add("speciality", TxtSpecialty.Text);
            row.Add("age", TxtAge.Text);
            row.Add("email", TxtEmail.Text);
            row.Add("phone", TxtPhone.Text);
            row.Add("experience", TxtExperience.Text);
            row.Add("hospital", TxtHospital.Text);
            rows.Add(row);
            SaveToJsonFile();
            LoadGrid();
            ClearField();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("id", TxtId.Text);

            row = rows.SingleOrDefault(x => row.All(x.Contains));

            row["id"] = TxtId.Text;
            row["name"] = TxtName.Text;
            row["speciality"] = TxtSpecialty.Text;
            row["age"] = TxtAge.Text;
            row["email"] = TxtEmail.Text;
            row["phone"] = TxtPhone.Text;
            row["experience"] = TxtExperience.Text;
            row["hospital"] = TxtHospital.Text;
            SaveToJsonFile();
            LoadGrid();
            ClearField();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string sid = TxtId.Text;

            int fid = rows.FindIndex(x => x["id"].ToString() == sid);

            if (fid != -1)
            {
                Dictionary<string, object> frow = rows[fid];
                TxtId.Text = frow["id"].ToString();
                TxtName.Text = frow["name"].ToString();
                TxtSpecialty.Text = frow["speciality"].ToString();
                TxtAge.Text = frow["age"].ToString();
                TxtEmail.Text = frow["email"].ToString();
                TxtPhone.Text = frow["phone"].ToString();
                TxtExperience.Text = frow["experience"].ToString();
                TxtHospital.Text = frow["hospital"].ToString();
                LoadGrid();
                
            }

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
          string delid=TxtId.Text;
            int iddel = rows.FindIndex(x => x["id"].ToString() == delid);
            if (iddel != -1)
            {
                rows.RemoveAt(iddel);
                SaveToJsonFile();
                LoadGrid();
                ClearField();
            }

        }
    }
    public class doctorRecord
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Speciality { get; set; }

        public string Age { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Experience { get; set; }

        public string Hospital { get; set; }

    }
}