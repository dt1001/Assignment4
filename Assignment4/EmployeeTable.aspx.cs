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
    public partial class EmployeeTable : System.Web.UI.Page
    {
        private string myConnection = "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database.accdb");
        OdbcConnection dbconn;
        DataTable table;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbconn = new OdbcConnection(myConnection);
            dbconn.Open();

            String selectAllQry = "Select * from Employees";
            OdbcCommand command = new OdbcCommand(selectAllQry, dbconn);
            OdbcDataAdapter adapt = new OdbcDataAdapter(command);
            table = new DataTable();
            adapt.Fill(table);
            Emp_lst.DataSource = table;
            Emp_lst.DataBind();
        }

        protected void Create_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("QueryForm.aspx");
            String query = "INSERT INTO Employees(Emp_name,Jobtitle,Startdate,Picblob) VALUES(?,?,?,?);";
            dbconn.Open();
            OdbcTransaction dbtrans = dbconn.BeginTransaction();
            OdbcCommand dbcmd = new OdbcCommand(query, dbconn, dbtrans);
            dbcmd.Parameters.Add("Emp_name", OdbcType.VarChar).Value = Session["NewName"];
            dbcmd.Parameters.Add("Jobtitle", OdbcType.VarChar).Value = Session["NewTitle"];
            dbcmd.Parameters.Add("Startdate", OdbcType.VarChar).Value = Session["NewStartdate"];
            dbcmd.Parameters.Add("Picblob", OdbcType.VarBinary).Value = Session["NewImg"];
            dbcmd.ExecuteNonQuery();
            dbtrans.Commit();
            dbconn.Close();
        }

        protected void Edit_btn_Click(object sender, EventArgs e)
        {
            Session["Name"] = Emp_lst.ToString();
            Session["Title"] = Emp_lst.ToString();
            Session["Startdate"] = Emp_lst.ToString();
            Response.Redirect("QueryForm.aspx");
            String query = "UPDATE Employees SET Emp_name=?, Jobtitle=?, Startdate=?, Picblob=? WHERE ID=?;";
            dbconn.Open();
            OdbcTransaction dbtrans = dbconn.BeginTransaction();
            OdbcCommand dbcmd = new OdbcCommand(query, dbconn, dbtrans);
            dbcmd.Parameters.Add("Emp_name", OdbcType.VarChar).Value = Session["NewName"];
            dbcmd.Parameters.Add("Jobtitle", OdbcType.VarChar).Value = Session["NewTitle"];
            dbcmd.Parameters.Add("Startdate", OdbcType.VarChar).Value = Session["NewStartdate"];
            dbcmd.Parameters.Add("Picblob", OdbcType.VarBinary).Value = Session["NewImg"];
            dbcmd.Parameters.Add("ID", OdbcType.Int).Value = Convert.ToInt32("temp");
            dbcmd.ExecuteNonQuery();
            dbtrans.Commit();
            dbconn.Close();
        }

        protected void Delete_btn_Click(object sender, EventArgs e)
        {
            String query = "DELETE FROM Employees WHERE ID=?";
            dbconn.Open();
            OdbcTransaction dbtrans = dbconn.BeginTransaction();
            OdbcCommand dbcmd = new OdbcCommand(query, dbconn, dbtrans);
            dbcmd.Parameters.Add("ID", OdbcType.Int).Value = Int32.Parse("temp");
            dbcmd.ExecuteNonQuery();
            dbtrans.Commit();
            dbconn.Close();
        }

        private byte[] ImgtoByte(Image img)
        {
            if (img == null)
            {
                return null;
            }
            using (MemoryStream stream = new MemoryStream())
            {
                //img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}