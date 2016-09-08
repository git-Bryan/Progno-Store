using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
   public class SalesTypeTranslator: BaseTranslator<SalesType, SALES_TYPE>
    {
        public override SalesType TranslateToModel(SALES_TYPE entity)
        {
            try
            {
                SalesType model = null;
                if (entity != null)
                {
                    model = new SalesType();
                    model.Id = entity.Sales_Type_Id;
                    model.Name = entity.Sales_Type_Name;
                    model.Description = entity.Description;
                }
                return model;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override SALES_TYPE TranslateToEntity(SalesType model)
        {
            try
            {
                SALES_TYPE entity = null;
                if (model!= null)
                {
                   entity = new SALES_TYPE();
                    entity.Sales_Type_Id = model.Id;
                    entity.Sales_Type_Name = model.Name;
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
