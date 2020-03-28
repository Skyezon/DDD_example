using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asssignment_PSD_2201809140.Factory;
using Asssignment_PSD_2201809140.Model;

namespace Asssignment_PSD_2201809140.Repository
{
    public static class ProductTypeRepository
    {
        private static DatabaseTokbedEntities tokbedDb = new DatabaseTokbedEntities();

        public static List<ProductTypes> GetProductList()
        {
            return (tokbedDb.ProductTypes).ToList();
        }

        public static void InsertProduct(String name, String description)
        {
            productTypeFactory baru = new productTypeFactory();
            tokbedDb.ProductTypes.Add(baru.CreateProductTypes(description,name));
            tokbedDb.SaveChanges();

        }

        public static void UpdateProduct(String name, String description, ProductTypes lama)
        {
            ProductTypes dapat = tokbedDb.ProductTypes.Find(lama.Id);
            dapat.Name = name;
            dapat.Description = description;
            tokbedDb.SaveChanges();

        }

        
    }
}