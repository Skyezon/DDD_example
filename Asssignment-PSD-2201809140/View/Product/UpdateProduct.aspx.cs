using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asssignment_PSD_2201809140.Controller;
using Asssignment_PSD_2201809140.Model;

namespace Asssignment_PSD_2201809140.View.Product
{
    public partial class UpdateProduct : System.Web.UI.Page
    {
        ProductController productController = new ProductController();
        ProductTypeController productTypeController = new ProductTypeController();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = productUpdateButton.UniqueID;
            Page.Form.DefaultFocus = productNameInput.ClientID;

            Users sessionUser = (Users)Session["SessionAuthUser"];
            if (sessionUser == null ? true : !sessionUser.Roles.Name.Equals("admin"))
            {
                Response.Redirect("../Home.aspx");
            }
            else
            {
                //"UpdateProduct.aspx?id=" + productId
                int targetProductId = Convert.ToInt32(Request.QueryString["id"]);
                Products old = productController.FindProduct(targetProductId);
                if (!IsPostBack)
                {
                    fillDropdown();

                    productNameInput.Text = old.Name;
                    productStockInput.Text = old.Stock.ToString();
                    productPriceInput.Text = old.Price.ToString();
                    dropDownListType.SelectedValue = old.ProductTypes.Name;
                }
              
                    ;
            }

        }


        protected void fillDropdown()
        {
            List<ProductTypes> productTypeList = productTypeController.GetProductList();
            List<String> productTypename = new List<string>();

            foreach (ProductTypes satu in productTypeList)
            {
                productTypename.Add(satu.Name);
            }

            dropDownListType.DataSource = productTypename;
            dropDownListType.DataBind();

        }

        protected void productUpdateButton_Click(object sender, EventArgs e)
        {
            productController.errorList.Clear();
            int targetProductId = Convert.ToInt32(Request.QueryString["id"]);
            Products old = productController.FindProduct(targetProductId);
            String productName = productNameInput.Text;
            int productStock = Convert.ToInt32(productStockInput.Text);
            int productPrice = Convert.ToInt32(productPriceInput.Text);
            String productTypeName = dropDownListType.SelectedValue;
         
            if (productController.validateAll(productName,productStock,productPrice))
            {

                productController.UpdateProduct(productName,productStock,productPrice,old,productTypeName);
                Response.Redirect("ViewProduct.aspx");
            }
            else
            {
                errorGrid.DataSource = productController.errorList;
                errorGrid.DataBind();
            }
        }
    }
}