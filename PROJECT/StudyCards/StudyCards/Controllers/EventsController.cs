using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyCards.Models;
using System.Text.RegularExpressions;

namespace StudyCards.Controllers
{
    public class EventsController : Controller
    {
        private EventDBContext db = new EventDBContext();

        //
        // GET: /Events/

        //public ActionResult Index()
        //{
        //    return View(db.Events.ToList());
        //}

        // Searching Portion
        public ActionResult Index(string SearchParam)
        {
            Regex regex = new Regex(@"^[1-9][0-9]*$");

            if (string.IsNullOrEmpty(SearchParam) || !regex.IsMatch(SearchParam))
                return View(db.Events.ToList());
            else
            {
                
                int CourseId = Convert.ToInt16(SearchParam);
                return View(db.Events.Where(e => e.CourseID == CourseId).ToList());
            }
        }

        //
        // GET: /Events/Details/5

        public ActionResult Details(int id = 0)
        {
            Event event1 = db.Events.Find(id);
            if (event1 == null)
            {
                return HttpNotFound();
            }
            return View(event1);
        }

        //
        // GET: /Events/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Events/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event event1)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(event1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(event1);
        }

        //
        // GET: /Events/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Event event1 = db.Events.Find(id);
            if (event1 == null)
            {
                return HttpNotFound();
            }
            return View(event1);
        }

        //
        // POST: /Events/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event event1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(event1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(event1);
        }

        //
        // GET: /Events/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Event event1 = db.Events.Find(id);
            if (event1 == null)
            {
                return HttpNotFound();
            }
            return View(event1);
        }

        //
        // POST: /Events/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event event1 = db.Events.Find(id);
            db.Events.Remove(event1);
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