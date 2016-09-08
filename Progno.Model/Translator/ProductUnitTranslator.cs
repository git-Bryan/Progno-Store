using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
    public class ProductUnitTranslator: BaseTranslator<ProductUnit, PRODUCT_UNIT>
    {
        private UnitTranslator unitTranslator;
        private ProductTranslator productTranslator;

        public ProductUnitTranslator()
        {
            unitTranslator = new UnitTranslator();
            productTranslator= new ProductTranslator();
        }
        public override ProductUnit TranslateToModel(PRODUCT_UNIT entity)
        {
            try
            {
                ProductUnit model = null;
                if (entity != null)
                {
                   model = new ProductUnit();
                    model.Id = entity.Product_Unit_Id;
                    model.Product = productTranslator.Translate(entity.PRODUCT);
                    model.Items = entity.Items;
                    model.Unit = unitTranslator.Translate(entity.UNIT);
                }
                return model;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override PRODUCT_UNIT TranslateToEntity(ProductUnit model)
        {
            try
            {
                PRODUCT_UNIT entity = null;
                if (model != null)
                {
                   entity = new PRODUCT_UNIT();
                    entity.Product_Unit_Id = model.Id;
                    entity.Product_Id = model.Product.Id;
                    entity.Items = model.Items;
                    entity.Unit_Id = model.Unit.Id;
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
