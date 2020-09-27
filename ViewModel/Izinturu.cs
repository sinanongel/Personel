using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personel.ViewModel
{
    public class Izinturu
    {
        public Tur IzinturListe { get; set; }
    }
    public enum Tur
    {
        Yillik,
        Mazeret
    }
}