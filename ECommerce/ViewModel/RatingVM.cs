using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.ViewModel
{
    public class RatingVM
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public float RatingNumber { get; set; }
    }
}