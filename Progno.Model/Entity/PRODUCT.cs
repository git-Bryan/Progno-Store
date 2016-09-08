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
    
    public partial class PRODUCT
    {
        public PRODUCT()
        {
            this.CATALOG = new HashSet<CATALOG>();
            this.ORDER = new HashSet<ORDER>();
            this.PRODUCT_UNIT = new HashSet<PRODUCT_UNIT>();
            this.STOCK = new HashSet<STOCK>();
        }
    
        public long Product_Id { get; set; }
        public string Product_Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Photo_Url { get; set; }
        public decimal Cost_Price { get; set; }
        public int Re_Order_Qty { get; set; }
        public int Category_Id { get; set; }
        public decimal Selling_Price { get; set; }
        public string Barcode_No { get; set; }
        public Nullable<decimal> Happy_Hour_Price { get; set; }
    
        public virtual ICollection<CATALOG> CATALOG { get; set; }
        public virtual ICollection<ORDER> ORDER { get; set; }
        public virtual PRODUCT_CATEGORY PRODUCT_CATEGORY { get; set; }
        public virtual ICollection<PRODUCT_UNIT> PRODUCT_UNIT { get; set; }
        public virtual ICollection<STOCK> STOCK { get; set; }
    }
}