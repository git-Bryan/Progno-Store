using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
    public class BatchTranslator : BaseTranslator<Batch, BATCH>
    {
        private PriceListTranslator priceListTranslator;

        public BatchTranslator()
        {
            priceListTranslator = new PriceListTranslator();
        }
        public override Batch TranslateToModel(BATCH entity)
        {
            try
            {
                Batch model = null;
                if (entity != null)
                {
                    model = new Batch();
                    model.Id = entity.Batch_Id;
                    model.Description = entity.Batch_Description;
                    model.PriceList = priceListTranslator.Translate(entity.PRICE_LIST);
                    model.Qty = entity.Qty;
                }
                return model;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override BATCH TranslateToEntity(Batch model)
        {
            try
            {
                BATCH entity = null;
                if (model != null)
                {
                    entity = new BATCH();
                    entity.Batch_Id = model.Id;
                    entity.Batch_Description = model.Description;
                    entity.Price_List_Id = model.PriceList.Id;
                    entity.Qty = model.Qty;
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
