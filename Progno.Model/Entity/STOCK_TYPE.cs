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
    
    public partial class STOCK_TYPE
    {
        public STOCK_TYPE()
        {
            this.CATALOG = new HashSet<CATALOG>();
        }
    
        public int Stock_Type_Id { get; set; }
        public string Stock_Type_Name { get; set; }
    
        public virtual ICollection<CATALOG> CATALOG { get; set; }
    }
}
