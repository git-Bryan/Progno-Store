﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Progno.Model.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class INVENTORYEntities : DbContext
    {
        public INVENTORYEntities()
            : base("name=INVENTORYEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BLOOD_GROUP> BLOOD_GROUP { get; set; }
        public virtual DbSet<BRANCH> BRANCH { get; set; }
        public virtual DbSet<BUSINESS> BUSINESS { get; set; }
        public virtual DbSet<CATALOG> CATALOG { get; set; }
        public virtual DbSet<COUNTRY> COUNTRY { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMER { get; set; }
        public virtual DbSet<DISCOUNT> DISCOUNT { get; set; }
        public virtual DbSet<HAPPY_HOUR> HAPPY_HOUR { get; set; }
        public virtual DbSet<LOCAL_GOVERNMENT> LOCAL_GOVERNMENT { get; set; }
        public virtual DbSet<NATIONALITY> NATIONALITY { get; set; }
        public virtual DbSet<OCCUPATION> OCCUPATION { get; set; }
        public virtual DbSet<ORDER> ORDER { get; set; }
        public virtual DbSet<PAYMENT> PAYMENT { get; set; }
        public virtual DbSet<PAYMENT_TYPE> PAYMENT_TYPE { get; set; }
        public virtual DbSet<PERSON> PERSON { get; set; }
        public virtual DbSet<PRODUCT> PRODUCT { get; set; }
        public virtual DbSet<PRODUCT_CATEGORY> PRODUCT_CATEGORY { get; set; }
        public virtual DbSet<PRODUCT_UNIT> PRODUCT_UNIT { get; set; }
        public virtual DbSet<RELIGION> RELIGION { get; set; }
        public virtual DbSet<RESERVATION> RESERVATION { get; set; }
        public virtual DbSet<RESERVATION_TYPE> RESERVATION_TYPE { get; set; }
        public virtual DbSet<ROLE> ROLE { get; set; }
        public virtual DbSet<SALARY> SALARY { get; set; }
        public virtual DbSet<SALARY_SCHEME> SALARY_SCHEME { get; set; }
        public virtual DbSet<SALES> SALES { get; set; }
        public virtual DbSet<SALES_TYPE> SALES_TYPE { get; set; }
        public virtual DbSet<SEX> SEX { get; set; }
        public virtual DbSet<STAFF> STAFF { get; set; }
        public virtual DbSet<STATE> STATE { get; set; }
        public virtual DbSet<STOCK> STOCK { get; set; }
        public virtual DbSet<STOCK_TYPE> STOCK_TYPE { get; set; }
        public virtual DbSet<SUPPLIER> SUPPLIER { get; set; }
        public virtual DbSet<UNIT> UNIT { get; set; }
        public virtual DbSet<USER> USER { get; set; }
        public virtual DbSet<VW_ACTIVITY_LOG> VW_ACTIVITY_LOG { get; set; }
        public virtual DbSet<VW_PAYMENT> VW_PAYMENT { get; set; }
        public virtual DbSet<VW_SALES> VW_SALES { get; set; }
        public virtual DbSet<VW_STOCK> VW_STOCK { get; set; }
    }
}
