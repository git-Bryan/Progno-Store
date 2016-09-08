using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
  public  class SalaryScheme
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal? Tax { get; set; }
    
    }
}
