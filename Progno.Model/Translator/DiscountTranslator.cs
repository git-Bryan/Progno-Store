using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
    public class DiscountTranslator: BaseTranslator<Discount, DISCOUNT>
    {
        public override Discount TranslateToModel(DISCOUNT entity)
        {
            try
            {
                Discount model = null;
                if (entity!= null)
                {
                  model = new Discount();
                    model.Id = entity.Discount_Id;
                    model.Name = entity.Discount_Name;
                    model.Description = entity.Description;
                    model.PercentageOff = entity.Percentage_Off;
                }
                return model;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override DISCOUNT TranslateToEntity(Discount model)
        {
            try
            {
                DISCOUNT entity = null;
                if (model != null)
                {
                  entity = new DISCOUNT();
                    entity.Discount_Id = model.Id;
                    entity.Discount_Name = model.Name;
                    entity.Description = model.Description;
                    entity.Percentage_Off = model.PercentageOff;
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
