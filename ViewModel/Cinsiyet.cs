using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personel.ViewModel
{
    public class Cinsiyet
    {
        public Cins CinsiyetListe { get; set; }
    }
    public enum Cins
    {
        Kadın,
        Erkek
    }
}