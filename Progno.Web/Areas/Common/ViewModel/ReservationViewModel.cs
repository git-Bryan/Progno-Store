using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Progno.Model.Model;
using Progno.Web.Models;

namespace Progno.Web.Areas.Common.ViewModel
{
    public class ReservationViewModel
    {
        public ReservationViewModel()
        {
            ReservationTypeSelectList = Utility.PopulateReservationTypeSelectListItem();
        }

        public List<SelectListItem> ReservationTypeSelectList { get; set; }
        public Reservation Reservation { get; set; }
        public User User { get; set; }
        public Customer Customer { get; set; }
        public ReservationType ReservationType { get; set; }
    }
}