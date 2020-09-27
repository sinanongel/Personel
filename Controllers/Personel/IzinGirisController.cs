using Npgsql;
using Personel.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Personel.ViewModel;

namespace Personel.Controllers.Personel
{
    public class IzinGirisController : Controller
    {
        // GET: IzinGiris
        db_personelEntities db = new db_personelEntities();
        tbl_izinler model = new tbl_izinler();
        public ActionResult Index(int id)
        {
            List<tbl_izinler> izinler = db.tbl_izinler.ToList();
            List<tbl_mazeret_turu> mazeretler = db.tbl_mazeret_turu.ToList();
            List<tbl_personel> personeller = db.tbl_personel.ToList();
            List<tbl_izin_turu> izinTurleri = db.tbl_izin_turu.ToList();

            var liste = (from i in izinler
                        join m in mazeretler on i.mazeret_id equals m.mazeret_id into mazeret
                        from m in mazeret.DefaultIfEmpty(new tbl_mazeret_turu())
                        join p in personeller on i.personel_id equals p.personel_id
                        join it in izinTurleri on i.izin_tur_id equals it.izin_tur_id
                         where i.personel_id == id
                         orderby i.izin_baslama_tarihi descending
                        select new IzinListe { izinDetay = i, mazeretDetay = m, izinTurDetay = it }).ToList();

            var personel = db.tbl_personel.FirstOrDefault(p => p.personel_id == id);
            var kalanYIzin = 0;            

            if ( liste.Count != 0)
            {
                var maxId = db.tbl_izinler.Max(i => i.izin_id);
                kalanYIzin = Convert.ToInt32(db.tbl_izinler.FirstOrDefault(i => i.personel_id == id && i.izin_id == maxId).kalan_yillik_izin);
            }

            ViewBag.kalYIzin = kalanYIzin;

            return View(Tuple.Create(personel, liste));
        }
        [HttpPost]
        public ActionResult ComboboxGetir(int id)
        {
            List<SelectListItem> mzrListe = (from m in db.tbl_mazeret_turu.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = m.mazeret_tur_adi,
                                                 Value = m.mazeret_id.ToString()
                                             }).ToList();
            mzrListe.Insert(0, new SelectListItem { Text = "Seçiniz", Value = "", Selected = true });

            List<tbl_izin_turu> iTurListe = db.tbl_izin_turu.ToList();
            model.IzinturList = (from it in db.tbl_izin_turu.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = it.izin_tur_adi,
                                                 Value = it.izin_tur_id.ToString()
                                             }).ToList();
            model.IzinturList.Insert(0, new SelectListItem { Text = "Seçiniz", Value = "", Selected = true });



            var per = db.tbl_personel.FirstOrDefault(p => p.personel_id == id);
            var perId = per.personel_id;
            var perKodu = per.personel_kodu;
            var perAdi = per.personel_adi;
            var perSoyadi = per.personel_soyadi;
            var isBasT = per.ise_giris_tarihi.ToString("dd.MM.yyyy");

            ViewBag.pId = perId;
            ViewBag.pKodu = perKodu;
            ViewBag.pAdi = perAdi;
            ViewBag.pSoyadi = perSoyadi;
            ViewBag.mzr = mzrListe;
            ViewBag.iBasT = isBasT;

