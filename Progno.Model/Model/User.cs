using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
   public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }

       public Role Role { get; set; }
       public Person Person { get; set; }

        public DateTime? LastLogin { get; set; }
    }
}
