using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personel.Models.Entity;

namespace Personel.Controllers
{
    public class BolgeController : Controller
    {
        // GET: Bolge
        db_personelEntities db = new db_personelEntities();
        public ActionResult Index()
        {
            var liste = db.tbl_bolgeler.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult BolgeEkle()
        {
            List<SelectListItem> liste = (from i in db.tbl_firmalar.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.firma_adi,
                                              Value = i.firma_id.ToString()
                                          }).ToList();
            ViewBag.blg = liste;
            return View();
        }
        [HttpPost]
        public ActionResult BolgeEkle(tbl_bolgeler p1)
        {
            var blg = db.tbl_firmalar.Where(f => f.firma_id == p1.tbl_firmalar.firma_id).FirstOrDefault();
            p1.tbl_firmalar = blg;
            db.tbl_bolgeler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BolgeGetir(int id)
        {
            var blg = db.tbl_bolgeler.Find(id);
            List<SelectListItem> liste = (from i in db.tbl_firmalar.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.firma_adi,
                                              Value = i.firma_id.ToString()
                                          }).ToList();
            ViewBag.blg = liste;
            return View("BolgeGetir", blg);
        }
        public ActionResult BolgeGuncelle(tbl_bolgeler p)
        {
            var blg = db.tbl_bolgeler.Find(p.bolge_id);
            blg.bolge_adi = p.bolge_adi;
            var frm = db.tbl_firmalar.Where(f => f.firma_id == p.tbl_firmalar.firma_id).FirstOrDefault();
            blg.firma_id = frm.firma_id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}