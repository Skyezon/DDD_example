using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asssignment_PSD_2201809140.Handler;
using Asssignment_PSD_2201809140.Model;

namespace Asssignment_PSD_2201809140.Controller
{
    public class ProductController
    {
        public List<String> errorList = new List<string>();

        public bool validateName(String name)
        {
            if (String.IsNullOrEmpty(name))
            {
                errorList.Add("Name Must be filled");

                return false;
            }
            else
            {
                return true;
            }
        }

        public bool validateStock(int stock)
        {
            if (stock >= 1)
            {
                return true;
            }
            else
            {
                errorList.Add("Stock must be 1 or more");
                return false;
            }
        }

        public bool validatePrice(int price)
        {
            if (price > 1000 && price % 1000 == 0)
            {
                return true;
            }
            else
            {
                errorList.Add("Price must be above 1000 and multiply of 1000");

                return false;
            }
        }

        public bool validateAll(String name, int stock, int price)
        {
            if (validateName(name) && validateStock(stock) && validatePrice(price))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public  Products FindProduct(int id)
        {
            return ProductHandler.FindProduct(id);
        }

        public  List<Products> GetProductList()
        {
            return ProductHandler.GetProductList();
        }

        public  List<Object> GetProductListWithTypeName()
        {

            return ProductHandler.GetProductListWithTypeName();
        }

        public  void InsertProduct(String Name, int Stock, int Price, int id)
        {
           ProductHandler.InsertProduct(Name,Stock,Price,id);

        }

        public  void UpdateProduct(String Name, int Stock, int Price, Products lama, String typeName)
        {
            ProductHandler.UpdateProduct(Name, Stock, Price, lama, typeName);
        }

        public  void DeleteProduct(int id)
        {
            ProductHandler.DeleteProduct(id);
        }

    }
}