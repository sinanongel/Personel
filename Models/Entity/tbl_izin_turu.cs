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
    
    public partial class tbl_izin_turu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_izin_turu()
        {
            this.tbl_izinler = new HashSet<tbl_izinler>();
        }
    
        public int izin_tur_id { get; set; }
        public string izin_tur_adi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_izinler> tbl_izinler { get; set; }
    }
}
