using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
    public class BranchTranslator: BaseTranslator<Branch, BRANCH>
    {
        private BusinessTranslator businessTranslator;

        public BranchTranslator()
        {
            businessTranslator = new BusinessTranslator();
        }
        public override Branch TranslateToModel(BRANCH entity)
        {
            try
            {
                Branch model = null;
                if (entity != null)
                {
                  model = new Branch();
                    model.Id = entity.Branch_Id;
                    model.Business = businessTranslator.Translate(entity.BUSINESS);
                    model.Name = entity.Name;
                    model.Location = entity.Location;
                    model.EmailAddress = entity.Email_address;
                    model.PhoneNumber = entity.Phone_number;
                    model.AlternativeEmail = entity.Alternative_Email;
                    model.AlternativePhone = entity.Alternative_Phone;

                }
                return model;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override BRANCH TranslateToEntity(Branch model)
        {
            try
            {
                BRANCH entity = null;
                if (model != null)
                {
                   entity = new BRANCH();
                    entity.Branch_Id = model.Id;
                    entity.Business_Id = model.Business.Id;
                    entity.Name = model.Name;
                    entity.Location = model.Location;
                    entity.Email_address = model.EmailAddress;
                    entity.Phone_number = model.PhoneNumber;
                    entity.Alternative_Email = model.AlternativeEmail;
                    entity.Alternative_Phone = model.AlternativePhone;
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
