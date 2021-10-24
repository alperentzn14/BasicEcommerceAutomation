using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;
namespace TicariOtomasyon.Controllers
{
    public class GalleryController : Controller
    {
        Context context = new Context();
        // GET: Gallery
        public ActionResult Index()
        {
            var values = context.Products.ToList();
            return View(values);
        }
    }
}