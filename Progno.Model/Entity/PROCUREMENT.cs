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
    
    public partial class PROCUREMENT
    {
        public long Id { get; set; }
        public long Staff_Id { get; set; }
        public Nullable<decimal> Amount_Paid { get; set; }
        public Nullable<decimal> Oustanding { get; set; }
        public System.DateTime Transaction_Date { get; set; }
        public Nullable<System.DateTime> Last_Update_Date { get; set; }
        public string Receipt_Number { get; set; }
        public Nullable<bool> Cleared { get; set; }
        public int Supplier_Id { get; set; }
    
        public virtual STAFF STAFF { get; set; }
        public virtual SUPPLIER SUPPLIER { get; set; }
    }
}
