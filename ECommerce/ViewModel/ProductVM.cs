using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.ViewModel
{
    public class ProductVM
    {
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string CatagoryName { get; set; }
        public int CatagoryID { get; set; }
        public int QuantityNumbers { get; set; }
        public int QuantityID { get; set; }
        public int ProductPrice { get; set; }
        public float RatingAvrage { get; set; }
    }
}