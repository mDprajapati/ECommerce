using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.ViewModel
{
    public class UsersVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Email is Requirde")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                             @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                             @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                             ErrorMessage = "Email is not valid")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Requirde")]
        public string Password { get; set; }
        public string UserRole { get; set; }
        public string AccessToken { get; set; }
    }
}