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
    
    public partial class SUPPLIER
    {
        public SUPPLIER()
        {
            this.CATALOG = new HashSet<CATALOG>();
        }
    
        public int Supplier_Id { get; set; }
        public string Supplier_Name { get; set; }
        public string Company_Name { get; set; }
        public string Additional_Information { get; set; }
    
        public virtual ICollection<CATALOG> CATALOG { get; set; }
    }
}