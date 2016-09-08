using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
   public class SalesTranslator: BaseTranslator<Sales, SALES>
   {
       private SalesTypeTranslator salesTypeTranslator;
       private StaffTranslator staffTranslator;
       private OrderTranslator orderTranslator;

       public SalesTranslator()
       {
           salesTypeTranslator = new SalesTypeTranslator();
           staffTranslator = new StaffTranslator();
           orderTranslator = new OrderTranslator();
       }
        public override Sales TranslateToModel(SALES entity)
        {
            try
            {
                Sales model = null;
                if (entity != null)
                {
                   model = new Sales();
                    model.Id = entity.Sales_Id;
                    model.TransactionDate = entity.Date_Of_Transaction;
                    model.SalesType = salesTypeTranslator.Translate(entity.SALES_TYPE);
                    model.Staff = staffTranslator.Translate(entity.STAFF);
                    model.Order = orderTranslator.Translate(entity.ORDER);
                }
                return model;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override SALES TranslateToEntity(Sales model)
        {
            try
            {
                SALES entity = null;
                if (model != null)
                {
                  entity = new SALES();
                    entity.Sales_Id = model.Id;
                    entity.Date_Of_Transaction = model.TransactionDate;
                    entity.Sales_Type_Id = model.SalesType.Id;
                    entity.Staff_Id = model.Staff.Id;
                    entity.Order_Id = model.Order.Id;
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
