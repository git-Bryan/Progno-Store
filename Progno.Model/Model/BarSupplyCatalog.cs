using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
    public class BarSupplyCatalog
    {
        public int Id { get; set; }
        public Staff StoreStaff { get; set; }
        public Staff BarStaff { get; set; }
        public Product Product { get; set; }
        public Batch Batch { get; set; }
        public int Qty { get; set; }
    }
}
