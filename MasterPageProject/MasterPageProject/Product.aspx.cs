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
    public partial class Product : System.Web.UI.Page
    {
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        JavaScriptSerializer serializer;
        string jsonData;
        string path;
        protected void Page_Load(object sender, EventArgs e)
        {
            serializer = new JavaScriptSerializer();
            path = Server.MapPath("product.json");
            StreamReader sr = new StreamReader(path);
            jsonData = sr.ReadToEnd();
            sr.Close();
            rows = serializer.Deserialize<List<Dictionary<string, object>>>(jsonData);
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }
       

        public void LoadGrid()
        {
            var data = rows.Select(x => new product
            {
                Id = x["id"].ToString(),
                Name = x["name"].ToString(),
                Description = x["description"].ToString(),
                Price = x["price"].ToString(),
                Quantity = x["quantity"].ToString(),
                Category = x["category"].ToString(),
                Brand = x["brand"].ToString(),
                Discount = x["discount"].ToString()
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
        public void ClearField()
        {
            TxtProductBrand.Text = "";
            TxtProductCategory.Text = "";
            TxtProductDescription.Text = "";
            TxtProductDiscount.Text = "";
            TxtProductId.Text = "";
            TxtProductName.Text = "";
            TxtProductPrice.Text = "";
            TxtQuantity.Text = "";
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Dictionary<string,object> row=new Dictionary<string,object>();

            row.Add("id",TxtProductId.Text);
            row.Add("name",TxtProductName.Text);
            row.Add("description",TxtProductDescription.Text);
            row.Add("price", TxtProductPrice.Text);
            row.Add("quantity",TxtQuantity.Text);
            row.Add("category",TxtProductCategory.Text);
            row.Add("brand",TxtProductBrand.Text);
            row.Add("discount",TxtProductDiscount.Text);

            rows.Add(row);
            SaveToJsonFile();
            LoadGrid();
            ClearField();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("id", TxtProductId.Text);

            row = rows.SingleOrDefault(x => row.All(x.Contains));
            row["id"] = TxtProductId.Text;
            row["name"]= TxtProductName.Text;
            row["description"]=TxtProductDescription.Text;
            row["price"]= TxtProductPrice.Text;
            row["quantity"]= TxtQuantity.Text;
            row["category"]= TxtProductCategory.Text;
            row["brand"]= TxtProductBrand.Text;
            row["discount"]=TxtProductDiscount.Text;
            SaveToJsonFile();
            LoadGrid();
            ClearField();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string sid = TxtProductId.Text;

            int fid = rows.FindIndex(x => x["id"].ToString() == sid);

            if (fid != 1)
            {
                Dictionary<string, object> frow = rows[fid];
                TxtProductId.Text = frow["id"].ToString();
                TxtProductName.Text = frow["name"].ToString();
                TxtProductDescription.Text = frow["description"].ToString();
                TxtProductPrice.Text = frow["price"].ToString();
                TxtQuantity.Text = frow["quantity"].ToString();
                TxtProductCategory.Text = frow["category"].ToString();
                TxtProductBrand.Text = frow["brand"].ToString();
                TxtProductDiscount.Text = frow["discount"].ToString();
                SaveToJsonFile();
                LoadGrid();
                
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            string sid = TxtProductId.Text;

            int did = rows.FindIndex(x => x["id"].ToString() == sid);
            if (did != -1)
            {
                rows.RemoveAt(did);
                SaveToJsonFile();
                LoadGrid();
                ClearField();
            }
        }
    }
    public class product
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        public string Quantity { get; set; }

        public string Category { get; set; }

        public string Brand { get; set; }

        public string Discount { get; set; }

    }
}