using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
  public  class StockList
    {
        public int QuantityLeft { get; set; }
        public System.DateTime LastUpdateTime { get; set; }
        public int StockId { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string BarcodeNo { get; set; }
        public long ProductId { get; set; }
    }
}
