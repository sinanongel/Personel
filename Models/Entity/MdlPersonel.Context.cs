﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_personelEntities : DbContext
    {
        public db_personelEntities()
            : base("name=db_personelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_bolgeler> tbl_bolgeler { get; set; }
        public virtual DbSet<tbl_calisma_yeri> tbl_calisma_yeri { get; set; }
        public virtual DbSet<tbl_degerlendirme> tbl_degerlendirme { get; set; }
        public virtual DbSet<tbl_firmalar> tbl_firmalar { get; set; }
        public virtual DbSet<tbl_gorevler> tbl_gorevler { get; set; }
        public virtual DbSet<tbl_izin_turu> tbl_izin_turu { get; set; }
        public virtual DbSet<tbl_izinler> tbl_izinler { get; set; }
        public virtual DbSet<tbl_kullanici> tbl_kullanici { get; set; }
        public virtual DbSet<tbl_mazeret_turu> tbl_mazeret_turu { get; set; }
        public virtual DbSet<tbl_ozluk_belgeler> tbl_ozluk_belgeler { get; set; }
        public virtual DbSet<tbl_personel> tbl_personel { get; set; }
        public virtual DbSet<tbl_personel_ozluk> tbl_personel_ozluk { get; set; }
        public virtual DbSet<tbl_resmi_tatil> tbl_resmi_tatil { get; set; }
        public virtual DbSet<tbl_sgk_kayit_hareketleri> tbl_sgk_kayit_hareketleri { get; set; }
        public virtual DbSet<tbl_sgk_kayit_yeri> tbl_sgk_kayit_yeri { get; set; }
    }
}
