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
    public partial class UpdateProfile : System.Web.UI.Page
    {
        AccountController accountController = new AccountController();
     
        protected void Page_Load(object sender, EventArgs e)
        {

            Page.Form.DefaultButton = profileUpdateButton.UniqueID;
            Page.Form.DefaultFocus = emailInput.ClientID;

            Users sessionUsers = (Users)Session["SessionAuthUser"];

            if (!IsPostBack)
            {
                emailInput.Text = sessionUsers.Email;
                genderInput.SelectedValue = sessionUsers.Gender;
                nameInput.Text = sessionUsers.Name;

            }
        }

       

        protected void profileUpdateButton_Click(object sender, EventArgs e)
        {  
            accountController.errorList.Clear();

            String emailInput = this.emailInput.Text;
            String genderInput = this.genderInput.SelectedValue;
            String nameInput = this.nameInput.Text;

            if (accountController.checkAllValidationUpdate(emailInput,nameInput,genderInput))
            {
                Users sessionUsers = (Users)Session["SessionAuthUser"];

                accountController.UpdateProfile(sessionUsers,emailInput,nameInput,genderInput);
                Response.Redirect("Profile.aspx");
            }
            else
            {
                errorGrid.DataSource = accountController.errorList;
                errorGrid.DataBind();
            }

        }
    }
}