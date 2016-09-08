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
   public class CustomerLogic : BusinessBaseLogic<Customer, CUSTOMER>
   {
       public CustomerLogic()
       {
           translator = new CustomerTranslator();
       }

       public Customer Modify(Customer customer)
       {
           try
           {
               CUSTOMER entity = GetEntityBy(x => x.Person_Id == customer.Id);
               Customer model = new Customer();
               if (entity != null)
               {
                   if (customer.TimesVisited != null)
                   {
                       entity.Times_Visited = customer.TimesVisited;
                       }
                   if (customer.LastDateVisited != null)
                   {
                       entity.Last_Date_Visited = customer.LastDateVisited;
                   }
                    Save();
                   model = GetModelBy(x => x.Person_Id == customer.Id);
               }
               return model;
           }
           catch (Exception)
           {
               
               throw;
           }
       }
    }
}
