﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dataset1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MisevDB : DbContext
    {
        public MisevDB()
            : base("name=MisevDB")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Colors> Colors { get; set; }
        public virtual DbSet<Dolzhnocti> Dolzhnocti { get; set; }
        public virtual DbSet<Sotrudniki> Sotrudniki { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Colors_View> Colors_View { get; set; }
        public virtual DbSet<Dolzhnocti_View> Dolzhnocti_View { get; set; }
        public virtual DbSet<Sotrudniki_View> Sotrudniki_View { get; set; }
    }
}