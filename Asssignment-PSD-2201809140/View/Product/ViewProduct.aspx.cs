using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asssignment_PSD_2201809140.Controller;
using Asssignment_PSD_2201809140.Model;

namespace Asssignment_PSD_2201809140.View
{
    public partial class WebForm4 : System.Web.UI.Page
    {

        private Users sessionUser = new Users();
        ProductController productController = new ProductController();
        protected void Page_Load(object sender, EventArgs e)
        {
            sessionUser = (Users)Session["SessionAuthUser"];
            List <Object> newList = productController.GetProductListWithTypeName();
            productList.DataSource = newList;
            productList.DataBind();

            hideAll(sessionUser == null ? "guest" : sessionUser.Roles.Name);




        }

        protected void hideAll(String role)
        {
            if (!role.Equals("admin"))
            {
                //foreach (GridViewRow row in productList.Rows)
                //{
                //        Button btnUpdate = row.FindControl("updateProductButton") as Button;
                //        Button btnDelete = row.FindControl("deleteProductButton") as Button;
                //        btnUpdate.Visible = false;
                //        btnDelete.Visible = false;
                //}

                //insertProductButton.Visible = false;
                productList.Columns[1].Visible = false;
                productList.Columns[2].Visible = false;
            }

            if (!role.Equals("member"))
            {
                productList.Columns[0].Visible = false;

            }
        }

        protected void addToCartButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int rowIndex = row.RowIndex;

            String productId = productList.Rows[rowIndex].Cells[3].Text;


            Response.Redirect("../Cart/InsertCart.aspx?id=" + productId);
        }

        protected void insertProductButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertProduct.aspx");

        }

        protected void updateProductButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int rowIndex = row.RowIndex;

            String productId = productList.Rows[rowIndex].Cells[3].Text;
            

            Response.Redirect("UpdateProduct.aspx?id="+productId);
        }

        protected void deleteProductButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int rowIndex = row.RowIndex;

            int productId = Convert.ToInt16(productList.Rows[rowIndex].Cells[3].Text);
            Products target = new Products();
            target.Id = productId;
            productController.DeleteProduct(target.Id);
            Response.Redirect("ViewProduct.aspx");
        }
    }
}