using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
   public class StaffTranslator: BaseTranslator<Staff, STAFF>
   {
       private UserTranslator userTranslator;
       private PersonTranslator personTranslator;

       public StaffTranslator()
       {
           userTranslator = new UserTranslator();
           personTranslator = new PersonTranslator();
       }
        public override Staff TranslateToModel(STAFF entity)
        {
            try
            {
                Staff model = null;
                if (entity != null)
                {
                 model = new Staff();
                    model.Id = entity.Staff_Id;
                    model.AccountNumber = entity.Account_Number;
                    model.Salary = entity.Salary;
                    model.User = userTranslator.Translate(entity.USER);
                    model.Person = personTranslator.Translate(entity.PERSON);
                }
                return model;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override STAFF TranslateToEntity(Staff model)
        {
            try
            {
                STAFF entity = null;
                if (model != null)
                {
                    entity = new STAFF();
                    entity.Staff_Id = model.Id;
                    entity.User_Id = model.User.Id;
                    entity.Account_Number = model.AccountNumber;
                    entity.Person_Id = model.Person.Id;
                    entity.Salary = model.Salary;
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
