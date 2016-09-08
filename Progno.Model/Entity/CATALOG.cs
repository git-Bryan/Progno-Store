//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class CATALOG
    {
        public int Catalog_Id { get; set; }
        public long Product_Id { get; set; }
        public System.DateTime Date_Of_Transaction { get; set; }
        public int Stock_Type_Id { get; set; }
        public int Quantity { get; set; }
        public long Staff_Id { get; set; }
        public Nullable<int> Supplier_Id { get; set; }
        public Nullable<int> Product_Unit_Id { get; set; }
    
        public virtual PRODUCT PRODUCT { get; set; }
        public virtual PRODUCT_UNIT PRODUCT_UNIT { get; set; }
        public virtual STAFF STAFF { get; set; }
        public virtual STOCK_TYPE STOCK_TYPE { get; set; }
        public virtual SUPPLIER SUPPLIER { get; set; }
    }
}
