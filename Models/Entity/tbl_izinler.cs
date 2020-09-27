//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Personel.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public partial class tbl_izinler
    {
        public int izin_id { get; set; }
        public int personel_id { get; set; }
        public System.DateTime izin_baslama_tarihi { get; set; }
        public System.DateTime izin_bitis_tarihi { get; set; }
        public Nullable<int> mazeret_id { get; set; }
        public Nullable<int> kullanilan_yillik_izin { get; set; }
        public Nullable<int> tahakkuk_eden_yillik_izin { get; set; }
        public Nullable<int> kalan_yillik_izin { get; set; }
        public Nullable<int> kullanilan_mazeret_izin { get; set; }
        public Nullable<int> calisilan_sure { get; set; }
        public int izin_tur_id { get; set; }
    
        public virtual tbl_izin_turu tbl_izin_turu { get; set; }
        public virtual tbl_mazeret_turu tbl_mazeret_turu { get; set; }
        public virtual tbl_personel tbl_personel { get; set; }

        public List<SelectListItem> IzinturList { get; set; }
    }
}
