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
    
    public partial class tbl_gorevler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_gorevler()
        {
            this.tbl_degerlendirme = new HashSet<tbl_degerlendirme>();
        }
    
        public int gorev_id { get; set; }
        public string gorev_adi { get; set; }
        public int bolge_id { get; set; }
        public int firma_id { get; set; }
    
        public virtual tbl_bolgeler tbl_bolgeler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_degerlendirme> tbl_degerlendirme { get; set; }
        public virtual tbl_firmalar tbl_firmalar { get; set; }
    }
}
