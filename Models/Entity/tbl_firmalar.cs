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
    
    public partial class tbl_firmalar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_firmalar()
        {
            this.tbl_bolgeler = new HashSet<tbl_bolgeler>();
            this.tbl_calisma_yeri = new HashSet<tbl_calisma_yeri>();
            this.tbl_degerlendirme = new HashSet<tbl_degerlendirme>();
            this.tbl_gorevler = new HashSet<tbl_gorevler>();
            this.tbl_sgk_kayit_yeri = new HashSet<tbl_sgk_kayit_yeri>();
            this.tbl_personel = new HashSet<tbl_personel>();
            this.tbl_kullanici = new HashSet<tbl_kullanici>();
        }
    
        public int firma_id { get; set; }
        public string firma_unvani { get; set; }
        public string firma_adi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_bolgeler> tbl_bolgeler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_calisma_yeri> tbl_calisma_yeri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_degerlendirme> tbl_degerlendirme { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_gorevler> tbl_gorevler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_sgk_kayit_yeri> tbl_sgk_kayit_yeri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_personel> tbl_personel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_kullanici> tbl_kullanici { get; set; }
    }
}
