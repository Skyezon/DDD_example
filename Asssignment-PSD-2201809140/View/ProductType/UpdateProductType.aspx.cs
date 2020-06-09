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
    public partial class UpdateProductType : System.Web.UI.Page
    {
        ProductTypeController productTypeController = new ProductTypeController();
        protected void Page_Load(object sender, EventArgs e)
        {

            Page.Form.DefaultButton = productUpdateButton.UniqueID;
            Page.Form.DefaultFocus = productTypeName.ClientID;

            Users sessionUser = (Users)Session["SessionAuthUser"];
            if (sessionUser == null ? true : !sessionUser.Roles.Name.Equals("admin"))
            {
                Response.Redirect("../Home.aspx");
            }
            else
            {
                //"UpdateProduct.aspx?id=" + productId
                int targetProductId = Convert.ToInt32(Request.QueryString["id"]);
                ProductTypes old = productTypeController.FindProductType(targetProductId);
                if (!IsPostBack)
                {
                    productTypeName.Text = old.Name;
                    productTypeDescription.Text = old.Description;
                }
              
                    
            }

        }
        
        protected void productUpdateButton_Click(object sender, EventArgs e)
        {
            productTypeController.errorList.Clear();
            String productName = productTypeName.Text;
            String productDesc = productTypeDescription.Text;
            int productTypeId = Convert.ToInt32(Request.QueryString["id"]);
            if (productTypeController.validateAll(productName, productDesc))
            {
                productTypeController.UpdateProductType(productName, productDesc,productTypeController.FindProductType(productTypeId));
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