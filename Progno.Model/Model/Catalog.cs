using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
   public class Catalog
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public DateTime TransactionDate { get; set; }
        public StockType    StockType { get; set; }
       public Staff Staff { get; set; }
        public int Quantity { get; set; }
        public Supplier Supplier { get; set; }
        public ProductUnit ProductUnit { get; set; }
    }
}
