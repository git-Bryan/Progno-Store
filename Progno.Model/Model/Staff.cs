using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
   public class Staff
    {
        public long Id { get; set; }
        public User User { get; set; }
        public string AccountNumber { get; set; }
        public Person Person { get; set; }
        public decimal? Salary { get; set; }
    }
}
