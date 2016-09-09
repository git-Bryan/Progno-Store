using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
    public class StockCatalog
    {
        public int Id { get; set; }
        public Staff Staff { get; set; }
        public System.DateTime Date { get; set; }
        public string ReceiptNumber { get; set; }

        public Supplier Supplier { get; set; }
        public Batch Batch { get; set; }
        public Product Product { get; set; }
    }
}
