using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
    public class BarProduct
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Qty { get; set; }
        public bool Active { get; set; }
        public Batch Batch { get; set; }
        public Bar Bar { get; set; }
    }
}
