using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Controllers
{
    public class PersonController : Controller
    {
        Context Context = new Context();
        // GET: Person
        public ActionResult Index()
        {
            var values = Context.Persons.Where(x => x.Status == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult PersonAdd()
        {
            List<SelectListItem> value1 = (from x in Context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmantName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.vl1 = value1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonAdd(Person person)
        {
            person.Status = true;
            Context.Persons.Add(person);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonFetch(int id)
        {
            ///Dropdown GET DEPARTMENT  NAME 
            List<SelectListItem> value1 = (from x in Context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmantName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.vl1 = value1;

            var value2 = Context.Persons.Find(id);

            return View("PersonFetch", value2);
        }
        public ActionResult PersonUpdate(Person person)
        {
            var values = Context.Persons.Find(person.PersonId);
            values.PersonName = person.PersonName;
            values.PersonSurName = person.PersonSurName;
            values.PersonImage = person.PersonImage;
            values.DepartmentId = person.DepartmentId;
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonDelete(int id)
        {
            var person = Context.Persons.Find(id);
            person.Status = false;
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}