using Personel.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personel.ViewModel
{
    public class IzinListe
    {
        public string PersonelAdi { get; set; }
        public string FirmaAdi { get; set; }
        public DateTime İseGirisTarihi { get; set; }
        public int TahEdenToplam { get; set; }
        public int KulToplam { get; set; }
        public int KalanYIzin { get; set; }

        public tbl_personel personeldetay { get; set; }
        public tbl_izinler izinDetay { get; set; }
        public tbl_mazeret_turu mazeretDetay { get; set; }
        public tbl_izin_turu izinTurDetay { get; set; }
        public tbl_firmalar firmaDetay { get; set; }
    }
}