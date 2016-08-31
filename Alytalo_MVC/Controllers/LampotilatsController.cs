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
    public class LampotilatsController : Controller
    {
        private MVC_Alytalo_dbEntities db = new MVC_Alytalo_dbEntities();

        // GET: Lampotilats
        public ActionResult Index()
        {
            var lampotilat = db.Lampotilat.Include(l => l.Huoneet);
            return View(lampotilat.ToList());
        }

        // GET: Lampotilats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lampotilat lampotilat = db.Lampotilat.Find(id);
            if (lampotilat == null)
            {
                return HttpNotFound();
            }
            return View(lampotilat);
        }

        // GET: Lampotilats/Create
        public ActionResult Create()
        {
            ViewBag.Huone = new SelectList(db.Huoneet, "Huone_id", "Huone");
            return View();
        }

        // POST: Lampotilats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Lampotila_id,Huone,NykyLampotila,TavoiteLampotila")] Lampotilat lampotilat)
        {
            if (ModelState.IsValid)
            {
                db.Lampotilat.Add(lampotilat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Huone = new SelectList(db.Huoneet, "Huone_id", "Huone", lampotilat.Huone);
            return View(lampotilat);
        }

        // GET: Lampotilats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lampotilat lampotilat = db.Lampotilat.Find(id);
            if (lampotilat == null)
            {
                return HttpNotFound();
            }
            ViewBag.Huone = new SelectList(db.Huoneet, "Huone_id", "Huone", lampotilat.Huone);
            return View(lampotilat);
        }

        // POST: Lampotilats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Lampotila_id,Huone,NykyLampotila,TavoiteLampotila")] Lampotilat lampotilat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lampotilat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Huone = new SelectList(db.Huoneet, "Huone_id", "Huone", lampotilat.Huone);
            return View(lampotilat);
        }

        // GET: Lampotilats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lampotilat lampotilat = db.Lampotilat.Find(id);
            if (lampotilat == null)
            {
                return HttpNotFound();
            }
            return View(lampotilat);
        }

        // POST: Lampotilats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lampotilat lampotilat = db.Lampotilat.Find(id);
            db.Lampotilat.Remove(lampotilat);
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
