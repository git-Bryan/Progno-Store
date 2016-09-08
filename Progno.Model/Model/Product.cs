using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
   public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public int ReOrderQty { get; set; }
        public ProductCategory Category { get; set; }
        public string BarCode { get; set; }
        public bool Active { get; set; }
    }
}
