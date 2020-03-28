using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asssignment_PSD_2201809140.Factory;
using Asssignment_PSD_2201809140.Model;
using Asssignment_PSD_2201809140.Repository;
using String = System.String;

namespace Asssignment_PSD_2201809140.View
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        List<String> errorList = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SessionAuthUser"] != null)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {

            }
        }

        protected bool validateEmail()
        {
            if (String.IsNullOrEmpty(emailRegis.Text.ToString()) || AccountRepository.ifEmailExist(emailRegis.Text))
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
            if (String.IsNullOrEmpty(nameRegis.Text.ToString()))
            {
                errorList.Add("Must be filled");
                return false;
            }
            else
            {
                return true;
            }
        }

        protected bool validatePassword()
        {
            if (String.IsNullOrEmpty(passwordRegis.Text.ToString()))
            {
                errorList.Add("Must be filled");

                return false;
            }
            else
            {
                return true;
            }
        }

        protected bool validateConfirmPassword()
        {
            if (passwordRegis.Text.ToString().Equals(confirmPasswordRegis.Text.ToString()))
            {
                return true;
            }
            else
            {
                errorList.Add("Must be same with password");
                return false;
            }
        }

        protected bool validateGender()
        {
            String genderValue = genderRegis.SelectedValue;
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
            bool ispasswordGud = validatePassword();
            bool isconfirmGud = validateConfirmPassword();
            bool isgenderGud = validateGender();
            if (isemailGud && isnameGud && ispasswordGud && isconfirmGud && isgenderGud)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        protected void regisButton_Click(object sender, EventArgs e)
        {
            errorList.Clear();
            listOfError.DataSource = null;
            
            if (checkAllValidation())
            {
                userFactory userPabrik =  new userFactory();
                Users userBaru = userPabrik.CreateUser(emailRegis.Text, nameRegis.Text, passwordRegis.Text,
                    genderRegis.Text);
                AccountRepository.insertUser(userBaru);
                Response.Redirect("Login.aspx");
            }
            else
            {
                listOfError.DataSource = errorList;
                listOfError.DataBind();
            }
        }
    }
}