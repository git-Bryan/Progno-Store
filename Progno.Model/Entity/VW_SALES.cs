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
    
    public partial class VW_SALES
    {
        public System.DateTime Date_Of_Transaction { get; set; }
        public int Sales_Type_Id { get; set; }
        public long Staff_Id { get; set; }
        public long Order_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public decimal Amount { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> Total_Amount { get; set; }
        public Nullable<bool> Checked_Out { get; set; }
        public string Product_Name { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Happy_Hour_Price { get; set; }
    }
}