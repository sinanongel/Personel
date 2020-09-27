using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Personel.Models.Entity;

namespace Personel.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        db_personelEntities db = new db_personelEntities();
        [AllowAnonymous]
        public ActionResult GirisYap()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult GirisYap(tbl_kullanici k)
        {
            var bilgiler = db.tbl_kullanici.FirstOrDefault(x => x.kullanici_adi == k.kullanici_adi && x.sifre == k.sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanici_adi, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }            
        }
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap");
        }
    }
}