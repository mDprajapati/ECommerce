using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Quantity
    {
        [Key]
        public int ID { get; set; }

        public int QuantityNumbers { get; set; }
    }
}