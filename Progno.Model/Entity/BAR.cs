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
    
    public partial class BAR
    {
        public BAR()
        {
            this.BAR_PRODUCT = new HashSet<BAR_PRODUCT>();
            this.PRICE_LIST = new HashSet<PRICE_LIST>();
        }
    
        public int Bar_Id { get; set; }
        public string Bar_name { get; set; }
        public bool Active { get; set; }
    
        public virtual ICollection<BAR_PRODUCT> BAR_PRODUCT { get; set; }
        public virtual ICollection<PRICE_LIST> PRICE_LIST { get; set; }
    }
}
