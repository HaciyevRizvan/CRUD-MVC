using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crud.Models;
using System.Data.Entity;


namespace Crud.Areas.Admins.Controllers
{
    public class HomeController : Controller
    {
        TeacherEnt db = new TeacherEnt();
        private object entitystate;
        // GET: Admins/Home
        public ActionResult Index()
        {
            ViewBag.teach = db.teacher.OrderBy(i => i.id).ToList();
            return View();
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert([Bind(Include ="id,teachName,teachSurname")]teacher tch)
        {
            if (ModelState.IsValid)
            {
                db.teacher.Add(tch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                return View(tch);
        } 

        [HttpGet]
        public ActionResult Delete(int id)
        {

                teacher tch = db.teacher.SingleOrDefault(x => x.id == id);
                db.teacher.Remove(tch);
                db.SaveChanges();
                return RedirectToAction("Index");
        
         
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Update([Bind(Include = "id,teachName,teachSurname")]teacher tch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tch);
        }
    }
}