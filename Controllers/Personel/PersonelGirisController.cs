using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personel.Models.Entity;
using Personel.ViewModel;
using PagedList;
using PagedList.Mvc;

namespace Personel.Controllers.Personel
{
    public class PersonelGirisController : Controller
    {
        db_personelEntities db = new db_personelEntities();
        tbl_personel model = new tbl_personel();

        public ActionResult Index(int sayfa = 1)
        {
            var liste = db.tbl_personel.OrderByDescending(p => p.personel_id).ToList().ToPagedList(sayfa, 10);

            return View(liste);
        }
        [HttpGet]        
        public ActionResult PersonelEkle()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult PersonelEkle(tbl_personel p1)
        {
            p1.durum = "AKTİF";
            db.tbl_personel.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult ComboboxGetir()
        {
            List<tbl_firmalar> firmaListe = db.tbl_firmalar.ToList();
            model.FirmaList = (from f in firmaListe
                               select new SelectListItem
                               {
                                   Text = f.firma_adi,
                                   Value = f.firma_id.ToString()
                               }).ToList();
            model.FirmaList.Insert(0, new SelectListItem { Text = "Seçiniz", Value = "", Selected = true });

            return PartialView("PersonelEkle", model);
        }
        public ActionResult PersonelGetir(int? id)
        {
            var per = db.tbl_personel.Find(id);

            List<tbl_firmalar> firmaListe = db.tbl_firmalar.ToList();
            List<SelectListItem> liste = (from f in firmaListe
                                          select new SelectListItem
                                          {
                                              Text = f.firma_adi,
                                              Value = f.firma_id.ToString()
                                          }).ToList();
            //List<SelectListItem> sListe = (from s in db.tbl_sgk_kayit_yeri.ToList()
            //                               select new SelectListItem
            //                               {
            //                                   Text = s.sgk_kayit_yeri_adi,
            //                                   Value = s.sgk_kayit_yeri_id.ToString()
            //                               }).ToList();

            ViewBag.frm = liste;
            //ViewBag.sgk = sListe;
            return PartialView("PersonelGetir", per);            
        }
        public ActionResult PersonelGuncelle(tbl_personel p)
        {
            var per = db.tbl_personel.Find(p.personel_id);
            per.personel_kodu = p.personel_kodu;
            per.personel_adi = p.personel_adi;
            per.personel_soyadi = p.personel_soyadi;
            per.firma_id = p.firma_id;
            //per.sgk_kayit_yeri_id = p.sgk_kayit_yeri_id;
            per.ise_giris_tarihi = p.ise_giris_tarihi;
            per.isten_cikis_tarihi = p.isten_cikis_tarihi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Detay(int? id)
        {
            var personel = (db.tbl_personel.FirstOrDefault(p => p.personel_id == id));

            return View("Detay", personel);
        }
        [HttpPost]
        public JsonResult SgkKayitYeriList(int id)
        {
            List<tbl_sgk_kayit_yeri> sgkKayitYeriList = db.tbl_sgk_kayit_yeri.Where(s => s.firma_id == id).OrderBy(s => s.sgk_kayit_yeri_adi).ToList();

            List<SelectListItem> sgkList = (from i in sgkKayitYeriList
                                            select new SelectListItem
                                            {
                                                Text = i.sgk_kayit_yeri_adi,
                                                Value = i.sgk_kayit_yeri_id.ToString()
                                            }).ToList();

            return Json(sgkList, JsonRequestBehavior.AllowGet);
        }
    }
}