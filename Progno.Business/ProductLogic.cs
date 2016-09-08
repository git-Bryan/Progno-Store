using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;
using Progno.Model.Translator;

namespace Progno.Business
{
  public  class ProductLogic : BusinessBaseLogic<Product, PRODUCT>
    {
        public ProductLogic()
        {
            translator = new ProductTranslator();
        }

      public bool ModifyProduct(Product product)
      {
          try
          {
              PRODUCT entity = GetEntityBy(x => x.Product_Id == product.Id);
              if (entity == null || entity.Product_Id <= 0)
              {
                  throw new Exception(NoItemFound);
              }
              if (entity != null)
              {
                  if (product.Name!= null)
                  {
                      entity.Product_Name = product.Name;
                  }
                  if (product.Description != null)
                  {
                      entity.Description= product.Description;
                  }
                  //if (product.Brand != null)
                  //{
                  //    entity.Brand = product.Brand;
                  //}
                  //if (product.PhotoUrl != null)
                  //{
                  //    entity.Photo_Url = product.PhotoUrl;
                  //}
                  //if (product.CostPrice != null)
                  //{
                  //    entity.Cost_Price = product.CostPrice;
                  //}
                  //if (product.SellingPrice != null)
                  //{
                  //    entity.Selling_Price = product.SellingPrice;
                  }
                  if (product.ReOrderQty != null)
                  {
                      entity.Re_Order_Qty = product.ReOrderQty;
                  }
                  //if (product.ProductCategory != null)
                  //{
                  //    entity.PRODUCT_CATEGORY.Category_Id = product.ProductCategory.Id;
                  //}
                
                int modifiedRecordCount = Save();
                  if (modifiedRecordCount <= 0)
                  {
                      throw new Exception(NoItemModified);
                  }
                  return true;
              }
              //return false;
              //}
          catch (Exception)
          {
              
              throw;
          }
         
      }
    }
}
