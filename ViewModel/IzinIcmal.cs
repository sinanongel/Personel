using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personel.ViewModel
{
    public class IzinIcmal
    {
        public string PersonelAdi { get; set; }
        public DateTime İseGirisTarihi { get; set; }
        public int TahEdenToplam { get; set; }
        public int KulToplam { get; set; }
        public int KalanYIzin { get; set; }
    }
}