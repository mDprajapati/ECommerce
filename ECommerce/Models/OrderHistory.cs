using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class OrderHistory
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}