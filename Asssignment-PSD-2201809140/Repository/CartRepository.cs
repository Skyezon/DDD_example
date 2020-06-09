using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asssignment_PSD_2201809140.Model;

namespace Asssignment_PSD_2201809140.Repository
{
    public class CartRepository
    {
        DatabaseTokbedEntities tokbedDB = new DatabaseTokbedEntities();

        public void insertCart(Carts newCart)
        {
            tokbedDB.Carts.Add(newCart);
            tokbedDB.SaveChanges();
        }

        public void updateCart(Carts oldCarts, int newQuantity)
        {
            Carts oldCart = findCart(oldCarts.UserID,oldCarts.ProductID);
            oldCart.Quantity = newQuantity;
            tokbedDB.SaveChanges();
        }

        public Carts findCart(int userId, int productId)
        {
            return tokbedDB.Carts.Where(oneCart => oneCart.ProductID.Equals(productId) && oneCart.UserID.Equals(userId)).FirstOrDefault();

        }

        public List<Carts> allCarts()
        {
            return (tokbedDB.Carts).ToList();
        }

        public void deleteCart(int userId, int productId)
        {
            Carts dapat = findCart(userId,productId);
            tokbedDB.Carts.Remove(dapat);
            tokbedDB.SaveChanges();
        }

    }
}