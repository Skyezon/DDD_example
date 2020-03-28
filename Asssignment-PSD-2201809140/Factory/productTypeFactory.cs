using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asssignment_PSD_2201809140.Model;

namespace Asssignment_PSD_2201809140.Factory
{
    public class productTypeFactory
    {
        public ProductTypes CreateProductTypes(String description, String name)
        {
            ProductTypes newType = new ProductTypes();
            newType.Description= description;
            newType.Name = name;
            return newType;
        }
    }
}