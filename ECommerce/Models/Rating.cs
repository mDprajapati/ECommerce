using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Rating
    {
        [Key]
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public float RatingNumber { get; set; }
    }
}