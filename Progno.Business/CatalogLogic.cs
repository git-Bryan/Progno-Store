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
   public class CatalogLogic : BusinessBaseLogic<Catalog, CATALOG>
   {
       public CatalogLogic()
       {
           translator = new CatalogTranslator();
       }

       public List<ActivityLog> GetAllActivity()
       {
           try
           {
               List<ActivityLog> activityLogs = (from sr in repository.GetAll<VW_ACTIVITY_LOG>()
                                                 select new ActivityLog
                                                 {
                                                     StockTypeId = sr.Stock_Type_Id,
                                                     StockTypeName = sr.Stock_Type_Name,
                                                     Quantity = sr.Quantity,
                                                     StaffId = sr.Staff_Id,
                                                     FirstName = sr.First_Name,
                                                     LastName = sr.Last_Name,
                                                     ProductId = sr.Product_Id,
                                                     ProductName = sr.Product_Name,
                                                     
                                                     DateOfTransaction = sr.Date_Of_Transaction,
                                                    
                                                    }).ToList();

               return activityLogs;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       //public List<ActivityLog> GetActivityByType(StockType stockType)
       //{
       //    try
       //    {
       //        List<ActivityLog> activityLogs = (from sr in repository.GetBy<VW_ACTIVITY_LOG>(x=>x.Stock_Type_Id== stockType.Id)
       //                                          select new ActivityLog
       //                                          {
       //                                              StockTypeId = sr.Stock_Type_Id,
       //                                              StockTypeName = sr.Stock_Type_Name,
       //                                              Quantity = sr.Quantity,
       //                                              UserId = sr.User_Id,
       //                                              FirstName = sr.First_Name,
       //                                              LastName = sr.Last_Name,
       //                                              ProductId = sr.Product_Id,
       //                                              ProductName = sr.Product_Name,
       //                                              Brand = sr.Brand,
       //                                              CategoryId = sr.Category_Id,
       //                                              CategoryName = sr.Category_Name,
       //                                              DateOfTransaction = sr.Date_Of_Transaction,
       //                                              QuantityLeft = sr.Quantity_Left,
       //                                          }).ToList();

       //        return activityLogs;
       //    }
       //    catch (Exception)
       //    {

       //        throw;
       //    }
       //} 

    }
}
