using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asssignment_PSD_2201809140.Model;

namespace Asssignment_PSD_2201809140.View.Master
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Users sessionUser = (Users)Session["SessionAuthUser"];
            System.Diagnostics.Debug.WriteLine(sessionUser == null ? "session tidak ada" : "session true");

            if (sessionUser == null)
            {
                username.Text = "Guest";
                viewProductButton.Visible = true;
                viewProfileButton.Visible = false;
                logoutButton.Visible = false;
                registerButton.Visible = true;
            
                return;
            }
            else if (sessionUser.Roles.Name.Equals("member") || sessionUser.Roles.Name.Equals("admin"))
            {
                username.Text = sessionUser.Name;
                viewProductButton.Visible = true;
                viewProfileButton.Visible = true;
                logoutButton.Visible = true;
                loginButtonpage.Visible = false;
                registerButton.Visible = false;
            }

        }

        protected void viewProductButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Product/ViewProduct.aspx");
        }

        protected void viewProfileButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Account/Profile.aspx");
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/View/Home.aspx");
        }

        protected void loginButtonlagi_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Login.aspx");
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Register.aspx");
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home.aspx");
        }
    }
}