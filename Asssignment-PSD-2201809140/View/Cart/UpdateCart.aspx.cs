using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asssignment_PSD_2201809140.Controller;
using Asssignment_PSD_2201809140.Model;

namespace Asssignment_PSD_2201809140.View.Cart
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        CartController cartController = new CartController();
        ProductController productHandler = new ProductController();
        protected void Page_Load(object sender, EventArgs e)
        {
            Users sessionUser = (Users)Session["SessionAuthUser"];
            if (sessionUser == null)
            {
                Response.Redirect("../Home.aspx");

            }

            if (!sessionUser.Roles.Name.Equals("member"))
            {
                Response.Redirect("../Home.aspx");
            }
            int targetProductId = Convert.ToInt32(Request.QueryString["id"]);
            Carts getCarts = cartController.findCarts(sessionUser.Id, targetProductId);

            if (!IsPostBack)
            {
              cartProductName.Text = productHandler.FindProduct(targetProductId).Name;
              cartProductQuantityInput.Text = getCarts.Quantity.ToString();
            }

        }

        protected void cartProductUpdateButton_Click(object sender, EventArgs e)
        {
            Users sessionUser = (Users)Session["SessionAuthUser"];
            int targetProductId = Convert.ToInt32(Request.QueryString["id"]);

            cartController.errorList.Clear();
            int quantityInput = 0;
            if (cartController.isQuantityNumber(cartProductQuantityInput.Text))
            {
                quantityInput = Convert.ToInt32(cartProductQuantityInput.Text);

            }
            else
            {
                Response.Redirect(Request.RawUrl);
            }

            if (cartController.isZero(quantityInput))
            {
                cartController.deleteCart(sessionUser.Id,targetProductId); 
                Response.Redirect("ViewCart.aspx");
            }

            if (cartController.validateQuantity(quantityInput, sessionUser.Id, targetProductId))
            {
                cartController.updateCart(sessionUser.Id,targetProductId,quantityInput);
                Response.Redirect("ViewCart.aspx");
            }
            else
            {
                errorGrid.DataSource = cartController.errorList;
                errorGrid.DataBind();
            }
        }
    }
}