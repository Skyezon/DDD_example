using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asssignment_PSD_2201809140.Controller;
using Asssignment_PSD_2201809140.Model;
using Asssignment_PSD_2201809140.Repository;

namespace Asssignment_PSD_2201809140.View
{
    public partial class InsertProduct : System.Web.UI.Page
    {
        ProductController productController = new ProductController();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = productInsertButton.UniqueID;
            Page.Form.DefaultFocus = productNameInput.ClientID;
            if (!IsPostBack)
            {
              fillDropdown();
            }

            Users sessionUser = (Users) Session["SessionAuthUser"];

            if (!sessionUser.Roles.Name.Equals("admin"))
            {
                Response.Redirect("../Home.aspx");
            }
            else
            {
                
            }
        }

        protected void fillDropdown()
        {
            List<ProductTypes> productTypeList = ProductTypeRepository.GetProductList();
            List<String> productTypename = new List<string>();

            foreach (ProductTypes satu in productTypeList)
            {
                productTypename.Add(satu.Name);
            }

            dropDownListType.DataSource = productTypename;
            dropDownListType.DataBind();

        }





        protected void productInsertButton_Click(object sender, EventArgs e)
        {

            productController.errorList.Clear();
            String productName = productNameInput.Text;
            int productStock = Convert.ToInt32(productStockInput.Text);
            int productPrice = Convert.ToInt32(productPriceInput.Text);
            if (productController.validateAll(productName, productStock, productPrice))
            {

                ProductRepository.InsertProduct(productName,productStock,productPrice, ProductTypeRepository.findId(dropDownListType.SelectedItem.Value)); 
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