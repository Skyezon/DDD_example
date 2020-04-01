using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Asssignment_PSD_2201809140.Model;
using Asssignment_PSD_2201809140.Repository;

namespace Asssignment_PSD_2201809140.View
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = loginButton.UniqueID;
            Page.Form.DefaultFocus = emailLogin.ClientID;

            if (Request.Cookies["authUserPasswordCookie"] != null)
            {
               if (!IsPostBack)
               {
                    emailLogin.Text = Request.Cookies["authUserEmailCookie"].Value;
                    passwordLogin.Attributes.Add("value",Request.Cookies["authUserPasswordCookie"].Value); 
                }
               
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
            passwordLogin.TextMode = TextBoxMode.Password;
        }

        protected void loginButtons_Click(object sender, EventArgs e)
        {
            String emailInput = emailLogin.Text;
            String passwordInput = passwordLogin.Text;

            Users user = AccountRepository.findUser(emailInput, passwordInput);

            if (user == null)
            {
                errorMessage.Visible = true;
            }else if (!user.Status.Equals("active"))
            {
                bannedMessage.Visible = true;
            }else
            {
                System.Diagnostics.Debug.WriteLine($"emailnya : {emailInput} passwordnya : {passwordInput}");
       
            
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
                Session["SessionAuthUsers"] = user;
                Session["SessionAuthUser"] = user;

                System.Diagnostics.Debug.WriteLine("berhasil login jadi session harusnya ke buat");

                Response.Redirect("Home.aspx");

            }

        }
    }
}