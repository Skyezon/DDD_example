using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asssignment_PSD_2201809140.Model;
using Asssignment_PSD_2201809140.Repository;

namespace Asssignment_PSD_2201809140.View.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        List<String> errorList = new List<string>();

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

        protected bool validateOldPassword(String oldPassword)
        {
            Users sessionUsers = (Users) Session["SessionAuthUser"];

            if (oldPassword.Equals(sessionUsers.Password))
            {
                return true;
            }
            else
            {
                errorList.Add("old password Must match with the password in database");
                return false;
            }
        }

        protected bool validatenewPassword(String newPassword)
        {
            if (newPassword.Length < 5)
            {
                errorList.Add("new Password must be longer than 5 character");
                return false;
            }
            else
            {
                return true;
            }
        }

        protected bool validateConfirmPassword(String confirmPassword)
        {
            if (confirmPassword.Equals(newPasswordInput.Text))
            {
                return true;
            }
            else
            {
                errorList.Add("confirm password must match new password");
                return false;
            }
        }

        protected bool validateAll(String oldPassword, String newPassword, String confirmPassword)
        {
            if (validateOldPassword(oldPassword) && validatenewPassword(newPassword) && validateConfirmPassword(confirmPassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            errorList.Clear();

            Users sessionUsers = (Users) Session["SessionAuthUser"];

            String oldPassword = oldPasswordInput.Text;
            String newPassword = newPasswordInput.Text;
            String confirmPassword = confirmPasswordInput.Text;

            if (validateAll(oldPassword,newPassword,confirmPassword))
            {
                AccountRepository.ChangePassword(sessionUsers,newPassword);
                Response.Redirect("../Home.aspx");
            }
            else
            {
                errorGrid.DataSource = errorList;
                errorGrid.DataBind();
                
            }
        }
    }
}