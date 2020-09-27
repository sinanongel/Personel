using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personel.Models.Entity;
using Personel.ViewModel;
using PagedList;

namespace Personel.Controllers.Tanimlamalar
{
    public class CalismaYeriController : Controller
    {
        db_personelEntities db = new db_personelEntities();
        FirmaViewModel model = new FirmaViewModel();
        // GET: CalismaYeri
        public ActionResult Index(int sayfa = 1)
        {
            var liste = db.tbl_calisma_yeri.OrderByDescending(c => c.bolge_id).ToList().ToPagedList(sayfa, 10);
            return View();
        }
        [HttpGet]
        public ActionResult CalismaYeriEkle()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult CalismaYeriEkle(tbl_calisma_yeri p1)
        {
            
            return RedirectToAction("Index");
        }
        public ActionResult ComboboxGetir()
        {
            //List<tbl_firmalar> firmaListe = db.tbl_firmalar.ToList();
            //model.FirmaList = (from f in firmaListe
            //                   select new SelectListItem
            //                   {
            //                       Text = f.firma_adi,
            //                       Value = f.firma_id.ToString()
            //                   }).ToList();
            //model.FirmaList.Insert(0, new SelectListItem { Text = "Seçiniz", Value = "", Selected = true });

            List<SelectListItem> firmaListe = (from f in db.tbl_firmalar.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = f.firma_adi,
                                                   Value = f.firma_id.ToString()
                                               }).ToList();
            firmaListe.Insert(0, new SelectListItem { Text = "Seçiniz", Value = "", Selected = true });

            ViewBag.frm = firmaListe;

            return PartialView("CalismaYeriEkle", model);
        }
    }
}