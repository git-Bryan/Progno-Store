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
    
    public partial class PAYMENT_TYPE
    {
        public PAYMENT_TYPE()
        {
            this.PAYMENT = new HashSet<PAYMENT>();
        }
    
        public int Payment_Type_Id { get; set; }
        public string Payment_Type_Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<PAYMENT> PAYMENT { get; set; }
    }
}
