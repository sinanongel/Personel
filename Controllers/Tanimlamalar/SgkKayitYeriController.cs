using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personel.Models.Entity;

namespace Personel.Controllers.Tanımlamalar
{
    public class SgkKayitYeriController : Controller
    {
        // GET: SgkKayitYeri
        db_personelEntities db = new db_personelEntities();
        public ActionResult Index()
        {
            var liste = db.tbl_sgk_kayit_yeri.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult SgkKayitYeriEkle()
        {            
            return PartialView();
        }
        [HttpPost]
        public ActionResult SgkKayitYeriEkle(tbl_sgk_kayit_yeri p1)
        {
            var sgk = db.tbl_firmalar.Where(f => f.firma_id == p1.tbl_firmalar.firma_id).FirstOrDefault();
            p1.tbl_firmalar = sgk;
            db.tbl_sgk_kayit_yeri.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult ComboboxGetir()
        {
             List<SelectListItem> liste = (from i in db.tbl_firmalar.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.firma_adi,
                                              Value = i.firma_id.ToString()
                                          }).ToList();
            ViewBag.sgk = liste;

            return PartialView("SgkKayitYeriEkle");
        }
        public ActionResult SgkKayitYeriGetir(int id)
        {
            var sgk = db.tbl_sgk_kayit_yeri.Find(id);
            List<SelectListItem> liste = (from i in db.tbl_firmalar.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.firma_adi,
                                              Value = i.firma_id.ToString()
                                          }).ToList();
            ViewBag.sgk = liste;
            return View("SgkKayitYeriGetir", sgk);
        }
        public ActionResult SgkKayityeriGuncelle(tbl_sgk_kayit_yeri p)
        {
            var sgk = db.tbl_sgk_kayit_yeri.Find(p.sgk_kayit_yeri_id);
            sgk.sgk_kayit_yeri_adi = p.sgk_kayit_yeri_adi;
            var frm = db.tbl_firmalar.Where(f => f.firma_id == p.tbl_firmalar.firma_id).FirstOrDefault();
            sgk.firma_id = frm.firma_id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}