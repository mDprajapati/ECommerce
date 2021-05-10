using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.ViewModel
{
    public class AddCartVM
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public string ProductImage { get; set; }

        public int ProductPrice { get; set; }
        public string ProductName { get; set; }
    }
}