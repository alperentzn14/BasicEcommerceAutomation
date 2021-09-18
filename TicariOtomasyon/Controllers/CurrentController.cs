using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Controllers
{
    public class CurrentController : Controller
    {
        Context Context = new Context();
        // GET: Current
        public ActionResult Index()
        {
            var values = Context.Currents.Where(x=>x.Status==true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CurrentAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CurrentAdd(Current current)
        {
            current.Status = true;
            Context.Currents.Add(current);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CurrentDelete(int id)
        {
            var current = Context.Currents.Find(id);
            current.Status = false;
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CurrentFetch(int id)
        {
            var current = Context.Currents.Find(id);
            return View("CurrentFetch", current);
        }
        public ActionResult CurrentUpdate(Current current)
        {
            if(!ModelState.IsValid)//<!--ValidationControl example-->
            {
                return View("CurrentFetch");
            }
            var currents = Context.Currents.Find(current.CurrentId);
            currents.CurrentName = current.CurrentName;
            currents.CurrentSurName = current.CurrentSurName;
            currents.CurrentCity = current.CurrentCity;
            currents.CurrentMail= current.CurrentMail;
            Context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult CustomerSales(int id)
        {
            var values = Context.SalesMoves.Where(x => x.CurrentId == id).ToList();
            var cr = Context.Currents.Where(x => x.CurrentId == id).Select(y => y.CurrentName + " " + y.CurrentSurName).FirstOrDefault();
            ViewBag.current = cr;
            return View(values);
        }
      
    }
}