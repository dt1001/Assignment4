using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4
{
    public partial class QueryForm : System.Web.UI.Page
    {
        private string myConnection = "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database.accdb");
        private OdbcConnection dbconn;
        String id;
        protected void Page_Load(object sender, EventArgs e)
        {
            //check if logged in
            if (Session["login"] == null || !(bool)Session["Login"])
            {
                Response.Redirect("Login.aspx");
            }
            id = Request.QueryString["id"];
            dbconn = new OdbcConnection(myConnection);
            if ((bool)Session["isEdit"] && (id != null) && !id.Equals("") )
            {    
                DataTable table = new DataTable();
                dbconn.Open();
                String query = "Select * from Employees where ID=?";
                OdbcCommand dbcmd = new OdbcCommand(query,dbconn);
                dbcmd.Parameters.Add("ID", OdbcType.Int).Value = Int32.Parse(id);
                OdbcDataAdapter adapt = new OdbcDataAdapter(dbcmd);
                //get record
                adapt.Fill(table);
                table.Columns.Add("img_url");
                ConvertImg(table);
                dbconn.Close();
                //fill fields
                Name_txt.Text = table.Rows[0]["Emp_name"].ToString();
                Title_txt.Text = table.Rows[0]["JobTitle"].ToString();
                Startdate_txt.Text = table.Rows[0]["Startdate"].ToString();
                Img.Src = table.Rows[0]["img_url"].ToString();
            }
        }

        protected void Submit_btn_Click(object sender, EventArgs e)
        {
            byte[] imgarr = null;
            String query;
            //get image
            if (ImgUpload.HasFile)
            {
                String path = Server.MapPath(Path.GetFileName(ImgUpload.FileName));
                ImgUpload.SaveAs(path);
                imgarr = UrlToByteArr(path);
                
            }
            //set query
            if ((bool)Session["isEdit"])
            {
                if (imgarr!=null) {
                    query = "UPDATE Employees SET Emp_name=?, Jobtitle=?, Startdate=?, Picblob=? WHERE ID=?;";
                }
                else
                {
                    query = "UPDATE Employees SET Emp_name=?, Jobtitle=?, Startdate=? WHERE ID=?;";
                }
            }
            else
            {
                query = "INSERT INTO Employees(Emp_name,Jobtitle,Startdate,Picblob) VALUES(?,?,?,?);";
            }
            //execute sql
            dbconn.Open();
            OdbcTransaction dbtrans = dbconn.BeginTransaction();
            OdbcCommand dbcmd = new OdbcCommand(query, dbconn, dbtrans);
            dbcmd.Parameters.Add("Emp_name", OdbcType.VarChar).Value = Name_txt.Text;
            dbcmd.Parameters.Add("Jobtitle", OdbcType.VarChar).Value = Title_txt.Text;
            dbcmd.Parameters.Add("Startdate", OdbcType.VarChar).Value = Startdate_txt.Text;
            if (imgarr != null)//if user gives a new image
            {
                dbcmd.Parameters.Add("Picblob", OdbcType.VarBinary).Value = imgarr;
            }
            if ((bool)Session["isEdit"])//if editing an entry
            {
                dbcmd.Parameters.Add("ID", OdbcType.Int).Value = Int32.Parse(id);
            }
            dbcmd.ExecuteNonQuery();
            //commit and end transaction
            dbtrans.Commit();
            dbconn.Close();
            //reset edit session state
            Session["isEdit"] = false;
            Response.Redirect("EmployeeTable.aspx");
        }

        protected void Cancel_btn_Click(object sender, EventArgs e)
        {
            Session["isEdit"] = false;
            Response.Redirect("EmployeeTable.aspx");
        }

        private byte[] UrlToByteArr(String img)
        {
            FileStream fs = new FileStream(img, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] imgarr = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            return imgarr;
        }

        private void ConvertImg(DataTable table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i]["Picblob"] != DBNull.Value)
                {
                    byte[] bytes = (byte[])table.Rows[i]["Picblob"];
                    string temp = Convert.ToBase64String(bytes, 0, bytes.Length);
                    table.Rows[i]["img_url"] = "data:image/jpeg;base64," + temp;
                }
            }
        }
    }
}