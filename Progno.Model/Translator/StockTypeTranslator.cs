using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
  public  class StockTypeTranslator : BaseTranslator<StockType, STOCK_TYPE>
    {
        public override StockType TranslateToModel(STOCK_TYPE entity)
        {
            try
            {
                StockType model = null;
                if (entity != null)
                {
                    model = new StockType();
                    model.Id = entity.Stock_Type_Id;
                    model.Name = entity.Stock_Type_Name;

                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override STOCK_TYPE TranslateToEntity(StockType model)
        {
            try
            {
                STOCK_TYPE entity = null;
                if (model != null)
                {
                    entity = new STOCK_TYPE();
                    entity.Stock_Type_Id = model.Id;
                    entity.Stock_Type_Name = model.Name;
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
