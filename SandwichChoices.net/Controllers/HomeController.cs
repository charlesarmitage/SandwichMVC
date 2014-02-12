using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SandwichChoices.net.Models;

namespace SandwichChoices.net.Controllers
{
    public class HomeController : Controller
    {
        private SandwichDbContext db = new SandwichDbContext();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(db.Sandwiches.ToList());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            Sandwich sandwich = db.Sandwiches.Find(id);
            if (sandwich == null)
            {
                return HttpNotFound();
            }
            return View(sandwich);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(Sandwich sandwich)
        {
            if (ModelState.IsValid)
            {
                db.Sandwiches.Add(sandwich);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sandwich);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Sandwich sandwich = db.Sandwiches.Find(id);
            if (sandwich == null)
            {
                return HttpNotFound();
            }
            return View(sandwich);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(Sandwich sandwich)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sandwich).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sandwich);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Sandwich sandwich = db.Sandwiches.Find(id);
            if (sandwich == null)
            {
                return HttpNotFound();
            }
            return View(sandwich);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Sandwich sandwich = db.Sandwiches.Find(id);
            db.Sandwiches.Remove(sandwich);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}