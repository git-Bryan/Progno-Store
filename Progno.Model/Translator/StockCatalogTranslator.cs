using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
    public class StockCatalogTranslator: BaseTranslator<StockCatalog,STOCK_CATALOG>
    {
        private SupplierTranslator supplierTranslator;
        private BatchTranslator batchTranslator;
        private StaffTranslator staffTranslator;
        private ProductTranslator productTranslator;

        public StockCatalogTranslator()
        {
            supplierTranslator = new SupplierTranslator();
            batchTranslator = new BatchTranslator();
            staffTranslator = new StaffTranslator();
            productTranslator = new ProductTranslator();
        }
 public override StockCatalog TranslateToModel(STOCK_CATALOG entity)
        {
            try
            {
                StockCatalog model = null;
                if (entity != null)
                {
                    model = new StockCatalog();
                    model.Id = entity.Stock_Catlog_Id;
                    model.Staff = staffTranslator.Translate(entity.STAFF);
                    model.Date = entity.Date;
                    model.ReceiptNumber = entity.Receipt_number;
                    model.Supplier = supplierTranslator.Translate(entity.SUPPLIER);
                    model.Batch = batchTranslator.Translate(entity.BATCH);
                    model.Product = productTranslator.Translate(entity.PRODUCT);
                }
                return model;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override STOCK_CATALOG TranslateToEntity(StockCatalog model)
        {
            try
            {
                STOCK_CATALOG entity = null;
                if (model != null)
                {
                    entity = new STOCK_CATALOG();
                    entity.Stock_Catlog_Id = model.Id;
                    entity.Staff_Id = model.Staff.Id;
                    entity.Date = model.Date;
                    entity.Receipt_number = model.ReceiptNumber;
                    entity.Supplier_Id = model.Supplier.Id;
                    entity.Batch_Id = model.Batch.Id;
                    entity.Product_Id = model.Product.Id;
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

