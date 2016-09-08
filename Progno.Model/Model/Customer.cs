using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
   public class Customer:Person
    {
       public Person Person { get; set; }
       public string CustomerId { get; set; }

       public int TimesVisited { get; set; }
        public System.DateTime LastDateVisited { get; set; }
        public bool Active { get; set; }
        public decimal? MaximumCredit { get; set; }
    
    }
}
