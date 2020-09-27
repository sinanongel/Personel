using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Personel.ViewModel
{
    public class FirmaViewModel
    {
        public int FirmaId { get; set; }
        public int SgkKayitYeriId { get; set; }

        public List<SelectListItem> FirmaList { get; set; }
        public List<SelectListItem> SgkKayitYeriList { get; set; }
    }
}