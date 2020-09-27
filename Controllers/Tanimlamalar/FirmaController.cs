using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personel.Models.Entity;

namespace Personel.Controllers
{
    public class FirmaController : Controller
    {
        // GET: Firmalar
        db_personelEntities db = new db_personelEntities();
      
        public ActionResult Index()
        {
            var liste = db.tbl_firmalar.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FirmaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FirmaEkle(tbl_firmalar p1)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("FirmaEkle");
            //}
            db.tbl_firmalar.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FirmaGetir(int id)
        {
            var frm = db.tbl_firmalar.Find(id);
            return View("FirmaGetir", frm);
        }
        public ActionResult Guncelle(tbl_firmalar p1)
        {
            var frm = db.tbl_firmalar.Find(p1.firma_id);
            frm.firma_adi = p1.firma_adi;
            frm.firma_unvani = p1.firma_unvani;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}