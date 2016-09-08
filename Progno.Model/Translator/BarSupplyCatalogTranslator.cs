using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
    public class BarSupplyCatalogTranslator : BaseTranslator<BarSupplyCatalog, BAR_SUPPLY_CATALOG>
    {
        private StaffTranslator staffTranslator;
        private BatchTranslator batchTranslator;
        private ProductTranslator productTranslator;

        public BarSupplyCatalogTranslator()
        {
            staffTranslator = new StaffTranslator();
            productTranslator = new ProductTranslator();
            batchTranslator = new BatchTranslator();
        }

        public override BarSupplyCatalog TranslateToModel(BAR_SUPPLY_CATALOG entity)
        {

            try
            {
                BarSupplyCatalog model = null;
                if (entity != null)
                {
                    model = new BarSupplyCatalog();
                    model.Id = entity.Bar_Supply_Catalog_Id;
                    model.StoreStaff = staffTranslator.Translate(entity.STAFF);
                    model.BarStaff = staffTranslator.Translate(entity.STAFF1);
                    model.Product = productTranslator.Translate(entity.PRODUCT);
                    model.Batch = batchTranslator.Translate(entity.BATCH);
                    model.Qty = entity.Qty;
                }
                return model;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override BAR_SUPPLY_CATALOG TranslateToEntity(BarSupplyCatalog model)
        {
            try
            {
                BAR_SUPPLY_CATALOG entity = null;
                if (model != null)
                {
                    entity = new BAR_SUPPLY_CATALOG();
                    entity.Bar_Supply_Catalog_Id = model.Id;
                    entity.Store_Staff_Id = model.StoreStaff.Id;
                    entity.Bar_Staff_Id = model.BarStaff.Id;
                    entity.Product_Id = model.Product.Id;
                    entity.Batch_Id = model.Batch.Id;
                    entity.Qty = model.Qty;
                }
                return  entity;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
