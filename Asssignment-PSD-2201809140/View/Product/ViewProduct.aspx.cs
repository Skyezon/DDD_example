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
    public partial class WebForm4 : System.Web.UI.Page
    {

        private Users sessionUser = new Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            sessionUser = (Users)Session["SessionAuthUser"];
            productList.DataSource = ProductRepository.GetProductList();
            productList.DataBind();

            hideAll(sessionUser == null ? "guest" : sessionUser.Roles.Name);


        }

        protected void hideAll(String role)
        {
            if (!role.Equals("admin"))
            {
                foreach (GridViewRow row in productList.Rows)
                {
                    Button btnUpdate = row.FindControl("updateProductButton") as Button;
                        Button btnDelete = row.FindControl("deleteProductButton") as Button;
                        btnUpdate.Visible = false;
                        btnDelete.Visible = false;
                }

                insertProductButton.Visible = false;
            }
        }

        protected void insertProductButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product/InsertProduct.aspx");

        }

        protected void updateProductButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int rowIndex = row.RowIndex;

            String productId = productList.Rows[rowIndex].Cells[2].Text;
            

            Response.Redirect("UpdateProduct.aspx?id="+productId);
        }

        protected void deleteProductButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int rowIndex = row.RowIndex;

            int productId = Convert.ToInt16(productList.Rows[rowIndex].Cells[2].Text);
            Products target = new Products();
            target.Id = productId;
            ProductRepository.DeleteProduct(target.Id);
            Response.Redirect("ViewProduct.aspx");
        }
    }
}