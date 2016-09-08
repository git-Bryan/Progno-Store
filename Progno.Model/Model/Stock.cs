using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
   public class Stock
    {
        public int Id { get; set; }
        public Batch Batch { get; set; }
        public bool Exhausted { get; set; }
        public bool Active { get; set; }
        public Product Product { get; set; }
    }
}
