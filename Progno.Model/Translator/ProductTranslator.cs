using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
  public  class ProductTranslator : BaseTranslator<Product, PRODUCT>
  {
      private ProductCategoryTranslator productCategoryTranslator;
      private UnitTranslator unitTranslator;
      public ProductTranslator()
      {
         productCategoryTranslator = new ProductCategoryTranslator();
          unitTranslator = new UnitTranslator();
      }
      public override Product TranslateToModel(PRODUCT entity)
      {
          try
          {
              Product model = null;
              if (entity != null)
              {
                  model = new Product();
                  model.Id = entity.Product_Id;
                  model.Name = entity.Product_Name;
                  model.Description = entity.Description;
                  model.PhotoUrl = entity.Photo_Url;
                  model.ReOrderQty = entity.Re_Order_Qty;
                  model.BarCode = entity.Barcode_No;
                  model.Category = productCategoryTranslator.Translate(entity.PRODUCT_CATEGORY);
                  model.Active = entity.Active;

              }

              return model;
          }
          catch (Exception)
          {
              throw;
          }
      }

      public override PRODUCT TranslateToEntity(Product model)
      {
 try
            {
                PRODUCT entity = null;
                if (model != null)
                {
                    entity = new PRODUCT();
                    entity.Product_Id = model.Id;
                    entity.Product_Name = model.Name;
                    entity.Description = model.Description;
                    entity.Photo_Url = model.PhotoUrl;
                    entity.Re_Order_Qty = model.ReOrderQty;
                    entity.Category_Id = model.Category.Id;
                    entity.Barcode_No = model.BarCode;
                    entity.Active = model.Active;
                }

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }      }
  }

