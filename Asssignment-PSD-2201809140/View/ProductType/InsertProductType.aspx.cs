using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asssignment_PSD_2201809140.Controller;
using Asssignment_PSD_2201809140.Model;

namespace Asssignment_PSD_2201809140.View.ProductType
{
    public partial class InsertProductType : System.Web.UI.Page
    {
        ProductTypeController productTypeController = new ProductTypeController();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = productInsertButton.UniqueID;
            Page.Form.DefaultFocus = productTypeName.ClientID;

            Users sessionUser = (Users)Session["SessionAuthUser"];

            if (sessionUser == null ? true : !sessionUser.Roles.Name.Equals("admin"))
            {
                Response.Redirect("../Home.aspx");
            }
            else
            {
                
            }
        }

        

        protected void productInsertButton_Click(object sender, EventArgs e)
        {
            productTypeController.errorList.Clear();
            String productName = productTypeName.Text;
            String productDesc = productTypeDescription.Text;
            if (productTypeController.validateAll(productName,productDesc))
            {
                productTypeController.InsertProductType(productName,productDesc);
                Response.Redirect("ViewProductType.aspx");
            }
            else
            {
                errorGrid.DataSource = productTypeController.errorList;
                errorGrid.DataBind();
            }
        }
    }
}