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
    public partial class Student : System.Web.UI.Page
    {
        List<Dictionary<string, object>> rows;
        JavaScriptSerializer serializer;
        string jsonData;
        string path;

        protected void Page_Load(object sender, EventArgs e)
        {
            serializer = new JavaScriptSerializer();
            path = Server.MapPath("student.json");
            StreamReader streamReader = new StreamReader(path);
            jsonData = streamReader.ReadToEnd();
            streamReader.Close();
            rows = serializer.Deserialize<List<Dictionary<string, object>>>(jsonData);
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

      

        public void LoadGrid()
        {
            var data = rows.Select(x => new StudentRecord
            {
                RollNo = x["rollno"].ToString(),
                Name = x["name"].ToString(),
                Age = x["age"].ToString(),
                Program = x["program"].ToString(),
                Semester = x["semester"].ToString(),
                Department = x["department"].ToString(),
                Email = x["email"].ToString(),
                CGPA = x["cgpa"].ToString()
            });

            GridUser.DataSource = data;
            GridUser.DataBind();
        }
        public void SaveToJsonFile()
        {
            jsonData = serializer.Serialize(rows);
            StreamWriter sw = new StreamWriter(path);
            if (jsonData != null)
            {
                sw.WriteLine(jsonData);
            }
            sw.Close();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("rollno", TxtRollNo.Text);
            row.Add("name", TxtName.Text);
            row.Add("age", TxtAge.Text);
            row.Add("program", TxtProgram.Text);
            row.Add("semester", TxtSemester.Text);
            row.Add("department", TxtDepartment.Text);
            row.Add("email", TxtEmail.Text);
            row.Add("cgpa", TxtCGPA.Text);
            rows.Add(row);
            SaveToJsonFile();
            LoadGrid();
            Reset();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string rollNo = TxtRollNo.Text;
            Dictionary<string, object> existingRow = rows.SingleOrDefault(x => x["rollno"].ToString() == rollNo);

            if (existingRow != null)
            {
                existingRow["rollno"]=TxtRollNo.Text;
                existingRow["name"] = TxtName.Text;
                existingRow["age"] = TxtAge.Text;
                existingRow["program"] = TxtProgram.Text;
                existingRow["semester"] = TxtSemester.Text;
                existingRow["department"] = TxtDepartment.Text;
                existingRow["email"] = TxtEmail.Text;
                existingRow["cgpa"] = TxtCGPA.Text;

                SaveToJsonFile();
                LoadGrid();
                Reset();
            }
            else
            {
               
            }
        }

        /*protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("rollno", TxtRollNo.Text);
            row = rows.SingleOrDefault(x => row.All(x.Contains));
            row["rollno"] = TxtRollNo.Text;
            row["name"] = TxtName.Text;
            row["age"] = TxtAge.Text;
            row["program"] = TxtProgram.Text;
            row["semester"] = TxtSemester.Text;
            row["department"] = TxtDepartment.Text;
            row["email"] = TxtEmail;
            row["cgpa"] = TxtCGPA.Text;

            SaveToJsonFile();
            LoadGrid();
            Reset();
            
        }*/

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string rollno = TxtRollNo.Text;

            int sroll = rows.FindIndex(x => x["rollno"].ToString() == rollno);
           if (sroll != -1)
            {
                Dictionary<string, object> frow = rows[sroll];
                TxtRollNo.Text = frow["rollno"].ToString();
                TxtName.Text = frow["name"].ToString();
                TxtAge.Text = frow["age"].ToString();
                TxtProgram.Text = frow["program"].ToString();
                TxtSemester.Text = frow["semester"].ToString();
                TxtDepartment.Text = frow["department"].ToString();
                TxtEmail.Text = frow["email"].ToString();
                TxtCGPA.Text = frow["cgpa"].ToString();
                //SaveDataToStudentJson();
                //LoadGrid();
            }
        }

        public void Reset()
        {
            TxtRollNo.Text = "";
            TxtName.Text = "";
            TxtAge.Text = "";
            TxtProgram.Text = "";
            TxtSemester.Text = "";
            TxtDepartment.Text = "";
            TxtEmail.Text = "";
            TxtCGPA.Text = "";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string drollno = TxtRollNo.Text;
            int droll = rows.FindIndex(x => x["rollno"].ToString() == drollno);
            if (droll != -1)
            {
                rows.RemoveAt(droll);
                SaveToJsonFile();
                LoadGrid();
                Reset();
            }
        }
    }
    public class StudentRecord
    {
        public string RollNo { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Program { get; set; }
        public string Semester { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string CGPA { get; set; }
    }

}
