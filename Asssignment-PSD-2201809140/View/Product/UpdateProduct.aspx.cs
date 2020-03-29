using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asssignment_PSD_2201809140.Model;
using Asssignment_PSD_2201809140.Repository;

namespace Asssignment_PSD_2201809140.View.Product
{
    public partial class UpdateProduct : System.Web.UI.Page
    {
        private List<String> errorList = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Users sessionUser = (Users)Session["SessionAuthUser"];
            if (sessionUser == null ? true : !sessionUser.Roles.Name.Equals("admin"))
            {
                Response.Redirect("../Home.aspx");
            }
            else
            {
                //"UpdateProduct.aspx?id=" + productId
                int targetProductId = Convert.ToInt32(Request.QueryString["id"]);
                Products old = ProductRepository.FindProduct(targetProductId);
                if (!IsPostBack)
                {
                    productNameInput.Text = old.Name;
                    productStockInput.Text = old.Stock.ToString();
                    productPriceInput.Text = old.Price.ToString();
                }
              
                    ;
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

        protected void productUpdateButton_Click(object sender, EventArgs e)
        {
            errorList.Clear();
            int targetProductId = Convert.ToInt32(Request.QueryString["id"]);
            Products old = ProductRepository.FindProduct(targetProductId);
            String productName = productNameInput.Text;
            int productStock = Convert.ToInt32(productStockInput.Text);
            int productPrice = Convert.ToInt32(productPriceInput.Text);
            System.Diagnostics.Debug.WriteLine($"{productName} stocknya : {productStock} price : {productPrice}");
            if (validateAll(productName,productStock,productPrice))
            {

                ProductRepository.UpdateProduct(productName,productStock,productPrice,old);
                Response.Redirect("ViewProduct.aspx");
            }
            else
            {
                errorGrid.DataSource = errorList;
                errorGrid.DataBind();
            }
        }
    }
}