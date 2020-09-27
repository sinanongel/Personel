using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personel.Models.Entity;

namespace Personel.Controllers
{
    public class GorevController : Controller
    {
        // GET: Gorev
        db_personelEntities db = new db_personelEntities();
        public ActionResult Index()
        {
            var liste = db.tbl_gorevler.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult GorevEkle()
        {
            List<SelectListItem> fListe = (from f in db.tbl_firmalar.ToList()
                                          select new SelectListItem
                                          {
                                              Text = f.firma_adi,
                                              Value = f.firma_id.ToString()
                                          }).ToList();
            List<SelectListItem> bListe = (from b in db.tbl_bolgeler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = b.bolge_adi,
                                               Value = b.bolge_id.ToString()
                                           }).ToList();
            ViewBag.frm = fListe;
            ViewBag.blg = bListe;
            return View();
        }
        [HttpPost]
        public ActionResult GorevEkle(tbl_gorevler p1)
        {
            var frm = db.tbl_firmalar.Where(f => f.firma_id == p1.tbl_firmalar.firma_id).FirstOrDefault();
            var blg = db.tbl_bolgeler.Where(b => b.bolge_id == p1.tbl_bolgeler.bolge_id).FirstOrDefault();
            p1.tbl_firmalar = frm;
            p1.tbl_bolgeler = blg;
            db.tbl_gorevler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GorevGetir(int id)
        {
            var grv = db.tbl_gorevler.Find(id);
            List<SelectListItem> fListe = (from f in db.tbl_firmalar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = f.firma_adi,
                                               Value = f.firma_id.ToString()
                                           }).ToList();
            List<SelectListItem> bListe = (from b in db.tbl_bolgeler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = b.bolge_adi,
                                               Value = b.bolge_id.ToString()
                                           }).ToList();
            ViewBag.frm = fListe;
            ViewBag.blg = bListe;
            return View("GorevGetir", grv);
        }
        public ActionResult GorevGuncelle(tbl_gorevler p)
        {
            var grv = db.tbl_gorevler.Find(p.gorev_id);
            grv.gorev_adi = p.gorev_adi;
            var frm = db.tbl_firmalar.Where(f => f.firma_id == p.tbl_firmalar.firma_id).FirstOrDefault();
            var blg = db.tbl_bolgeler.Where(b => b.bolge_id == p.tbl_bolgeler.bolge_id).FirstOrDefault();
            grv.firma_id = frm.firma_id;
            grv.bolge_id = blg.bolge_id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}