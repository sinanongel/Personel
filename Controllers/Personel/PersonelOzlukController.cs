using Personel.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Personel.Controllers.Personel
{
    public class PersonelOzlukController : Controller
    {
        db_personelEntities db = new db_personelEntities();
        // GET: PersonelOzluk
        public ActionResult Index(int id)
        {
            var perId = db.tbl_personel.FirstOrDefault(p => p.personel_id == id).personel_id;
            var perKod = db.tbl_personel.FirstOrDefault(p => p.personel_id == id).personel_kodu;
            var perAd = db.tbl_personel.FirstOrDefault(p => p.personel_id == id).personel_adi;
            var perSoyad = db.tbl_personel.FirstOrDefault(p => p.personel_id == id).personel_soyadi;
            var perCinsiyet = db.tbl_personel.FirstOrDefault(p => p.personel_id == id).cinsiyet;
            
            var perFId = db.tbl_personel.FirstOrDefault(p => p.personel_id == id).firma_id;
            var perFirma = db.tbl_firmalar.FirstOrDefault(f => f.firma_id == perFId).firma_adi;

            var perSgkYer = db.tbl_sgk_kayit_yeri.FirstOrDefault(s => s.firma_id == perFId).sgk_kayit_yeri_adi;

            ViewBag.pId = perId;
            ViewBag.pKod = perKod;
            ViewBag.pAd = perAd;
            ViewBag.pSoyad = perSoyad;
            ViewBag.pFirma = perFirma;
            ViewBag.pCinsiyet = perCinsiyet;
            ViewBag.pSgkYer = perSgkYer;

            var liste = db.tbl_personel_ozluk.OrderBy(p => p.personel_id == id).ToList();

            return View(liste);
        }
        public ActionResult ComboboxGetir(int id)
        {
            List<SelectListItem> belgeListe = (from b in db.tbl_ozluk_belgeler.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = b.belge_adi,
                                                   Value = b.belge_id.ToString()
                                               }).ToList();
            belgeListe.Insert(0, new SelectListItem { Text = "Belge Seçiniz", Value = "", Selected = true });

            var per = db.tbl_personel.FirstOrDefault(p => p.personel_id == id);
            var perId = per.personel_id;
            var perKodu = per.personel_kodu;
            var perAdi = per.personel_adi;
            var perSoyadi = per.personel_soyadi;

            ViewBag.bListe = belgeListe;
            ViewBag.pId = perId;
            ViewBag.pKodu = perKodu;
            ViewBag.pAdi = perAdi;
            ViewBag.pSoyadi = perSoyadi;


            return PartialView("OzlukDosyaEkle");
        }
        [HttpGet]
        public ActionResult OzlukDosyaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OzlukDosyaEkle(HttpPostedFileBase dosya_yolu, tbl_personel_ozluk p1)
        {
            var dosya = dosya_yolu;
            var dosyaAdi= "";
            var dosyaYolu = "";
            var dYolu = "";

            if (dosya!=null && dosya.ContentLength > 0)
            {
                if(dosya.ContentType=="image/jpeg"||dosya.ContentType=="image/jpg"||dosya.ContentType== "application/pdf")
                {
                    var d = new FileInfo(dosya.FileName);
                    dosyaAdi = Path.GetFileName(dosya.FileName);
                    dosyaAdi = Guid.NewGuid().ToString() + d.Extension;
                    dYolu= Path.Combine(Server.MapPath("~/dosyalar/"));
                    dosyaYolu = Path.Combine(Server.MapPath("~/dosyalar/"), dosyaAdi);
                    dosya.SaveAs(dosyaYolu);
                }
            }

            var bId = db.tbl_ozluk_belgeler.Where(b => b.belge_id == p1.tbl_ozluk_belgeler.belge_id).FirstOrDefault();
            var id = p1.personel_id;

            p1.dosya_adi = dosyaAdi;
            p1.dosya_yolu = dosyaYolu;
            p1.durum = "VAR";
            p1.tbl_ozluk_belgeler = bId;
            db.tbl_personel_ozluk.Add(p1);
            db.SaveChanges();

            return RedirectToAction("Index", new RouteValueDictionary(new { controller = "PersonelOzluk", action = "Index", Id = id }));
        }
    }
}