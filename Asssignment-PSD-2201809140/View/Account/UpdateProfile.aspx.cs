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
    public partial class UpdateProfile : System.Web.UI.Page
    {

        List<String> errorList = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Users sessionUsers = (Users)Session["SessionAuthUser"];

            if (!IsPostBack)
            {
                emailInput.Text = sessionUsers.Email;
                genderInput.SelectedValue = sessionUsers.Gender;
                nameInput.Text = sessionUsers.Name;

            }
        }

        protected bool validateEmail()
        {
            if (String.IsNullOrEmpty(emailInput.Text.ToString()) || AccountRepository.ifEmailExist(emailInput.Text))
            {
                errorList.Add("Must be filled and unique");
                return false;
            }
            else
            {
                return true;
            }
        }

        protected bool validateName()
        {
            if (String.IsNullOrEmpty(nameInput.Text))
            {
                errorList.Add("Must be filled");
                return false;
            }
            else
            {
                return true;
            }
        }

        protected bool validateGender()
        {
            String genderValue = genderInput.SelectedValue;
            if (String.IsNullOrEmpty(genderValue))
            {
                errorList.Add("Must be chosen");
                return false;
            }
            else
            {
                return true;
            }
        }

        protected bool checkAllValidation()
        {
            bool isemailGud = validateEmail();
            bool isnameGud = validateName();
            bool isgenderGud = validateGender();
            if (isemailGud && isnameGud &&  isgenderGud)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        protected void profileUpdateButton_Click(object sender, EventArgs e)
        {
            errorList.Clear();

            String emailInput = this.emailInput.Text;
            String genderInput = this.genderInput.SelectedValue;
            String nameInput = this.nameInput.Text;

            if (checkAllValidation())
            {
                Users sessionUsers = (Users)Session["SessionAuthUser"];

                AccountRepository.UpdateProfile(sessionUsers,emailInput,nameInput,genderInput);
                Response.Redirect("Profile.aspx");
            }
            else
            {
                errorGrid.DataSource = errorList;
                errorGrid.DataBind();
            }

        }
    }
}