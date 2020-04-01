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

        public static void InsertProductType(String name, String description)
        {
            productTypeFactory baru = new productTypeFactory();
            tokbedDb.ProductTypes.Add(baru.CreateProductTypes(description,name));
            tokbedDb.SaveChanges();

        }

        public static void UpdateProductType(String name, String description, ProductTypes lama)
        {
            ProductTypes dapat = FindProductType(lama.Id);
            dapat.Name = name;
            dapat.Description = description;
            tokbedDb.SaveChanges();

        }

        public static ProductTypes FindProductType(int id)
        {
            ProductTypes dapat = tokbedDb.ProductTypes.Find(id);
            return dapat;
        }

        public static int findId(String productTypeName)
        {
            ProductTypes dapat = tokbedDb.ProductTypes.Where(satu => satu.Name.Equals(productTypeName))
                .FirstOrDefault();
            return dapat.Id;
        }

        public static void DeleteProductType(int id)
        {
            ProductTypes target = FindProductType(id);
            tokbedDb.ProductTypes.Remove(target);
            tokbedDb.SaveChanges();
        }

        public static bool isUnique(String name)
        {
            if (tokbedDb.ProductTypes.Where(satu => satu.Name.Equals(name)).FirstOrDefault() == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}