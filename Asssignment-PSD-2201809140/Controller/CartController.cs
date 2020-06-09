using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asssignment_PSD_2201809140.Handler;
using Asssignment_PSD_2201809140.Model;
using Asssignment_PSD_2201809140.Repository;

namespace Asssignment_PSD_2201809140.Controller
{
    public class CartController
    {
        private CartHandler cartHandler = new CartHandler();
        public List<String> errorList = new List<string>();

        public bool greaterThanZero(int quantity)
        {
            if (quantity > 0)
            {
                return true;
            }
            else
            {
                errorList.Add("Quantity must be greater than 0");
                return false;

            }
        }

        public bool notOverProductStock(int quantity, int productId)
        {
            Products selectedProducts = ProductRepository.FindProduct(productId);
            if (quantity <= selectedProducts.Stock)
            {
                return true;
            }
            else
            {
                errorList.Add("Quantity Must be less than or equals to current stock");
                return false;
            }
        }

        public bool notOverProductStockWithOtherCart(int quantity, int productId)
        {
            Products selectedProducts = ProductRepository.FindProduct(productId);
            int totalOtherCartQuantity = cartHandler.totalStockRelatedProductCarts(productId);
            if (quantity + totalOtherCartQuantity > selectedProducts.Stock)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool isQuantityNumber(String quantity)
        {
            int hasilQuantity = 0;
            if (Int32.TryParse(quantity, out hasilQuantity))
            {
                return true;
            }
            else
            {
                errorList.Add("Quantity is not number");
                return false;
            }
        }

        public bool validateQuantity(int inputQuantity, int userId,int productId)
        {

            if (greaterThanZero(inputQuantity) && notOverProductStock(inputQuantity, productId) && notOverProductStockWithOtherCart(inputQuantity, productId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isZero(int quantity)
        {
            if (quantity == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Carts findCarts(int userId, int productId)
        {
            CartRepository cartRepository = new CartRepository();
            return cartRepository.findCart(userId, productId);
        }

        public void insertCart(int inputQuantity, int userId,int productId)
        {
            cartHandler.insertCart(userId,productId,inputQuantity);
     
        }

        public void updateCart(int userId,int productId, int quantity)
        {
            cartHandler.updateCart(userId, productId, quantity);
        }

        public void deleteCart(int userId, int productId)
        {
            cartHandler.deleteCart(userId,productId);
        }

    }
}