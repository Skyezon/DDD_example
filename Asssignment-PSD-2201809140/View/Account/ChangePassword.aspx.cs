using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asssignment_PSD_2201809140.Controller;
using Asssignment_PSD_2201809140.Model;

namespace Asssignment_PSD_2201809140.View.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        AccountController accountController = new AccountController();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = changePasswordButton.UniqueID;
            Page.Form.DefaultFocus = oldPasswordInput.ClientID;

            Users sessionUsers = (Users) Session["SessionAuthUser"];

            if (sessionUsers == null)
            {
                Response.Redirect("../Home.aspx");
            }
        }

        

        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            accountController.errorList.Clear();

            Users sessionUsers = (Users) Session["SessionAuthUser"];

            String oldPassword = oldPasswordInput.Text;
            String newPassword = newPasswordInput.Text;
            String confirmPassword = confirmPasswordInput.Text;

            if (accountController.validateAll(oldPassword,newPassword,confirmPassword,sessionUsers))
            {
                accountController.ChangePassword(sessionUsers,newPassword);
                Response.Redirect("../Home.aspx");
            }
            else
            {
                errorGrid.DataSource = accountController.errorList;
                errorGrid.DataBind();
                
            }
        }
    }
}