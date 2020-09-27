using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personel.Models.Entity;
using Personel.ViewModel;

namespace Personel.Controllers
{
    public class IzinIcmalController : Controller
    {
        db_personelEntities db = new db_personelEntities();        
        // GET: IzinIcmal
        public ActionResult Index()
        {
            List<tbl_izinler> izinler = db.tbl_izinler.ToList();
            List<tbl_personel> personeller = db.tbl_personel.ToList();
            List<tbl_firmalar> firmalar = db.tbl_firmalar.ToList();

            var liste = (from p in personeller
                         join i in izinler on p.personel_id equals i.personel_id into izin
                         from i in izin.DefaultIfEmpty(new tbl_izinler())
                         join f in firmalar on p.firma_id equals f.firma_id
                         group i by new { p.personel_adi, p.personel_soyadi, p.ise_giris_tarihi, f.firma_adi } into g
                         orderby g.Key.personel_adi
                         select new IzinListe
                         {
                             PersonelAdi = g.Key.personel_adi + " " + g.Key.personel_soyadi,
                             FirmaAdi=g.Key.firma_adi,
                             İseGirisTarihi = g.Key.ise_giris_tarihi,
                             TahEdenToplam = (int)g.Sum(i => i.tahakkuk_eden_yillik_izin),
                             KulToplam = (int)g.Sum(i => i.kullanilan_yillik_izin),
                             KalanYIzin = (int)g.Sum(i => i.tahakkuk_eden_yillik_izin) - (int)g.Sum(i => i.kullanilan_yillik_izin)
                         }).ToList();

            return View(liste);
        }
    }
}