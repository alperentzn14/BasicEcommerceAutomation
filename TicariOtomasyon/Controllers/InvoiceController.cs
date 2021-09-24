using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Controllers
{
    public class InvoiceController : Controller
    {
        Context Context = new Context();
        // GET: Invoice
        public ActionResult Index()
        {
            var list = Context.Invoices.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult InvoiceAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InvoiceAdd(Invoice ınvoice)
        {
            Context.Invoices.Add(ınvoice);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult InvoiceFetch(int id)
        {
            var values = Context.Invoices.Find(id);
            return View("InvoiceFetch", values);
        }
        public ActionResult InvoiceUpdate(Invoice ınvoice)
        {
            var values = Context.Invoices.Find(ınvoice.InvoiceId);
            values.InvoiceSerialNumber = ınvoice.InvoiceSerialNumber;
            values.InvoiceOrderNumber = ınvoice.InvoiceOrderNumber;
            values.InvoiceHour = ınvoice.InvoiceHour;
            values.InvoiceDate = ınvoice.InvoiceDate;
            values.InvoiceToSubmit = ınvoice.InvoiceToSubmit;
            values.InvoiceReceive = ınvoice.InvoiceReceive;
            values.InvoiceTaxOffice = ınvoice.InvoiceTaxOffice;
            Context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult InvoiceDetail(int id)
        {
            var values = Context.InvoicePens.Where(x => x.InvoiceId== id).ToList();
             return View(values);
        }
        [HttpGet]
        public ActionResult NewPen()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewPen(InvoicePen ınvoicePen)
        {
            Context.InvoicePens.Add(ınvoicePen);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}