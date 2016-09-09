using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
   public class SupplierTranslator: BaseTranslator<Supplier,SUPPLIER>
    {
        public override Supplier TranslateToModel(SUPPLIER entity)
        {
            try
            {
                Supplier model = null;
                if (entity!= null)
                {
                    model = new Supplier();
                    model.Id = entity.Id;
                    model.Name = entity.Supplier_Name;
                    model.CompanyName = entity.Company_Name;
                    model.AdditionalInformation = entity.Additional_Information;
                }
                return model;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override SUPPLIER TranslateToEntity(Supplier model)
        {
            try
            {
                SUPPLIER entity = null;
                if (model != null)
                {
                  entity = new SUPPLIER();
                    entity.Id = model.Id;
                    entity.Supplier_Name = model.Name;
                    entity.Company_Name = model.CompanyName;
                    entity.Additional_Information = model.AdditionalInformation;
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
