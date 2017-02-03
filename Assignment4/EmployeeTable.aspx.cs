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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null || !(bool)Session["Login"])
            {
                Response.Redirect("Login.aspx");
            }
            dbconn = new OdbcConnection(myConnection);
            dbconn.Open();

            String selectAllQry = "Select * from Employees";
            OdbcCommand command = new OdbcCommand(selectAllQry, dbconn);
            OdbcDataAdapter adapt = new OdbcDataAdapter(command);
            DataTable table = new DataTable();
            adapt.Fill(table);
            //get images
            table.Columns.Add("img_url");
            ConvertImg(table);
            //bind table
            Emp_lst.DataSource = table;
            Emp_lst.DataBind();
            dbconn.Close();
        }

        //
        protected void Create_btn_Click(object sender, EventArgs e)
        {
            Session["isEdit"] = false;
            Response.Redirect("QueryForm.aspx");
        }

        protected void Edit_btn_Click(object sender, EventArgs e)
        {
            Session["isEdit"] = true;
            Response.Redirect("QueryForm.aspx?id="+Request.Form["ID"]);
        }

        protected void Delete_btn_Click(object sender, EventArgs e)
        {
            if (Request.Form["ID"] != null)
            {
                String query = "DELETE FROM Employees WHERE ID=?";
                dbconn.Open();
                OdbcTransaction dbtrans = dbconn.BeginTransaction();
                OdbcCommand dbcmd = new OdbcCommand(query, dbconn, dbtrans);
                dbcmd.Parameters.Add("ID", OdbcType.Int).Value = Request.Form["ID"];
                dbcmd.ExecuteNonQuery();
                dbtrans.Commit();
                dbconn.Close();
                Response.Redirect("EmployeeTable.aspx");
            }
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