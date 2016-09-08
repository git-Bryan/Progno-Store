using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
  public  class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PercentageOff { get; set; }
        public string Description { get; set; }
    }
}
