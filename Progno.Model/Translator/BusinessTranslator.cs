using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
   public class BusinessTranslator:BaseTranslator<Business, BUSINESS>
   {
       public override Business TranslateToModel(BUSINESS entity)
       {
           try
           {
               Business model = null;
               if (entity != null)
               {
                 model = new Business();
                   model.Id = entity.Business_Id;
                   model.Name = entity.Business_Name;
                   model.LogoUrl = entity.Logo_Url;
                    
               }
               return model;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public override BUSINESS TranslateToEntity(Business model)
       {
           try
           {
               BUSINESS entity = null;
               if (model != null)
               {
                 entity = new BUSINESS();
                   entity.Business_Id = model.Id;
                   entity.Business_Name = model.Name;
                   entity.Logo_Url = model.LogoUrl;
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
