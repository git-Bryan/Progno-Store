using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
    public class ActivityLog
    {
        public string StockTypeName { get; set; }
        public int StockTypeId { get; set; }
        public long StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public System.DateTime DateOfTransaction { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }

        public string SupplierName { get; set; }
        public string Company { get; set; } 

    }
}
