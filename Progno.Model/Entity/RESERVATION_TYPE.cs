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
    
    public partial class RESERVATION_TYPE
    {
        public RESERVATION_TYPE()
        {
            this.RESERVATION = new HashSet<RESERVATION>();
        }
    
        public int Reservation_Type_Id { get; set; }
        public string Reservation_Type_Name { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<RESERVATION> RESERVATION { get; set; }
    }
}
