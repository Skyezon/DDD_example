using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asssignment_PSD_2201809140.Controller;
using Asssignment_PSD_2201809140.Model;
using String = System.String;

namespace Asssignment_PSD_2201809140.View
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        AccountController accountController = new AccountController();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = regisButton.UniqueID;
            Page.Form.DefaultFocus = emailRegis.ClientID;

            if (Session["SessionAuthUser"] != null)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {

            }
        }

       
        protected void regisButton_Click(object sender, EventArgs e)
        {
            accountController.errorList.Clear();
            listOfError.DataSource = null;
            
            if (accountController.checkAllValidation(passwordRegis.Text,confirmPasswordRegis.Text,genderRegis.Text,nameRegis.Text,emailRegis.Text))
            {
                
                accountController.insertUser(emailRegis.Text, nameRegis.Text, passwordRegis.Text,
                    genderRegis.Text);
                Response.Redirect("Login.aspx");

            }
            else
            {
                listOfError.DataSource = accountController.errorList;
                listOfError.DataBind();
            }
        }
    }
}