            return PartialView("IzinEkle", model);
        }
        [HttpGet]
        public ActionResult IzinEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IzinEkle(tbl_izinler p1)
        {
            var mzrTur = db.tbl_mazeret_turu.Where(m => m.mazeret_id == p1.tbl_mazeret_turu.mazeret_id).FirstOrDefault();
            var id = p1.personel_id;

            p1.tbl_mazeret_turu = mzrTur;
            db.tbl_izinler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index", new RouteValueDictionary(new { controller = "IzinGiris", action = "Index", Id = id }));
        }
        public ActionResult Sil(int id)
        {
            var izin = db.tbl_izinler.Find(id);
            var pId = izin.personel_id;
            db.tbl_izinler.Remove(izin);
            db.SaveChanges();
            return RedirectToAction("Index", new RouteValueDictionary(new { controller = "IzinGiris", action = "Index", Id = pId }));
        }
        public ActionResult IzinGetir(int? id)
        {
            var izin = db.tbl_izinler.Find(id);
            var per = db.tbl_personel.FirstOrDefault(p => p.personel_id == izin.personel_id);
            var perId = per.personel_id;
            var perKodu = per.personel_kodu;
            var perAdi = per.personel_adi;
            var perSoyadi = per.personel_soyadi;
            var isBasT = per.ise_giris_tarihi.ToString("dd.MM.yyyy");

            List<tbl_izin_turu> izinListe = db.tbl_izin_turu.ToList();
            List<SelectListItem> iTurListe = (from it in izinListe
                                           select new SelectListItem
                                           {
                                               Text = it.izin_tur_adi,
                                               Value = it.izin_tur_id.ToString()
                                           }).ToList();

            List<tbl_mazeret_turu> mazListe = db.tbl_mazeret_turu.ToList();
            List<SelectListItem> mzrListe = (from m in mazListe
                                             select new SelectListItem
                                             {
                                                 Text = m.mazeret_tur_adi,
                                                 Value = m.mazeret_id.ToString()
                                             }).ToList();
            mzrListe.Insert(0, new SelectListItem { Text = "Seçiniz", Value = "", Selected = true });

            ViewBag.pKodu = perKodu;
            ViewBag.pAdi = perAdi;
            ViewBag.pSoyadi = perSoyadi;
            ViewBag.mzr = mzrListe;
            ViewBag.itl = iTurListe;
            ViewBag.iBasT = isBasT;
            ViewBag.pId = perId;

            return PartialView("IzinGetir", izin);
        }
        public ActionResult IzinGuncelle(tbl_izinler p)
        {
            var izin = db.tbl_izinler.Find(p.izin_id);
            izin.personel_id = p.personel_id;
            izin.izin_tur_id = p.izin_tur_id;
            izin.mazeret_id = p.mazeret_id;
            izin.izin_baslama_tarihi = p.izin_baslama_tarihi;
            izin.izin_bitis_tarihi = p.izin_bitis_tarihi;
            izin.calisilan_sure = p.calisilan_sure;
            izin.tahakkuk_eden_yillik_izin = p.tahakkuk_eden_yillik_izin;
            izin.kullanilan_yillik_izin = p.kullanilan_yillik_izin;
            izin.kalan_yillik_izin = p.kalan_yillik_izin;
            izin.kullanilan_mazeret_izin = p.kullanilan_mazeret_izin;
            db.SaveChanges();

            var pId = izin.personel_id;

            return RedirectToAction("Index", new RouteValueDictionary(new { controller = "IzinGiris", action = "Index", Id = pId }));
        }
        [HttpPost]
        public ActionResult Detay(int? id)
        {
            var personel = (db.tbl_personel.FirstOrDefault(p => p.personel_id == id));
            var liste = db.tbl_izinler.Where(i=>i.personel_id==id).ToList();

            return PartialView(personel);
        }
        [HttpPost]
        public JsonResult Hesaplama(tbl_izinler izin)
        {
            DateTime iBasT = izin.izin_baslama_tarihi;
            DateTime iBitT = izin.izin_bitis_tarihi;
            var pId = izin.personel_id;
            var iTur = izin.izin_tur_id;
            var iId = izin.izin_id;
            int tIzin = Convert.ToInt32(izin.tahakkuk_eden_yillik_izin);

            var tahEYI = 0;
            var yIzinSure = 0;
            var mIzinSure = 0;
            var kalanYI = 0;
            var kIzin = 0;

            var per = db.tbl_personel.FirstOrDefault(p => p.personel_id == pId);
            DateTime isGirT = per.ise_giris_tarihi;

            var kulIzToplam = db.tbl_izinler.Where(i => i.personel_id == pId).Sum(i => i.kullanilan_yillik_izin);
            var tahIzToplam = db.tbl_izinler.Where(i => i.personel_id == pId).Sum(i => i.tahakkuk_eden_yillik_izin);

            if (iId != 0)
            {
                kIzin = Convert.ToInt32(db.tbl_izinler.Where(i => i.izin_id == iId).Sum(i => i.kullanilan_yillik_izin));
            }           

            int kulTYIzin = Convert.ToInt32(kulIzToplam);
            int tahTYIzin = Convert.ToInt32(tahIzToplam);
            int kalYIz = tahTYIzin - kulTYIzin;

            TimeSpan calisilanSure = iBasT - isGirT;
            var cSonuc = Math.Floor(calisilanSure.TotalDays/365);
            var k = db.tbl_izinler.Where(i => i.calisilan_sure == cSonuc && i.personel_id == pId);
            var kidem = k.Count();
            int calSure = Convert.ToInt32(cSonuc);

            List<DateTime> ResmiTatil = new List<DateTime>();
            foreach(var rtListe in db.tbl_resmi_tatil.ToList())
            {
                ResmiTatil.Add(rtListe.tarih);
            }
            int resmiTatil = 0;

            foreach(DateTime rt in ResmiTatil)
            {
                if(rt.ToString("dddd")!="Pazar" && (rt >= iBasT && rt <= iBitT))
                {
                    resmiTatil++;
                }
            }

            int rtsonuc = resmiTatil;          
            
            DateTime geciciTarih = iBasT;
            int gunSay = 0;
            string gun = string.Empty;

            while (geciciTarih <= iBitT)
            {
                gun = geciciTarih.ToString("dddd");
                if (gun != "Pazar")
                {
                    gunSay++;
                }
                geciciTarih = geciciTarih.AddDays(1);
            }
            int ptsonuc = gunSay;
            int tahSonuc;

            if (iTur == 1)
            {
                yIzinSure = ptsonuc - rtsonuc;

                if (cSonuc < 1)
                {
                    tahEYI = 0;
                    kalanYI = (tahEYI + tahTYIzin) - (yIzinSure + kulTYIzin);
                }
                if ((cSonuc >= 1) && (cSonuc <= 5))
                {                    
                    if (kidem != 0)
                    {
                        tahEYI = 0;
                    }
                    else
                    {
                        tahSonuc = 14 * calSure;
                        if (tahSonuc > tahTYIzin)
                        {
                            tahEYI = (14 * calSure) - tahTYIzin;
                        }
                        else
                        {
                            tahEYI = 0;
                        }                        
                    }
                    
                    kalanYI = (tahEYI + tahTYIzin) - (yIzinSure + kulTYIzin);
                }
                if ((cSonuc > 5) && (cSonuc < 15))
                {
                    if (kidem != 0)
                    {
                        tahEYI = 0;
                    }
                    else
                    {
                        int cSure = 0;
                        cSure = calSure - 5;
                        int kalansure = 14 * 5;
                        tahSonuc = (20 * cSure) + kalansure;

                        if (tahSonuc > tahTYIzin)                        {
                            
                            tahEYI = tahSonuc - tahTYIzin;
                        }
                        else
                        {
                            tahEYI = 0;
                        }
                    }
                    kalanYI = (tahEYI + tahTYIzin) - (yIzinSure + kulTYIzin);
                }
                if (cSonuc >= 15)
                {
                    if (kidem != 0)
                    {
                        tahEYI = 0;
                    }
                    else
                    {
                        tahSonuc = 26 * calSure;
                        if (tahSonuc > tahTYIzin)
                        {
                            tahEYI = (26 * calSure) - tahTYIzin;
                        }
                        else
                        {
                            tahEYI = 0;
                        }
                    }
                    kalanYI = (tahEYI + tahTYIzin) - (yIzinSure + kulTYIzin);
                }

            }
            else if (iTur == 2)
            {
                mIzinSure = ptsonuc - rtsonuc;
            }

            if (iId != 0)
            {
                kalanYI = kalanYI + kIzin;
                tahEYI = tIzin;
            }

            var sonuc = new { tahEYI, yIzinSure, mIzinSure, kalanYI, cSonuc };

            return Json(sonuc, JsonRequestBehavior.AllowGet);
        }
    }
}