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
    public partial class ViewProductType : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        Users sessionUser = (Users)Session["SessionAuthUser"];


            if (sessionUser == null)
            {
                Response.Redirect("../Home.aspx");
            }
             if (!sessionUser.Roles.Name.Equals("admin"))
            {
                Response.Redirect("../Home.aspx");
            }

            sessionUser = (Users)Session["SessionAuthUser"];
            viewProductGrid.DataSource = ProductTypeRepository.GetProductList();
            viewProductGrid.DataBind();

            hideAll(sessionUser == null ? "guest" : sessionUser.Roles.Name);

        }

        protected void hideAll(String role)
        {
            if (!role.Equals("admin"))
            {
                foreach (GridViewRow row in viewProductGrid.Rows)
                {
                    Button btnUpdate = row.FindControl("updateProductTypeButton") as Button;
                    Button btnDelete = row.FindControl("deleteProductTypeButton") as Button;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                }

                insertProductTypeButton.Visible = false;
            }
        }

        protected void deleteProductTypeButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int rowIndex = row.RowIndex;

            int productId = Convert.ToInt16(viewProductGrid.Rows[rowIndex].Cells[2].Text);
            ProductTypes target = new ProductTypes();
            target.Id = productId;
            //ubahg repo
            ProductTypeRepository.DeleteProductType(target.Id);
            Response.Redirect("ViewProductType.aspx");
        }

        protected void updateProductTypeButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Get the row that contains this button
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int rowIndex = row.RowIndex;

            String productTypeId = viewProductGrid.Rows[rowIndex].Cells[2].Text;


            Response.Redirect("UpdateProductType.aspx?id=" + productTypeId);
        }

        protected void insertProductTypeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertProductType.aspx");
        }
    }
}