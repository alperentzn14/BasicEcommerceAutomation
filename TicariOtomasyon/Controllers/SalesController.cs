using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Controllers
{
    public class SalesController : Controller
    {
        Context Context = new Context();
        // GET: Sales
        public ActionResult Index()
        {
            var values = Context.SalesMoves.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewSales()
        {
                        List<SelectListItem> values1 = (from x in Context.Products.ToList() select new SelectListItem
                            {
                        Text = x.ProductName,
                           Value = x.ProductId.ToString()
                              }).ToList();
       
            List<SelectListItem> values2 = (from x in Context.Currents.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CurrentName +" "+ x.CurrentSurName,
                                                Value = x.CurrentId.ToString()
                                            }).ToList();
           

            List<SelectListItem> values3 = (from x in Context.Persons.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.PersonName + " "+x.PersonSurName,
                                                Value=x.PersonId.ToString()
                                            }).ToList();
            ViewBag.vl1 = values1;
            ViewBag.vl2 = values2;
            ViewBag.vl3 = values3;
            return View();


}

        [HttpPost]
        public ActionResult NewSales(SalesMove salesMove)
        {
            salesMove.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            Context.SalesMoves.Add(salesMove);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesFetch(int id)
        {

            List<SelectListItem> values1 = (from x in Context.Products.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ProductName,
                                                Value = x.ProductId.ToString()
                                            }).ToList();

            List<SelectListItem> values2 = (from x in Context.Currents.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CurrentName + " " + x.CurrentSurName,
                                                Value = x.CurrentId.ToString()
                                            }).ToList();


            List<SelectListItem> values3 = (from x in Context.Persons.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.PersonName + " " + x.PersonSurName,
                                                Value = x.PersonId.ToString()
                                            }).ToList();
            ViewBag.vl1 = values1;
            ViewBag.vl2 = values2;
            ViewBag.vl3 = values3;
            var values = Context.SalesMoves.Find(id);
            return View("SalesFetch", values);

        }
        public ActionResult SalesUpdate(SalesMove s)
        {
            var salesMove = Context.SalesMoves.Find(s.SalesMoveId);
            salesMove.CurrentId=s.CurrentId;
            salesMove.Quantity = s.Quantity;
            salesMove.Price=s.Price;
            salesMove.PersonId=s.PersonId;
            salesMove.Date=s.Date;
            salesMove.Total=s.Total;
            salesMove.ProductId=s.ProductId;
          
            Context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SalesDetail(int id)
        {
            var values = Context.SalesMoves.Where(x => x.SalesMoveId == id).ToList();
            return View(values);
        }
    }
}