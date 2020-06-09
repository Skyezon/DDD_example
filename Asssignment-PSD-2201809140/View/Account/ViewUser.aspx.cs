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
    public partial class ViewUser : System.Web.UI.Page
    {
        AccountController accountController = new AccountController();
        protected void Page_Load(object sender, EventArgs e)
        {
            Users thisUsers = (Users)Session["SessionAuthUser"];
            if (thisUsers == null ? true : !thisUsers.Roles.Name.Equals("admin"))
            {
                Response.Redirect("../Home.aspx");
            }

            List<Users> userList = accountController.GetUsers();
            userList.Remove(thisUsers);

            userGrid.DataSource = userList;
            userGrid.DataBind();
        }

        protected void toogleStatusButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            //Get the row that contains this button
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            int rowIndex = row.RowIndex;

            String userId = userGrid.Rows[rowIndex].Cells[2].Text;
            accountController.ToggleStatus(Convert.ToInt32(userId));
            Response.Redirect("ViewUser.aspx");
        }

        protected void toogleRoleButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            GridViewRow row = (GridViewRow) btn.NamingContainer;

            int rowIndex = row.RowIndex;
            String Id = userGrid.Rows[rowIndex].Cells[2].Text;
            accountController.ToogleRole(Convert.ToInt32(Id));
            Response.Redirect("ViewUser.aspx");
        }
    }
}