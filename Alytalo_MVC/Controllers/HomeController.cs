using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alytalo_MVC.Models;

namespace Alytalo_MVC.Controllers
{
    public class HomeController : Controller
    {
        MVC_Alytalo_dbEntities db = new MVC_Alytalo_dbEntities();
        public ActionResult Index()
        {
            MVC_Alytalo_dbEntities db = new MVC_Alytalo_dbEntities();
            return View(db.Valot);
            //return View();
        }

        [HttpPost]
        public ActionResult Index(string etsiTermi)
        {
            //List<Valot> model = db.Valot.ToList();
            MVC_Alytalo_dbEntities db = new MVC_Alytalo_dbEntities();
            List<Valot> malli;
            if (string.IsNullOrEmpty(etsiTermi))
            {
                malli = db.Valot.ToList();
            }
            else
            {
                malli = db.Valot.Where(x => x.Valaisin.StartsWith(etsiTermi)).ToList();
            }

            return View(malli);
        }
        public PartialViewResult All()
        {
            List<Valot> model = db.Valot.ToList();
            return PartialView("_Valot", model);
        }
        //[HttpPost]
        //public PartialViewResult All(string etsiTermi)
        //{
        //    //List<Valot> model = db.Valot.ToList();
        //    MVC_Alytalo_dbEntities db = new MVC_Alytalo_dbEntities();
        //    List<Valot> model;
        //    if (string.IsNullOrEmpty(etsiTermi))
        //    {
        //        model = db.Valot.ToList();
        //    }
        //    else
        //    {
        //        model = db.Valot.Where(x => x.Valaisin.StartsWith(etsiTermi)).ToList();
        //    }
 
        //    return PartialView("_Valot", model);
        //}

            public JsonResult HaeppaValot(string term)
        {
            MVC_Alytalo_dbEntities db = new MVC_Alytalo_dbEntities();
            List<string> malli;
                 malli = db.Valot.Where(x => x.Valaisin.StartsWith(term)).Select(y => y.Valaisin).ToList();
            return Json(malli, JsonRequestBehavior.AllowGet);

        }

        public PartialViewResult HaeValot()
        {
            List<Valot> model = db.Valot.Where(x => x.ValonTila.Equals("1")).ToList();
            return PartialView("_Valot", model);
        }


        //public ActionResult HaePaallaValot(int? id)
        //public ActionResult HaeValot(string id)
        [HttpGet]
        public PartialViewResult HaePaallaValot()
        {
            using (MVC_Alytalo_dbEntities entities = new MVC_Alytalo_dbEntities())
            { 
                List<Valot> valot = (from v in entities.Valot
                                     where v.ValonTila == "1"
                                     select v).ToList();
            entities.Dispose();
            return PartialView("_Valot", valot);
            //return Json(valotpaalla, JsonRequestBehavior.AllowGet);
        }
        }

        public PartialViewResult PaallaValot()
        {
            MVC_Alytalo_dbEntities entities = new MVC_Alytalo_dbEntities();
            List<Valot> valot = (from v in entities.Valot
                                 where v.ValonTila == "1"
                                 select v).ToList();
            entities.Dispose();

            List<SimpleValoData> valotpaalla = new List<SimpleValoData>();
            foreach (Valot valo in valot)
            {
                SimpleValoData data = new SimpleValoData();
                data.Valo_id = valo.Valo_id;
                //data.Huone = Int32.Parse(valo.Huone);
                data.Huone = valo.Huone;
                data.Valaisin = valo.Valaisin;
                data.ValonTila = valo.ValonTila;
                data.ValonMaara = valo.ValonMaara;
                valotpaalla.Add(data);
            }
            return PartialView("_Valot", valot);
            //return Json(valotpaalla, JsonRequestBehavior.AllowGet);
        }

        //public PartialViewResult ValotPaalla()
        //{
        //    using (var db = new MVC_Alytalo_dbEntities())
        //    {
        //        //string paalla = "1";
        //        //List<Valot> model = db.Valot.ToList();
        //        List<Valot> model = (from valot in db.Valot select valot).ToList();


        //    return PartialView("_Valot", model);
        //}
        //}

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
    }
}