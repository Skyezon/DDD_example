using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asssignment_PSD_2201809140.Factory;
using Asssignment_PSD_2201809140.Model;
using Asssignment_PSD_2201809140.Repository;

namespace Asssignment_PSD_2201809140.Handler
{
    public class ProductTypeHandler
    {
        public static List<ProductTypes> GetProductList()
        {
            return ProductTypeRepository.GetProductList();
        }

        public static void InsertProductType(String name, String description)
        {
            productTypeFactory baru = new productTypeFactory();
            ProductTypeRepository.InsertProductType(baru.CreateProductTypes(description, name));

        }

        public static void UpdateProductType(String name, String description, ProductTypes lama)
        {
            ProductTypeRepository.UpdateProductType(name,description,lama);

        }

        public static ProductTypes FindProductType(int id)
        {
            return ProductTypeRepository.FindProductType(id);
        }

        public static int findId(String productTypeName)
        {
            return ProductTypeRepository.findId(productTypeName);
        }

        public static void DeleteProductType(int id)
        {
            ProductTypeRepository.DeleteProductType(id);
        }

        public static bool isUnique(String name)
        {
            return ProductTypeRepository.isUnique(name);
        }
    }
}