using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}