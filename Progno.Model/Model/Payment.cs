using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
   public class Payment
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Staff Staff { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountTendered { get; set; }

       public decimal? OutstandingAmount { get; set; }
        public string OrderNo { get; set; }
        public bool Paid { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public DateTime? ExpectedPaymentDate { get; set; }
    }
}
