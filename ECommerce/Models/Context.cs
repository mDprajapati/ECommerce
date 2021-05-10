using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Context:DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Quantity> quantities { get; set; }
        public DbSet<Catagory> catagories { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<AddCart> addcarts { get; set; }
        public DbSet<Rating> ratings { get; set; }
        public DbSet<BuyProduct> buyproducts { get; set; }
        public DbSet<OrderHistory> orderhistories { get; set; }
    }
}