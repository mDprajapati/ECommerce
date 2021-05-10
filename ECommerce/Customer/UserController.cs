using ECommerce.JWT;
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


namespace ECommerce.Customer
{
    public class UserController : ApiController
    {
        private Context db = new Context();
        [HttpPost]
        [Route("API/loginuser")]

        public IHttpActionResult loginuser(UsersVM usersVM)
        {
            var loginuser = db.users.Where(x => x.UserName == usersVM.UserName && x.Password == usersVM.Password).FirstOrDefault();
            if (loginuser != null)
            {
                if (loginuser.Status == 1)
                {
                    usersVM.AccessToken = new Token().GenerateToken(loginuser);
                    HttpContext.Current.Session["ID"] = loginuser.ID.ToString();
                    usersVM.UserRole = loginuser.UserRole;
                    db.SaveChanges();
                    return Ok(usersVM);
                }
                return BadRequest("Deactivated");
            }
            return BadRequest("InvalidLogin");
        }
        [HttpPost]
        [Route("API/BuyProduct")]

        public IHttpActionResult BuyProduct(BuyProductVM buyProduct)
        {
            var userid = Convert.ToInt32(HttpContext.Current.Session["ID"]);
            if (userid != 0)
            {
                var sellproduct = db.products.FirstOrDefault(x => x.ProductID == buyProduct.ProductID);
                
                if (sellproduct != null)
                {
                    var count = sellproduct.QuantityID - buyProduct.QuantityValue;
                    int quantity = count;
                    sellproduct.QuantityID = quantity;
                    db.Entry(sellproduct).State = EntityState.Modified;
                    db.SaveChanges();
                   
                    var cart = db.addcarts.Where(x => x.UserID == userid).ToList();
                    foreach(var item  in cart)
                    {
                        BuyProduct products = new BuyProduct
                        {
                            purchesedate = DateTime.Now,
                            UserID = userid,
                            ProductID = item.ProductID,
                            QuantityValue = buyProduct.QuantityValue
                        };
                        db.buyproducts.Add(products);
                        db.SaveChanges();
                    }
                    if (cart != null)
                    {
                        db.addcarts.RemoveRange(cart);
                        db.SaveChanges();
                    }
                    OrderHistory history = new OrderHistory
                    {
                        ProductID = buyProduct.ProductID,
                        UserID = userid,
                        ProductQuantity = buyProduct.QuantityValue,
                        OrderDate = DateTime.Now

                    };
                    db.orderhistories.Add(history);
                    db.SaveChanges();
                    
                    return Ok(sellproduct);    
                }
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
       [Route("API/AddCart")]

       public IHttpActionResult AddCart(AddCartVM addCart)
        {
            if (ModelState.IsValid)
            {
                AddCart cart = new AddCart
                {
                    ID = addCart.ID,
                    ProductID = addCart.ProductID,
                    UserID = Convert.ToInt32(HttpContext.Current.Session["ID"]),
                };
                db.addcarts.Add(cart);
                db.SaveChanges();
            }
            return Ok(addCart);
        }
        [HttpPost]
        [Route("API/Rating")]

        public IHttpActionResult Rating(RatingVM ratingVM )
        {
            if (ModelState.IsValid)
            {
                var userid = Convert.ToInt32(HttpContext.Current.Session["ID"]);
                if (userid != 0)
                {
                    Rating rating = new Rating
                    {
                        ID = ratingVM.ID,
                        ProductID = ratingVM.ProductID,
                        RatingNumber = ratingVM.RatingNumber,
                        UserID = Convert.ToInt32(HttpContext.Current.Session["ID"])
                    };
                    db.ratings.Add(rating);
                    db.SaveChanges();
                    return Ok(rating);
                }
                else
                {
                    return BadRequest();
                }

            }
            else
            {
                return BadRequest();
            }
            
        }

        
        [HttpGet]
        [Route("API/MyProducts")]
        public IHttpActionResult MyProducts()
        {
            var userid = Convert.ToInt32(HttpContext.Current.Session["ID"]);
            var getproduct = from d in db.addcarts.ToList()
                             join m in db.products.ToList()
                             on d.ProductID equals m.ProductID
                             select new AddCartVM
                             {
                                 ID = d.ID,
                                 ProductID = d.ProductID,
                                 UserID = d.UserID,
                                 ProductImage = m.ProductImage,
                                 ProductName  = m.ProductName,
                                 ProductPrice = m.ProductPrice
                             };
            var product = getproduct.Where(x => x.UserID == userid).ToList();

            return Ok(product);
        }
    }
}



