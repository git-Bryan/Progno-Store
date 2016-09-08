using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
   public class Order
    {
        public long Id { get; set; }
        public Product Product { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal GrossAmount { get; set; }

        public DateTime OrderTime { get; set; }
        public bool? Checked { get; set; }
        public string OrderNo { get; set; }
        public decimal? TotalAmount { get; set; }

        public string barcodeImageUrl { get; set; }



    }
}
