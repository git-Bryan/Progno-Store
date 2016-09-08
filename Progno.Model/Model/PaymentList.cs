using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
   public class PaymentList
    {
        public int PaymentId { get; set; }
        public long UserId { get; set; }
        public int PaymentTypeid { get; set; }
        public string PaymentTypeName { get; set; }
        public decimal Amount { get; set; }
        public Nullable<decimal> OutstandingAmount { get; set; }
        public string OrderNo { get; set; }
        public bool Paid { get; set; }
        public System.DateTime LastUpdateTime { get; set; }
        public Nullable<System.DateTime> ExpectedPaymentDate { get; set; }
        public long CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string SalesFirstName { get; set; }
        public string SalesLastName { get; set; }
    }
}
