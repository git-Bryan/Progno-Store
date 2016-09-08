using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
  public  class CatalogTranslator : BaseTranslator<Catalog, CATALOG>
  {
      private ProductTranslator productTranslator;
      private StockTypeTranslator stockTypeTranslator;
      private StaffTranslator staffTranslator;
      private SupplierTranslator supplierTranslator;
      private ProductUnitTranslator productUnitTranslator;
      public CatalogTranslator()
      {
       productTranslator = new ProductTranslator();
          stockTypeTranslator = new StockTypeTranslator();
          staffTranslator = new StaffTranslator();
          supplierTranslator = new SupplierTranslator();
          productUnitTranslator = new ProductUnitTranslator();
      }
      public override Catalog TranslateToModel(CATALOG entity)
      {
          try
          {
              Catalog model = null;
              if (entity!= null)
              {
                model = new Catalog();
                  model.Id = entity.Catalog_Id;
                  model.Product = productTranslator.Translate(entity.PRODUCT);
                  model.Quantity = entity.Quantity;
                  model.TransactionDate = entity.Date_Of_Transaction;
                  model.StockType = stockTypeTranslator.Translate(entity.STOCK_TYPE);
                  model.Staff = staffTranslator.Translate(entity.STAFF);
                  model.Supplier = supplierTranslator.Translate(entity.SUPPLIER);
                  model.ProductUnit = productUnitTranslator.Translate(entity.PRODUCT_UNIT);
              }
              return model;
          }
          catch (Exception)
          {
              
              throw;
          }
      }

      public override CATALOG TranslateToEntity(Catalog model)
      {
          try
          {
              CATALOG entity = null;
              if (model != null)
              {
                 entity = new CATALOG();
                  entity.Catalog_Id = model.Id;
                  entity.Product_Id = model.Product.Id;
                  entity.Quantity = model.Quantity;
                  entity.Date_Of_Transaction = model.TransactionDate;
                  entity.Stock_Type_Id = model.StockType.Id;
                  entity.Staff_Id = model.Staff.Id;
                  if (model.Supplier!= null)
                  {
                      entity.Supplier_Id = model.Supplier.Id;
                  }

                  if (model.ProductUnit != null)
                  {
                      entity.Product_Unit_Id = model.ProductUnit.Id;
                  }

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
