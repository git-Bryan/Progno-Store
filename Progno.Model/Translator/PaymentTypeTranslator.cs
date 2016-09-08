using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
   public class PaymentTypeTranslator: BaseTranslator<PaymentType, PAYMENT_TYPE>
   {
       public override PaymentType TranslateToModel(PAYMENT_TYPE entity)
       {
           try
           {
               PaymentType model = null;
               if (entity!= null)
               {
                 model = new PaymentType();
                   model.Id = entity.Payment_Type_Id;
                   model.Name = entity.Payment_Type_Name;
                   model.Description = entity.Description;
               }
               return model;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public override PAYMENT_TYPE TranslateToEntity(PaymentType model)
       {
           try
           {
               PAYMENT_TYPE entity = null;
               if (model!= null)
               {
                entity = new PAYMENT_TYPE();
                   entity.Payment_Type_Id = model.Id;
                   entity.Payment_Type_Name = model.Name;
                   entity.Description = model.Description;
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
