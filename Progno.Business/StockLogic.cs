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
  public  class StockLogic: BusinessBaseLogic<Stock, STOCK>
  {
      public StockLogic()
      {
          translator = new StockTranslator();
      }

      public bool Modify(Stock stock)
      {
          try
          {
              STOCK entity = GetEntityBy(x => x.Stock_Id == stock.Id && x.Product_Id == stock.Product.Id);
              if (entity!= null)
              {
                  entity.Stock_Id = stock.Id;
                  entity.Product_Id = stock.Product.Id;
                  //entity.Last_Update_Time = stock.LastUpdate;
                  //if (stock.QuantityLeft!= null)
                  //{
                  //    entity.Quantity_Left = stock.QuantityLeft;
                  //}
                  Save();
                  return true;
              }
              return false;
          }
          catch (Exception)
          {
              
              throw;
          }
      }
      public List<StockList> GetAllStock()
      {
          try
          {
              List<StockList> stockList = (from sr in repository.GetAll<VW_STOCK>()
                                           select new StockList
                                                {
                                                    StockId = sr.Stock_Id,
                                                    LastUpdateTime = sr.Last_Update_Time,
                                                    BarcodeNo = sr.Barcode_No,
                                                    SellingPrice = sr.Selling_Price,
                                                    CostPrice = sr.Cost_Price,
                                                    ProductId = sr.Product_Id,
                                                    ProductName = sr.Product_Name,
                                                    Brand = sr.Brand,
                                                    QuantityLeft = sr.Quantity_Left,
                                                }).ToList();

              return stockList;
          }
          catch (Exception)
          {

              throw;
          }
      } 

    }
}
