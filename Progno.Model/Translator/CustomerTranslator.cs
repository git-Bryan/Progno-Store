using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
   public class CustomerTranslator: BaseTranslator<Customer,CUSTOMER>
   {
       private PersonTranslator personTranslator;

       public CustomerTranslator()
       {
           personTranslator = new PersonTranslator();
       }
       public override Customer TranslateToModel(CUSTOMER entity)
       {
           try
           {
               Customer model = null;
               if (entity!= null)
               {
                  model = new Customer();
                   model.Person = personTranslator.Translate(entity.PERSON);
                   model.CustomerId = entity.Customer_Id;
                   model.TimesVisited = entity.Times_Visited;
                   model.LastDateVisited = entity.Last_Date_Visited;
               }
               return model;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public override CUSTOMER TranslateToEntity(Customer model)
       {
           try
           {
               CUSTOMER entity = null;
               if (model != null)
               {
                 entity = new CUSTOMER();
                   entity.Person_Id = model.Id;
                   entity.Customer_Id = model.CustomerId;
                   entity.Times_Visited = model.TimesVisited;
                   entity.Last_Date_Visited = model.LastDateVisited;
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
