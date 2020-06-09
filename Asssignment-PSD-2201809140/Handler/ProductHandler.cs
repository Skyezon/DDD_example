using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asssignment_PSD_2201809140.Model;
using Asssignment_PSD_2201809140.Repository;

namespace Asssignment_PSD_2201809140.Handler
{
    public class ProductHandler
    {

        public Products FindProduct(int id)
        {
            Products dapat = ProductRepository.FindProduct(id);
            return dapat;
        }
    }
}