using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progno.Model.Model
{
  public  class Reservation
    {
        public int Id { get; set; }
        public ReservationType ReservationType  { get; set; }
        public Customer Customer { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool IsCheckedOut { get; set; }
      public string AdditionalInformation { get; set; }
       public string ReservationCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
      public string Emailaddress { get; set; }

    }
}
