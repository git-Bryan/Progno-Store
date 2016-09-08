using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
   public class Sales
    {
        public long Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public SalesType SalesType { get; set; }
        public Staff Staff { get; set; }
        public Order Order { get; set; }
    }
}
