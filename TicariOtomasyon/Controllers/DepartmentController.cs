using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Classes;

namespace TicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        Context Context = new Context();
        // GET: Department
        public ActionResult Index()
        {

            var values=Context.Departments.Where(x=>x.Status==true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult DepartmentAdd()
        {

            return View();

        }
        [HttpPost]
        public ActionResult DepartmentAdd(Department department)
        {
            department.Status = true;
            Context.Departments.Add(department);
            Context.SaveChanges();
            return RedirectToAction("Index");
           
        }
    
        public ActionResult DepartmentDelete(int id)
        {
            var department = Context.Departments.Find(id);
            department.Status = false;
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentFetch(int id)
        {
            var department = Context.Departments.Find(id);
            return View("DepartmentFetch", department);

        }
          public ActionResult DepartmentUpdate(Department departments)
        {
            var department = Context.Departments.Find(departments.DepartmentId);
            department.DepartmantName = departments.DepartmantName;
            Context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DepartmentDetail(int id)
        {
            var values = Context.Persons.Where(x => x.DepartmentId == id).ToList();
            var department = Context.Departments.Where(x => x.DepartmentId == id).Select(y => y.DepartmantName).FirstOrDefault();
            ViewBag.d = department;
            return View(values);
        }
        public ActionResult DepartmentPersonHands(int id)
        {
            var values = Context.SalesMoves.Where(x => x.PersonId == id).ToList();
            var person = Context.Persons.Where(x => x.PersonId == id).Select(y => y.PersonName +" "+ y.PersonSurName).FirstOrDefault();
            ViewBag.dp = person;
            return View(values);
        }
    }
}