using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asssignment_PSD_2201809140.Factory;
using Asssignment_PSD_2201809140.Model;
using Asssignment_PSD_2201809140.Repository;

namespace Asssignment_PSD_2201809140.Handler
{
    public class CartHandler
    {
        CartRepository cartRepository = new CartRepository();

        public void insertCart(int userId, int productId, int quantity)
        {
            Carts hasil = new CartFactory().CreateCarts(userId,productId,quantity);
            cartRepository.insertCart(hasil);

        }

        public void updateCart(int userId, int productId, int quantity)
        {
            Carts oldCarts = cartRepository.findCart(userId, productId);
            cartRepository.updateCart(oldCarts,quantity);
        }

        public void deleteCart(int userId, int productId)
        {
            cartRepository.deleteCart(userId,productId);
        }

        public int totalStockRelatedProductCarts(int productId)
        {
            int totalStock = 0;
            List<Carts> allCarts = cartRepository.allCarts();
            foreach (Carts cart in allCarts)
            {
                if (cart.ProductID.Equals(productId))
                {
                    int cartQuantity = (int)cart.Quantity;
                    totalStock += cartQuantity;
                }
                else
                {
                    continue;
                }
            }

            return totalStock;
        }
    }
}