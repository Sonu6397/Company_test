using Company_test.dbo_connt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Company_test.Controllers
{
    public class HomeController : Controller
    {
        dummyEntities db = new dummyEntities();
        public ActionResult Index()
        {
            var res = db.Emp1.ToList();
            return View(res);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Edit(int id)
        {
            var Et = db.Emp1.Where(x => x.Id == id).FirstOrDefault();
            db.SaveChanges();
            return View(Et);
        }
        [HttpPost]
        public ActionResult Edit(Emp1 a)
        {
            db.Entry(a).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            var Dt = db.Emp1.Where(x => x.Id == id).FirstOrDefault();
            db.Emp1.Remove(Dt);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}