using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
   public class ProcurementTranslator: BaseTranslator<Procurement, PROCUREMENT>
   {
       private StaffTranslator staffTranslator;
       private SupplierTranslator supplierTranslator;

       public ProcurementTranslator()
       {
           staffTranslator = new StaffTranslator();
           supplierTranslator = new SupplierTranslator();
       }
        public override Procurement TranslateToModel(PROCUREMENT entity)
        {

            try
            {
                Procurement model = null;
                if (entity != null)
                {
                  model = new Procurement();
                    model.Id = entity.Id;
                    model.Staff = staffTranslator.Translate(entity.STAFF);
                    model.AmountPaid = entity.Amount_Paid;
                    model.Oustanding = entity.Oustanding;
                    model.TransactionDate = entity.Transaction_Date;
                    model.LastUpdateDate = entity.Last_Update_Date;
                    model.ReceiptNumber = entity.Receipt_Number;
                    model.Cleared = entity.Cleared;
                    model.Supplier = supplierTranslator.Translate(entity.SUPPLIER);

                }
                return model;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override PROCUREMENT TranslateToEntity(Procurement model)
        {
            try
            {
                PROCUREMENT entity = null;
                if (model != null)
                {
                  entity = new PROCUREMENT();
                    entity.Id = model.Id;
                    entity.Staff_Id = model.Staff.Id;
                    entity.Amount_Paid = model.AmountPaid;
                    entity.Oustanding = model.Oustanding;
                    entity.Transaction_Date = model.TransactionDate;
                    entity.Last_Update_Date = model.LastUpdateDate;
                    entity.Receipt_Number = model.ReceiptNumber;
                    entity.Cleared = model.Cleared;
                    entity.Supplier_Id = model.Supplier.Id;
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
