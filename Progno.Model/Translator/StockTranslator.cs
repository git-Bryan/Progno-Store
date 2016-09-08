using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
   public class StockTranslator : BaseTranslator<Stock, STOCK>
   {
       private ProductTranslator productTranslator;
       private BatchTranslator batchTranslator;

       public StockTranslator()
       {
           batchTranslator = new BatchTranslator();
           productTranslator = new ProductTranslator();
       }
       public override Stock TranslateToModel(STOCK entity)
       {
           try
           {
               Stock model = null;
               if (entity != null)
               {
                    model = new Stock();
                   model.Id = entity.Stock_Id;
                   model.Product = productTranslator.Translate(entity.PRODUCT);
                   model.Batch = batchTranslator.Translate(entity.BATCH);
                   model.Exhausted = entity.Exhausted;
                   model.Active = entity.Active;
               }
               return model;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public override STOCK TranslateToEntity(Stock model)
       {
           try
           {
               STOCK entity = null;
               if (model != null)
               {
                 entity = new STOCK();
                   entity.Stock_Id = model.Id;
                   entity.Product_Id = model.Product.Id;
                   entity.Batch_Id = model.Batch.Id;
                   entity.Exhausted = model.Exhausted;
                   entity.Active = model.Active;
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
