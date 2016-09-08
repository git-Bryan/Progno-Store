using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;
using Progno.Model.Translator;

namespace Progno.Business
{
   public class ReservationLogic: BusinessBaseLogic<Reservation,RESERVATION>
   {
       public ReservationLogic()
       {
           translator = new ReservationTranslator();
       }

       public bool Modify(Reservation model)
       {
           try
           {
               RESERVATION entity = GetEntityBy(x => x.Reservation_Id == model.Id);
               if (entity != null)
               {
                   entity.Is_Checked_Out = model.IsCheckedOut;
                   Save();
                   return true;
               }
               return false;
           }
           catch (Exception)
           {
               
               throw;
           }
       }
    }
}
