using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context Context = new Context();
        public ActionResult Index()
        {
            var values = Context.Categories.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category category)
        {
            Context.Categories.Add(category);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryDelete(int id)
        {
            var category = Context.Categories.Find(id);
            Context.Categories.Remove(category);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryFetch(int id)
        {
            var category = Context.Categories.Find(id);

            return View("CategoryFetch", category);
        }
        public ActionResult CategoryUpdate(Category categories)
        {
            var category = Context.Categories.Find(categories.CategoryId);
            category.CategoryName = categories.CategoryName;
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}