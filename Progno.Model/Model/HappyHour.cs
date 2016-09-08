using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
   public class HappyHour
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public Staff Staff { get; set; }
        public bool Activated { get; set; }
    }
}
