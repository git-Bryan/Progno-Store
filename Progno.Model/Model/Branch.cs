using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
   public class Branch
    {
        public int Id { get; set; }
        public Business Business { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternativePhone { get; set; }
        public string AlternativeEmail { get; set; }
    }
}
