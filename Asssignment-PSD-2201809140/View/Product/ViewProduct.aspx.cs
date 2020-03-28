using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asssignment_PSD_2201809140.View
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void insertProductButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product/InsertProduct.aspx");

        }
    }
}