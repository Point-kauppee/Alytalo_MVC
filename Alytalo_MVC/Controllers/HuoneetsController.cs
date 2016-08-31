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
    public class HuoneetsController : Controller
    {
        private MVC_Alytalo_dbEntities db = new MVC_Alytalo_dbEntities();

        // GET: Huoneets
        public ActionResult Index()
        {
            return View(db.Huoneet.ToList());
        }

        public ActionResult HaeValot(int id)
        //public ActionResult HaeValot(string id)
        {
            MVC_Alytalo_dbEntities entities = new MVC_Alytalo_dbEntities();
            List<Valot> valot = (from v in entities.Valot
                                 where v.Huone == id
                                 select v).ToList();
            entities.Dispose();

            List<SimpleValoData> tulos = new List<SimpleValoData>();
            foreach (Valot valo in valot)
            {
                SimpleValoData data = new SimpleValoData();
                data.Valo_id = valo.Valo_id;
                //data.Huone = Int32.Parse(valo.Huone);
                data.Huone = valo.Huone;
                data.Valaisin = valo.Valaisin;
                tulos.Add(data);
            }

            return Json(tulos, JsonRequestBehavior.AllowGet);
        }

        // GET: Huoneets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Huoneet huoneet = db.Huoneet.Find(id);
            if (huoneet == null)
            {
                return HttpNotFound();
            }
            return View(huoneet);
        }

        // GET: Huoneets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Huoneets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Huone_id,Huone")] Huoneet huoneet)
        {
            if (ModelState.IsValid)
            {
                db.Huoneet.Add(huoneet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(huoneet);
        }

        // GET: Huoneets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Huoneet huoneet = db.Huoneet.Find(id);
            if (huoneet == null)
            {
                return HttpNotFound();
            }
            return View(huoneet);
        }

        // POST: Huoneets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Huone_id,Huone")] Huoneet huoneet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(huoneet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(huoneet);
        }

        // GET: Huoneets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Huoneet huoneet = db.Huoneet.Find(id);
            if (huoneet == null)
            {
                return HttpNotFound();
            }
            return View(huoneet);
        }

        // POST: Huoneets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Huoneet huoneet = db.Huoneet.Find(id);
            db.Huoneet.Remove(huoneet);
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
