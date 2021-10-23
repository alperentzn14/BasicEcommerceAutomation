using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Controllers
{
    public class IstatisticController : Controller
    {

        Context context = new Context();
        // GET: Istatistic
        public ActionResult Index()
        {
            var values1 = context.Currents.Count().ToString();
            ViewBag.vl1 = values1;

            var values2 = context.Products.Count().ToString();
            ViewBag.vl2 = values2;

            var values3 = context.Persons.Count().ToString();
            ViewBag.vl3 = values3;

            var values4 = context.Categories.Count().ToString();
            ViewBag.vl4 = values4;

            var values5 = context.Products.Sum(x=>x.Stock).ToString();
            ViewBag.vl5 = values5;

            var values6 = (from x in context.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.vl6 = values6;

            var values7 = context.Products.Count(x=>x.Stock<=20).ToString();
            ViewBag.vl7 = values7;

            var values8 = (from x in context.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.vl8 = values8;

            var values9 = (from x in context.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.vl9 = values9;

            var values10 = context.Products.Count(x => x.ProductName=="İphone 13").ToString();
            ViewBag.vl10 = values10;

            var values11 = context.Products.Count(x => x.ProductName=="tv").ToString();
            ViewBag.vl1 = values11;

            var values12 = context.Products.GroupBy(x => x.Brand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.vl12 = values12;

            var values13 = context.Products.Where(u => u.ProductId == (context.SalesMoves.GroupBy(x => x.ProductId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.ProductName).FirstOrDefault();
                ViewBag.vl13 = values13;

            var values14 = context.SalesMoves.Sum(x => x.Total).ToString();
            ViewBag.vl14 = values14;

            DateTime todays = DateTime.Today;
            var values15 = context.SalesMoves.Count(x => x.Date ==todays).ToString();
            ViewBag.vl15 = values15;

            var values16 = context.SalesMoves.Where(x => x.Date == todays).Sum(y => y.Total).ToString();
            ViewBag.vl16 = values16;
            return View();
        }
    }
}