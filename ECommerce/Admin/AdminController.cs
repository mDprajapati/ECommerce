using ECommerce.Models;
using ECommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ECommerce.Admin
{
    public class AdminController : ApiController
    {
        private Context db = new Context();
        [HttpGet]
        [Route("API/GetProduct")]

        public IHttpActionResult GetProduct()
        {
            List<ProductVM> productVMs = new List<ProductVM>();
            var getproductdetails = db.products.ToList();

            foreach (var item in getproductdetails)
            {
                ProductVM productVM = new ProductVM();
                productVM.UserID = Convert.ToInt32(HttpContext.Current.Session["ID"]);
                productVM.ProductID = item.ProductID;
                productVM.ProductName = item.ProductName;
                productVM.ProductImage = item.ProductImage;
                productVM.CatagoryID = item.CatagoryID;
                productVM.CatagoryName = db.catagories.Find(item.CatagoryID).CatagoryName;
                productVM.QuantityID = item.QuantityID;

                List<RatingVM> ratings = new List<RatingVM>();
                var avrateofratings = db.ratings.Where(x => x.ProductID == item.ProductID).ToList();

                foreach (var item1 in avrateofratings)
                {
                    if (item1.ProductID == item.ProductID)
                    {
                       
                        productVM.RatingAvrage = db.ratings.Where(x => x.ProductID == item1.ProductID).Select(x => x.RatingNumber).Average();
                    }
                }

               

                if (item.QuantityID > 0)
                {
                    productVM.QuantityNumbers = db.quantities.Find(item.QuantityID).QuantityNumbers;
                }

                productVM.ProductPrice = item.ProductPrice;
                productVMs.Add(productVM);
            }
            return Ok(productVMs);
        }

        [HttpGet]
        [Route("API/OrderHistory")]
        public IHttpActionResult OrderHistory()
        {
            List<OrderHistoryVM> orders = new List<OrderHistoryVM>();
            var userid = Convert.ToInt32(HttpContext.Current.Session["ID"]);
            var histortdetails = db.orderhistories.ToList();

           

            foreach (var item in histortdetails)
            {
                if (item.UserID == userid)
                {
                    OrderHistoryVM order = new OrderHistoryVM();
                    order.UserID = item.UserID;
                    order.ProductID = item.ProductID;
                    order.OrderDate = item.OrderDate.ToShortDateString();
                    order.ProductImage = db.products.Find(item.ProductID).ProductImage;
                    order.ProductName = db.products.Find(item.ProductID).ProductName;
                    order.ProductPrice = (item.ProductQuantity * db.products.Where(x => x.ProductID == item.ProductID).Select(x => x.ProductPrice).DefaultIfEmpty().Sum());
                    orders.Add(order);
                }
            }
            //foreach (var item2 in details)
            //{
            //    if (item2.UserID == userid)
            //    {
            //        OrderHistoryVM orderHistory = new OrderHistoryVM();
            //        orderHistory.OrderTotal = db.buyproducts.Where(x => x.purchesedate == item2.OrderDate);
            //    }
            //}

            return Ok(orders);
        }

        [HttpPost]
        [Route("API/PostProduct")]
        public IHttpActionResult PostProduct(ProductVM product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductID == 0)
                {
                    Product product1 = new Product
                    {
                        ProductID = product.ProductID,
                        ProductName = product.ProductName,
                        ProductImage = product.ProductImage,
                        CatagoryID = product.CatagoryID,
                        QuantityID = product.QuantityID,
                        ProductPrice = product.ProductPrice
                    };
                    db.products.Add(product1);
                    db.SaveChanges();
                }
                else
                {
                    Product product1 = new Product
                    {
                        ProductID = product.ProductID,
                        ProductName = product.ProductName,
                        ProductImage = product.ProductImage,
                        CatagoryID = product.CatagoryID,
                        QuantityID = product.QuantityID,
                        ProductPrice = product.ProductPrice
                    };
                    db.Entry(product1).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return Ok(product);
        }

        [HttpDelete]
        [Route("API/DeleteProduct")]

        public IHttpActionResult DeleteProduct(int ProductID)
        {
            var product = db.products.Find(ProductID);
            if (product != null)
            {
                db.products.Remove(product);
                db.SaveChanges();
            }
            return Ok(product);
        }
        [HttpDelete]
        [Route("API/DeleteCartProduct")]

        public IHttpActionResult DeleteCartProduct(int ProductID)
        {
            var userid = Convert.ToInt32(HttpContext.Current.Session["ID"]);
            var deletecart = db.addcarts.Where(x => x.ProductID == ProductID && x.UserID == userid).FirstOrDefault();
            if (deletecart != null)
            {
                db.addcarts.Remove(deletecart);
                db.SaveChanges();
            }
            return Ok(deletecart);
        }

        

        [HttpGet]
        [Route("API/ProductByID")]

        public IHttpActionResult ProductByID(int ProductID)
        {
            var product = db.products.Find(ProductID);
            if (product == null)
            {
                return BadRequest();
            }
            else
            {
                ProductVM productVM = new ProductVM
                {
                    ProductImage = product.ProductImage,
                    ProductName = product.ProductName,
                    CatagoryID = product.CatagoryID,
                    QuantityID = product.QuantityID,
                    ProductPrice = product.ProductPrice,
                };
            }
            return Ok(product);
        }

    }
}
