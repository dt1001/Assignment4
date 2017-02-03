using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4
{
    public partial class Login : System.Web.UI.Page
    {
        private const String user = "admin";
        private const String password = "a";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
         
        protected void Login_Click(object sender, EventArgs e)
        {
            
            if (Username_txt.Text.Equals(user) && Password_txt.Text.Equals(password)){
                Response.Redirect("EmployeeTable.aspx");
            }
            else
            {
                Error_lbl.Text = "Username or Password is incorrect";
            }
        }
    }
}