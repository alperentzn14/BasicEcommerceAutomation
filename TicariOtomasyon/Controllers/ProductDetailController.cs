using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        Context context = new Context();
        // GET: ProductDetail
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.values1 = context.Products.Where(x => x.ProductId == 1).ToList();
            cs.values2 = context.Details.Where(y => y.DetailID == 1).ToList();
            //var values = context.Products.Where(x => x.ProductId == 1).ToList();
            return View(cs);
        }
    }
}