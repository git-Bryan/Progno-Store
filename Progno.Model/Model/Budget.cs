using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
    public class Budget
    {
        public int Id { get; set; }
        public int BudgetNo { get; set; }
        public string BudgetItem { get; set; }
        public bool Signed { get; set; }
        public System.DateTime Date { get; set; }
        public bool Delivered { get; set; }
    }
}
