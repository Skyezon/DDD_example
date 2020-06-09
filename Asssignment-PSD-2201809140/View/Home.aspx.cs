using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Asssignment_PSD_2201809140.Controller;
using Asssignment_PSD_2201809140.Model;
using Asssignment_PSD_2201809140.Repository;

namespace Asssignment_PSD_2201809140.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            Users sessionUser = (Users)Session["SessionAuthUser"];
            
            if (sessionUser == null || sessionUser.Roles.Name.Equals("member"))
            {
                loadListProduct();
            }

            if (sessionUser == null)
            {
         
                viewUserButton.Visible = false;
                insertProductButton.Visible = false;
                updateProductButton.Visible = false;
                viewProductTypeButton.Visible = false;
                insertProductTypeButton.Visible = false;
                updateProductTypeButton.Visible = false;
                return;
            }
            else if (sessionUser.Roles.Name.Equals("member") || sessionUser.Roles.Name.Equals("admin"))
            {
       

                viewUserButton.Visible = false;
                insertProductButton.Visible = false;
                updateProductButton.Visible = false;
                viewProductTypeButton.Visible = false;
                insertProductTypeButton.Visible = false;
                updateProductTypeButton.Visible = false;

            }
             
            if (sessionUser.Roles.Name.Equals("admin"))
            {
                viewUserButton.Visible = true;
                insertProductButton.Visible = true;
                updateProductButton.Visible = true;
                viewProductTypeButton.Visible = true;
                insertProductTypeButton.Visible = true;
                updateProductTypeButton.Visible = true;
            }
        }

        protected void viewUserButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Account/ViewUser.aspx");
        }

        protected void insertProductButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product/InsertProduct.aspx");

        }

        protected void updateProductButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product/ViewProduct.aspx");
        }

        protected void viewProductTypeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductType/ViewProductType.aspx");
        }

        protected void insertProductTypeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductType/InsertProductType.aspx");
        }

        protected void updateProductTypeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductType/ViewProductType.aspx");
        }

      

        protected void loadListProduct()
        {
            ProductController productController = new ProductController();

            Random rand = new Random();
             List<Products> tampilanProduct = new List<Products>();
             List<Products> kumpulanProduct = ProductRepository.GetProductList();
             Console.WriteLine(kumpulanProduct);
             if (kumpulanProduct.Count < 5)
             {
                 productList.DataSource = kumpulanProduct;

             }
             else
             {
                for (int i = 0; i < 5; i++)
                {
                    int index = 1;
                    Products pilihan = new Products();
                 
                        
                        index = (int)rand.Next(0, kumpulanProduct.Count-1);
                        pilihan = kumpulanProduct[index];
              
                    tampilanProduct.Add(pilihan);
                    kumpulanProduct.Remove(pilihan);
                    
                }
                productList.DataSource = tampilanProduct;
                
            }
             productList.DataBind();
        }

        
    }
}