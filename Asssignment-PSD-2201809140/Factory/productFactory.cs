using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asssignment_PSD_2201809140.Model;

namespace Asssignment_PSD_2201809140.Factory
{
    public class productFactory
    {
        public Products CreateProducts(String name, int price, int stock)
        {
            Products newProducts = new Products();
            newProducts.Name =  name;
            newProducts.Price = price;
            newProducts.Stock = stock;
            return newProducts;
        }
    }
}