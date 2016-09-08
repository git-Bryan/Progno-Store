using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
    public class ReservationType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Amount { get; set; }
    }
}
