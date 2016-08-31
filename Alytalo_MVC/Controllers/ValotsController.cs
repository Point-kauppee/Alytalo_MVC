using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Alytalo_MVC.Models;

namespace Alytalo_MVC.Controllers
{
    public class ValotsController : Controller
    {
        private MVC_Alytalo_dbEntities db = new MVC_Alytalo_dbEntities();

        // GET: Valots
        public ActionResult Index()
        {
            var valot = db.Valot.Include(v => v.Huoneet);
            return View(valot.ToList());
        }

        // GET: Valots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot valot = db.Valot.Find(id);
            if (valot == null)
            {
                return HttpNotFound();
            }
            return View(valot);
        }

        // GET: Valots/Create
        public ActionResult Create()
        {
            ViewBag.Huone = new SelectList(db.Huoneet, "Huone_id", "Huone");
            return View();
        }

        // POST: Valots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Valo_id,Huone,Valaisin,ValonTila,ValonMaara")] Valot valot)
        {
            if (ModelState.IsValid)
            {
                db.Valot.Add(valot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Huone = new SelectList(db.Huoneet, "Huone_id", "Huone", valot.Huone);
            return View(valot);
        }

        // GET: Valots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot valot = db.Valot.Find(id);
            if (valot == null)
            {
                return HttpNotFound();
            }
            ViewBag.Huone = new SelectList(db.Huoneet, "Huone_id", "Huone", valot.Huone);
            return View(valot);
        }

        // POST: Valots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Valo_id,Huone,Valaisin,ValonTila,ValonMaara")] Valot valot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Huone = new SelectList(db.Huoneet, "Huone_id", "Huone", valot.Huone);
            return View(valot);
        }

        // GET: Valots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot valot = db.Valot.Find(id);
            if (valot == null)
            {
                return HttpNotFound();
            }
            return View(valot);
        }

        // POST: Valots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Valot valot = db.Valot.Find(id);
            db.Valot.Remove(valot);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
