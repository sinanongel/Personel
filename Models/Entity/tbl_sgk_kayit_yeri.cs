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
    
    public partial class tbl_sgk_kayit_yeri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_sgk_kayit_yeri()
        {
            this.tbl_sgk_kayit_hareketleri = new HashSet<tbl_sgk_kayit_hareketleri>();
        }
    
        public int sgk_kayit_yeri_id { get; set; }
        public string sgk_kayit_yeri_adi { get; set; }
        public int firma_id { get; set; }
    
        public virtual tbl_firmalar tbl_firmalar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_sgk_kayit_hareketleri> tbl_sgk_kayit_hareketleri { get; set; }
    }
}
