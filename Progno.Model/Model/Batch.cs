using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
    public class Batch
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public PriceList PriceList { get; set; }
        public int Qty { get; set; }
    }
}
