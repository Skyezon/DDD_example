using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asssignment_PSD_2201809140.Handler;
using Asssignment_PSD_2201809140.Model;

namespace Asssignment_PSD_2201809140.Controller
{
    public class ProductTypeController
    {
        public List<String> errorList = new List<string>();

        public  List<ProductTypes> GetProductList()
        {
            return ProductTypeHandler.GetProductList();
        }

        public  void InsertProductType(String name, String description)
        {
            ProductTypeHandler.InsertProductType(name,description);

        }

        public  void UpdateProductType(String name, String description, ProductTypes lama)
        {
            ProductTypeHandler.UpdateProductType(name, description, lama);

        }

        public  ProductTypes FindProductType(int id)
        {
            return ProductTypeHandler.FindProductType(id);
        }

        public  int findId(String productTypeName)
        {
            return ProductTypeHandler.findId(productTypeName);
        }

        public  void DeleteProductType(int id)
        {
            ProductTypeHandler.DeleteProductType(id);
        }

        public  bool isUnique(String name)
        {
            return ProductTypeHandler.isUnique(name);
        }

        public bool validateName(String name)
        {
            if (ProductTypeHandler.isUnique(name))
            {
                return true;
            }
            else
            {
                errorList.Add("Product type Name must be unique");
                return false;
            }
        }

        public bool validateDescription(String desc)
        {
            if (String.IsNullOrEmpty(desc))
            {
                errorList.Add("Description must be filled");
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool validateAll(String name, String desc)
        {
            if (validateName(name) && validateDescription(desc))
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