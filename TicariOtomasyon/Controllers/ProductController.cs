using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        Context Context = new Context();
        // GET: Product
        public ActionResult Index()
        {
            var Product = Context.Products.Where(x => x.Status == true).ToList(); 
            return View(Product);
        }
        [HttpGet]
        public ActionResult ProductAdd()
        {
            List<SelectListItem> value1 = (from x in Context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.vl1 = value1;
            return View();

        }
        [HttpPost]
        public ActionResult ProductAdd(Product product)
        {

            Context.Products.Add(product);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductDelete(int id)////true-false
        {
            var value = Context.Products.Find(id);
            value.Status = false;
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductFetch(int id)
        {
            ///Dropdown GET CATEGORY NAME 
            List<SelectListItem> value1 = (from x in Context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.vl1 = value1;
          
            var value2 = Context.Products.Find(id);

            return View("ProductFetch",value2);
        }
        public ActionResult ProductUpdate(Product p)
        {
            var product = Context.Products.Find(p.ProductId);
            product.PurchasePrice = p.PurchasePrice;
            product.Status = p.Status;
            product.CategoryId = p.CategoryId;
            product.Brand = p.Brand;
            product.SalePrice = p.SalePrice;
            product.Stock = p.Stock;
            product.ProductName = p.ProductName;
            product.ProductImage = p.ProductImage;
            Context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}