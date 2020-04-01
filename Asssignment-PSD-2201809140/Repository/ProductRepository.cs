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

        public static List<Object> GetProductListWithTypeName()
        {

           List<Object> baru = tokbedDb.Products.Select(satu => new {Productid = satu.Id, ProductName = satu.Name, ProductStock = satu.Stock, ProductType = satu.ProductTypes.Name, ProductQuantity = satu.Price}).ToList<Object>();
           return baru;
        }

        public static void InsertProduct(String Name, int Stock, int Price,int id)
        {
            List<ProductTypes> productTypeList = ProductTypeRepository.GetProductList();
            Random rand = new Random();
            productFactory baru = new productFactory();
            Products target = baru.CreateProducts(Name, Price, Stock);
            target.ProductTypeID = id;
            tokbedDb.Products.Add(target);
            tokbedDb.SaveChanges();

        }

        public static void UpdateProduct(String Name, int Stock, int Price, Products lama, String typeName)
        {
           Products dapat = FindProduct(lama.Id);
           dapat.Name = Name;
           dapat.Stock = Stock;
           dapat.Price = Price;
           dapat.ProductTypeID = ProductTypeRepository.findId(typeName);
           tokbedDb.SaveChanges();
        }

        public static void DeleteProduct(int id)
        {
            Products dapat = FindProduct(id);
           tokbedDb.Products.Remove(dapat);
           tokbedDb.SaveChanges();
        }

        public static Products FindProduct(int id)
        {
            Products dapat = (Products) tokbedDb.Products.Find(id);
            return dapat;
        }

    }
}