using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asssignment_PSD_2201809140.Factory;
using Asssignment_PSD_2201809140.Model;
using Asssignment_PSD_2201809140.Repository;

namespace Asssignment_PSD_2201809140.Handler
{
    public class ProductHandler
    {

        public static Products FindProduct(int id)
        {
            Products dapat = ProductRepository.FindProduct(id);
            return dapat;
        }

        public static List<Products> GetProductList()
        {
            return ProductRepository.GetProductList();
        }

        public static List<Object> GetProductListWithTypeName()
        {

            return ProductRepository.GetProductListWithTypeName();
        }

        public static void InsertProduct(String Name, int Stock, int Price, int id)
        {
            productFactory baru = new productFactory();
            Products target = baru.CreateProducts(Name, Price, Stock);
            target.ProductTypeID = id;
            ProductRepository.InsertProduct(target);

        }

        public static void UpdateProduct(String Name, int Stock, int Price, Products lama, String typeName)
        {
           ProductRepository.UpdateProduct(Name,Stock,Price,lama,typeName);
        }

        public static void DeleteProduct(int id)
        {
           ProductRepository.DeleteProduct(id);
        }
            
    }
}