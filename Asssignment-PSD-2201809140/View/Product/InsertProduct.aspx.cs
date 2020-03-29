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
    public partial class InsertProduct : System.Web.UI.Page
    {
        List<String> errorList = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Users sessionUser = (Users) Session["SessionAuthUser"];

            if (!sessionUser.Roles.Name.Equals("admin"))
            {
                Response.Redirect("../Home.aspx");
            }
            else
            {
                
            }
        }

        protected bool validateName(String name)
        {
            if (String.IsNullOrEmpty(name))
            {
                errorList.Add("Name Must be filled");

                return false;
            }
            else
            {
                return true;
            }
        }

        protected bool validateStock(int stock)
        {
            if (stock >= 1)
            {
                return true;
            }
            else
            {
                errorList.Add("Stock must be 1 or more");
                return false;
            }
        }

        protected bool validatePrice(int price)
        {
            if (price > 1000 && price % 1000 == 0)
            {
                return true;
            }
            else
            {
                errorList.Add("Price must be above 1000 and multiply of 1000");

                return false;
            }
        }

        protected bool validateAll(String name, int stock, int price)
        {
            if (validateName(name) && validateStock(stock) && validatePrice(price))
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

            errorList.Clear();
            String productName = productNameInput.Text;
            int productStock = Convert.ToInt32(productStockInput.Text);
            int productPrice = Convert.ToInt32(productPriceInput.Text);
            if (validateAll(productName, productStock, productPrice))
            {
                ProductRepository.InsertProduct(productName,productStock,productPrice);
            }
            else
            {
                errorGrid.DataSource = errorList;
                errorGrid.DataBind();
            }
        }
    }
}