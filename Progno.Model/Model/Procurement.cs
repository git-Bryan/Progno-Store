using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
   public class Procurement
    {
        public long Id { get; set; }
        public Staff Staff { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? Oustanding { get; set; }
        public System.DateTime TransactionDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string ReceiptNumber { get; set; }
        public bool? Cleared { get; set; }
        public Supplier Supplier { get; set; }
    }
}
