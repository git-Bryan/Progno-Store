using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
  public  class Salary
    {
        public long Id { get; set; }
        public decimal? CreditBalance { get; set; }
        public decimal? UnauthorisedCredit { get; set; }
        public decimal? StaffCredit { get; set; }
        public decimal? Surcharge { get; set; }
        public int? Attendance { get; set; }
        public decimal? Deduction { get; set; }
        public Staff Staff { get; set; }
        public string Month { get; set; }
        public System.DateTime Date { get; set; }
        public decimal? Bonus { get; set; }
        public decimal? FinalBalance { get; set; }
        public decimal SalaryScheme { get; set; }
    
    }
}
