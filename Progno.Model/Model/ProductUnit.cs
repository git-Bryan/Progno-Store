using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
   public class ProductUnit
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Items { get; set; }
        public Unit Unit { get; set; }
    }
}
