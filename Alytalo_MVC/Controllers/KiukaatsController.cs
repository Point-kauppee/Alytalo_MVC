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
    public class KiukaatsController : Controller
    {
        private MVC_Alytalo_dbEntities db = new MVC_Alytalo_dbEntities();

        // GET: Kiukaats
        public ActionResult Index()
        {
            var kiukaat = db.Kiukaat.Include(k => k.Huoneet);
            return View(kiukaat.ToList());
        }

        // GET: Kiukaats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kiukaat kiukaat = db.Kiukaat.Find(id);
            if (kiukaat == null)
            {
                return HttpNotFound();
            }
            return View(kiukaat);
        }

        // GET: Kiukaats/Create
        public ActionResult Create()
        {
            ViewBag.Huone = new SelectList(db.Huoneet, "Huone_id", "Huone");
            return View();
        }

        // POST: Kiukaats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Kiuas_id,Huone,KiukaanTila,NykyLampotila,TavoiteLampotila")] Kiukaat kiukaat)
        {
            if (ModelState.IsValid)
            {
                db.Kiukaat.Add(kiukaat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Huone = new SelectList(db.Huoneet, "Huone_id", "Huone", kiukaat.Huone);
            return View(kiukaat);
        }

        // GET: Kiukaats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kiukaat kiukaat = db.Kiukaat.Find(id);
            if (kiukaat == null)
            {
                return HttpNotFound();
            }
            ViewBag.Huone = new SelectList(db.Huoneet, "Huone_id", "Huone", kiukaat.Huone);
            return View(kiukaat);
        }

        // POST: Kiukaats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Kiuas_id,Huone,KiukaanTila,NykyLampotila,TavoiteLampotila")] Kiukaat kiukaat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kiukaat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Huone = new SelectList(db.Huoneet, "Huone_id", "Huone", kiukaat.Huone);
            return View(kiukaat);
        }

        // GET: Kiukaats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kiukaat kiukaat = db.Kiukaat.Find(id);
            if (kiukaat == null)
            {
                return HttpNotFound();
            }
            return View(kiukaat);
        }

        // POST: Kiukaats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kiukaat kiukaat = db.Kiukaat.Find(id);
            db.Kiukaat.Remove(kiukaat);
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
