using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asssignment_PSD_2201809140.Model;

namespace Asssignment_PSD_2201809140.View
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Users sessionUsers = (Users)Session["SessionAuthUser"];

            if (sessionUsers == null)
            {
                Response.Redirect("../Home.aspx");
            }

            profileEmail.Text = sessionUsers.Email;
            profileGender.Text = sessionUsers.Gender;
            profileName.Text = sessionUsers.Name;
        }

        protected void updateProfileButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProfile.aspx");
        }

        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }
    }
}