using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
   public class ReservationTranslator: BaseTranslator<Reservation,RESERVATION>
   {
       private ReservationTypeTranslator reservationTypeTranslator;
       private CustomerTranslator customerTranslator;

       public ReservationTranslator()
       {
           reservationTypeTranslator = new ReservationTypeTranslator();
           ;customerTranslator = new CustomerTranslator();
       }
       public override Reservation TranslateToModel(RESERVATION entity)
       {
           try
           {
               Reservation model = null;
               if (entity != null)
               {
                model = new Reservation();
                   model.Id = entity.Reservation_Id;
                   model.ReservationType = reservationTypeTranslator.Translate(entity.RESERVATION_TYPE);
                   model.Customer = customerTranslator.Translate(entity.CUSTOMER);
                   model.FirstName = entity.First_Name;
                   model.LastName = entity.Last_Name;
                   model.Emailaddress = entity.Email_address;
                   model.ReservationCode = entity.Reservation_Code;
                   model.CheckIn = entity.Check_In;
                   model.CheckOut = entity.Check_Out;
                   model.IsCheckedOut = entity.Is_Checked_Out;
                   model.AdditionalInformation = entity.Additional_Information;
               }
               return model;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public override RESERVATION TranslateToEntity(Reservation model)
       {
           try
           {
               RESERVATION entity = null;
               if (model!= null)
               {
                   entity = new RESERVATION();
                   entity.Reservation_Id = model.Id;
                   entity.Reservation_Type_Id = model.ReservationType.Id;
                   if (model.Customer!= null)
                   {
                       entity.Customer_Id = model.Customer.Id;
  
                   }
                   entity.First_Name = model.FirstName;
                   entity.Last_Name = model.LastName;
                   entity.Reservation_Code = model.ReservationCode;
                   entity.Email_address = model.Emailaddress;
                   entity.Check_In = model.CheckIn;
                   entity.Check_Out = model.CheckOut;
                   entity.Is_Checked_Out = model.IsCheckedOut;
                   if (model.AdditionalInformation!= null)
                   {
                       entity.Additional_Information = model.AdditionalInformation;
   
                   }

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
