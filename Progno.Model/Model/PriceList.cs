using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
    public class PriceList
    {
        public int Id { get; set; }
        public Bar Bar { get; set; }
        public decimal NormalPrice { get; set; }
        public decimal HappyHourPrice { get; set; }
        public decimal Cost { get; set; }
    }
}
