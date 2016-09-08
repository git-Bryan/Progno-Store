using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
   public class ReservationTypeTranslator: BaseTranslator<ReservationType, RESERVATION_TYPE>
   {
       public override ReservationType TranslateToModel(RESERVATION_TYPE entity)
       {
           try
           {
               ReservationType model = null;
               if (entity != null)
               {
                   model = new ReservationType();
                   model.Id = entity.Reservation_Type_Id;
                   model.Name = entity.Reservation_Type_Name;
                   model.Description = entity.Description;
                   model.Amount = entity.Amount;
               }
               return model;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public override RESERVATION_TYPE TranslateToEntity(ReservationType model)
       {
           try
           {
               RESERVATION_TYPE entity = null;
               if (model != null)
               {
                   entity = new RESERVATION_TYPE();
                   entity.Reservation_Type_Id = model.Id;
                   entity.Reservation_Type_Name = model.Name;
                   entity.Description = model.Description;
                   entity.Amount = model.Amount;
               }
               return entity;
           }
           catch (Exception)
           {
               
               throw;
           }
       }
   }
}
