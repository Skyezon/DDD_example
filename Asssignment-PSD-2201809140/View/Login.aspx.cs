using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asssignment_PSD_2201809140.Model;
using Asssignment_PSD_2201809140.Repository;

namespace Asssignment_PSD_2201809140.View
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Request.Cookies["authUserPasswordCookie"] != null)
            {
                emailLogin.Text = Request.Cookies["authUserEmailCookie"].Value;
                passwordLogin.Text = Request.Cookies["authUserPasswordCookie"].Value;
            }

            if (Session["SessionAuthUser"] != null)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {

            }
            errorMessage.Visible = false;
            bannedMessage.Visible = false;
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            String emailInput = emailLogin.Text;
            String passwordInput = passwordLogin.Text;

            Users user = AccountRepository.findUser(emailInput, passwordInput);

            if (AccountRepository.ifCredNull(emailInput,passwordInput))
            {
                errorMessage.Visible = true;
            }else if (!user.Status.Equals("allowed"))
            {
                bannedMessage.Visible = true;
            }
            else
            {
                Session["SessionAuthUser"] = user;
                if (rememberMeCheckBox.Checked)
                {
                    Response.Cookies["authUserEmailCookie"].Value = emailInput;
                    Response.Cookies["authUserPasswordCookie"].Value = passwordInput;

                    Response.Cookies["authUserEmailCookie"].Expires = DateTime.Now.AddHours(1);
                    Response.Cookies["authUserPasswordCookie"].Expires = DateTime.Now.AddHours(1);
                }
                else
                {

                }
                
                Response.Redirect("Home.aspx");

            }

        }
    }
}