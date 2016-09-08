using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
    public class BarProductTranslator :BaseTranslator<BarProduct, BAR_PRODUCT>
    {
        private ProductTranslator productTranslator;
        private BatchTranslator batchTranslator;
        private BarTranslator barTranslator;

        public BarProductTranslator()
        {
            productTranslator = new ProductTranslator();
            batchTranslator = new BatchTranslator();
            barTranslator = new BarTranslator();
        }
        public override BarProduct TranslateToModel(BAR_PRODUCT entity)
        {
            try
            {
                BarProduct model = null;
                if (entity != null)
                {
                    model = new BarProduct();
                    model.Id = entity.Bar_Product_Id;
                    model.Product = productTranslator.Translate(entity.PRODUCT);
                    model.Qty = entity.Qty;
                    model.Active = entity.Active;
                    model.Batch = batchTranslator.Translate(entity.BATCH);
                    model.Bar = barTranslator.Translate(entity.BAR);
                }
                return model;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override BAR_PRODUCT TranslateToEntity(BarProduct model)
        {
            try
            {
                BAR_PRODUCT entity = null;
                if (model != null)
                {
                    entity = new BAR_PRODUCT();
                    entity.Bar_Product_Id = model.Id;
                    entity.Product_Id = model.Product.Id;
                    entity.Qty = model.Qty;
                    entity.Active = model.Active;
                    entity.Batch_Id = model.Batch.Id;
                    entity.Bar_Id = model.Bar.Id;
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
