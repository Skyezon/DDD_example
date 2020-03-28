using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asssignment_PSD_2201809140.Factory;
using Asssignment_PSD_2201809140.Model;

namespace Asssignment_PSD_2201809140.Repository
{
    public static class ProductRepository
    {
        private static DatabaseTokbedEntities tokbedDb = new DatabaseTokbedEntities();

        public static List<Products> GetProductList()
        {
           return (tokbedDb.Products).ToList();
        }

        public static void InsertProduct(String Name, int Stock, int Price)
        {
            productFactory baru = new productFactory();
            tokbedDb.Products.Add(baru.CreateProducts(Name,Price,Stock));
            tokbedDb.SaveChanges();

        }

        public static void UpdateProduct(String Name, int Stock, int Price, Products lama)
        {
           Products dapat = tokbedDb.Products.Find(lama.Id);
           dapat.Name = Name;
           dapat.Stock = Stock;
           dapat.Price = Price;
           tokbedDb.SaveChanges();
        }

        public static void DeleteProduct(Products targetProduct)
        {
           Products dapat = tokbedDb.Products.Find(targetProduct.Id);
           tokbedDb.Products.Remove(targetProduct);
           tokbedDb.SaveChanges();
        }

    }
}