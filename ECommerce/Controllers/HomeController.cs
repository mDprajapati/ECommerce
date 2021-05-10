using ECommerce.Models;
using ECommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private Context db = new Context();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult loginuser()
        {
            ViewBag.Title = "Login Page";
            return View();
        }

        
        public ActionResult PostProduct()
        {
            ProductVM product = new ProductVM();
            ViewBag.catagories = new SelectList(db.catagories, "ID", "CatagoryName");
            ViewBag.quantities = new SelectList(db.quantities, "ID", "QuantityNumbers");

            return View(product);
        }

        public ActionResult NewUser()
        {
            ViewBag.Title = "NewUser";
            return View();
        }
        public ActionResult Afterlogin()
        {
            ViewBag.Title = "LoginUser";
            return View();
        }

        
        public ActionResult MyProducts()
        {
            AddCartVM myproduct = new AddCartVM();
            return View(myproduct);
        }
        public ActionResult OrderHistory()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
        public ActionResult OrderHistoryDetails()
        {
            ViewBag.Title = "OrderDetails";
            return View();
        }

        public ActionResult UpdateProduct(int ProductID)
        {
            var product = db.products.Find(ProductID);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductVM product1 = new ProductVM();
                {
                    product1.ProductID = product.ProductID;
                    product1.ProductName = product.ProductName;
                    product1.ProductImage = product.ProductImage;
                    product1.QuantityID = product.QuantityID;
                    product1.CatagoryID = product.CatagoryID;
                    product1.ProductPrice = product.ProductPrice;
                }
                ViewBag.catagories = new SelectList(db.catagories, "ID", "CatagoryName", product1.CatagoryID);
                ViewBag.quantities = new SelectList(db.quantities, "ID", "QuantityNumbers", product1.QuantityID);

                return View(product1);
            }
        }
    }
}
