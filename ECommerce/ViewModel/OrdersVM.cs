using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.ViewModel
{
    public class BuyProductVM
    {
     
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int QuantityValue { get; set; }
        public int UserID { get; set; }
        public DateTime purchesedate { get; set; }
    }
}