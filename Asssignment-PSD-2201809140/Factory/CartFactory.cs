using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asssignment_PSD_2201809140.Model;

namespace Asssignment_PSD_2201809140.Factory
{
    public class CartFactory
    {

        public Carts CreateCarts(int userId, int productId, int quantity)
        {
            Carts newCarts = new Carts();
            newCarts.ProductID = productId;
            newCarts.UserID = userId;
            newCarts.Quantity = quantity;
            return newCarts;
        }

    }
}