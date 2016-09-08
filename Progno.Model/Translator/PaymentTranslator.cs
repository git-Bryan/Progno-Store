using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
    public class PaymentTranslator : BaseTranslator<Payment, PAYMENT>
    {
        private PaymentTypeTranslator paymentTypeTranslator;
        private CustomerTranslator customerTranslator;
        private StaffTranslator staffTranslator;

        public PaymentTranslator()
        {
            paymentTypeTranslator = new PaymentTypeTranslator();
            customerTranslator = new CustomerTranslator();
            staffTranslator = new StaffTranslator();
        }
        public override Payment TranslateToModel(PAYMENT entity)
        {
            try
            {
                Payment model = null;
                if (entity != null)
                {
                 model = new Payment();
                    model.Id = entity.Payment_Id;
                    model.Customer = customerTranslator.Translate(entity.CUSTOMER);
                    model.PaymentType = paymentTypeTranslator.Translate(entity.PAYMENT_TYPE);
                    model.Amount = entity.Amount;
                    model.AmountTendered = entity.Amount_Tendered;
                    model.OutstandingAmount = entity.Outstanding_Amount;
                    model.OrderNo = entity.Order_No;
                    model.Staff = staffTranslator.Translate(entity.STAFF);
                    model.Paid = entity.Paid;
                    model.LastUpdateTime = entity.Last_Update_Time;
                    model.ExpectedPaymentDate = entity.Expected_Payment_Date;
                }
                return model;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override PAYMENT TranslateToEntity(Payment model)
        {
            try
            {
                PAYMENT entity = null;
                if (model != null)
                {
                   entity = new PAYMENT();
                    entity.Payment_Id = model.Id;
                    if (model.Customer != null)
                    {
                        entity.Customer_Id = model.Customer.Person.Id;
  
                    }
                    entity.Staff_Id = model.Staff.Id;
                    entity.Payment_Type_id = model.PaymentType.Id;
                    entity.Amount = model.Amount;
                    entity.Amount_Tendered = model.AmountTendered;
                    entity.Outstanding_Amount = model.OutstandingAmount;
                    entity.Order_No = model.OrderNo;
                    entity.Paid = model.Paid;
                    entity.Last_Update_Time = model.LastUpdateTime;
                    if (model.ExpectedPaymentDate!= null)
                    {
                        entity.Expected_Payment_Date = model.ExpectedPaymentDate;
   
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
