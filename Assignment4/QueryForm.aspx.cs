using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4
{
    public partial class QueryForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["isEdit"])
            {
                Name_txt.Text = Session["Name"].ToString();
                Title_txt.Text = Session["Title"].ToString();
                Startdate_txt.Text = Session["Startdate"].ToString();
                Session["isEdit"] = false;
            }
        }

        protected void Submit_btn_Click(object sender, EventArgs e)
        {
            Session["NewName"] = Name_txt.Text.ToString();
            Session["NewTitle"] = Title_txt.Text.ToString();
            Session["NewStartdate"] = Startdate_txt.Text.ToString();
            if (ImgUpload.PostedFile.ContentLength.Equals("image/jpeg"))
            {
                Session["NewImg"] = Path.GetFileName(ImgUpload.FileName);
            }
            Response.Redirect("EmployeeTable.aspx");
        }

        protected void Cancel_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeTable.aspx");
        }
    }
}