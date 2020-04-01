using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asssignment_PSD_2201809140.Model;
using Asssignment_PSD_2201809140.Repository;

namespace Asssignment_PSD_2201809140.View.ProductType
{
    public partial class InsertProductType : System.Web.UI.Page
    {
        private List<String> ErrorList = new List<string>();
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

        protected bool validateName(String name)
        {
            if (ProductTypeRepository.isUnique(name))
            {
                return true;
            }
            else
            {
                ErrorList.Add("Product type Name must be unique");
                return false;
            }
        }

        protected bool validateDescription(String desc)
        {
            if (String.IsNullOrEmpty(desc))
            {
                ErrorList.Add("Description must be filled");
                return false;
            }
            else
            {
                return true;
            }
        }

        protected bool validateAll(String name, String desc)
        {
            if (validateName(name) && validateDescription(desc))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void productInsertButton_Click(object sender, EventArgs e)
        {
            ErrorList.Clear();
            String productName = productTypeName.Text;
            String productDesc = productTypeDescription.Text;
            if (validateAll(productName,productDesc))
            {
                ProductTypeRepository.InsertProductType(productName,productDesc);
                Response.Redirect("ViewProductType.aspx");
            }
            else
            {
                errorGrid.DataSource = ErrorList;
                errorGrid.DataBind();
            }
        }
    }
}