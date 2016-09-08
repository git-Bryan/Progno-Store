using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
   public class OrderTranslator : BaseTranslator<Order, ORDER>
   {
       private ProductTranslator productTranslator;
       private DiscountTranslator discountTranslator;

       public OrderTranslator()
       {
           productTranslator = new ProductTranslator();
           discountTranslator = new DiscountTranslator();
       }

       public override Order TranslateToModel(ORDER entity)
       {
           try
           {
               Order model = null;
               if (entity != null)
               {
                   model = new Order();
                   model.Id = entity.Order_Id;
                   model.Product = productTranslator.Translate(entity.PRODUCT);
                   model.Quantity = entity.Quantity;
                   model.UnitPrice = entity.Unit_Price;
                   model.Discount = entity.Discount;
                   model.Amount = entity.Amount;
                   model.OrderTime = entity.Time_Order;
                   model.Checked = entity.Checked_Out;
                   model.OrderNo = entity.Order_No;

               }

               return model;
           }
           catch (Exception)
           {
               throw;
           }
       }

       public override ORDER TranslateToEntity(Order model)
       {

           try
           {
               ORDER entity = null;
               if (model != null)
               {
                   entity = new ORDER();
                   entity.Order_Id = model.Id;
                   entity.Product_Id = model.Product.Id;
                   entity.Quantity = model.Quantity;
                   entity.Unit_Price = model.UnitPrice;
                   entity.Discount = model.Discount;
                    entity.Amount = model.Amount;
                   entity.Time_Order = model.OrderTime;
                  entity.Order_No =  model.OrderNo;
                   if (model.Checked!= null)
                   {
                       entity.Checked_Out = model.Checked;
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
