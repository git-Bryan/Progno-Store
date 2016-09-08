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
   public class PaymentLogic :BusinessBaseLogic<Payment, PAYMENT>
    {
       public PaymentLogic()
       {
           translator = new PaymentTranslator();
       }
       public List<PaymentList> GetAllPayments()
       {
           try
           {
               List<PaymentList> paymentLists = (from sr in repository.GetAll<VW_PAYMENT>()
                                            select new PaymentList
                                            {
                                                PaymentId = sr.Payment_Id,
                                                UserId =  sr.User_Id,
                                                PaymentTypeid = sr.Payment_Type_id,
                                                PaymentTypeName = sr.Payment_Type_Name,
                                                Amount= sr.Amount,
                                                OutstandingAmount = sr.Outstanding_Amount,
                                                OrderNo = sr.Order_No,
                                                Paid = sr.Paid,
                                                LastUpdateTime = sr.Last_Update_Time,
                                                ExpectedPaymentDate = sr.Expected_Payment_Date,
                                                CustomerId = sr.Customer_Id,
                                                CustomerFirstName = sr.First_Name,
                                                CustomerLastName = sr.Last_Name,
                                                SalesFirstName = sr.Expr1,
                                                SalesLastName = sr.Expr2,
                                               
                                            }).ToList();

               return paymentLists;
           }
           catch (Exception)
           {

               throw;
           }
       }

       public List<PaymentList> GetPaymentsByUser(User user)
       {
           try
           {
               List<PaymentList> paymentLists = (from sr in repository.GetBy<VW_PAYMENT>(x=>x.User_Id == user.Id)
                                                 select new PaymentList
                                                 {
                                                     PaymentId = sr.Payment_Id,
                                                     UserId = sr.User_Id,
                                                     PaymentTypeid = sr.Payment_Type_id,
                                                     PaymentTypeName = sr.Payment_Type_Name,
                                                     Amount = sr.Amount,
                                                     OutstandingAmount = sr.Outstanding_Amount,
                                                     OrderNo = sr.Order_No,
                                                     Paid = sr.Paid,
                                                     LastUpdateTime = sr.Last_Update_Time,
                                                     ExpectedPaymentDate = sr.Expected_Payment_Date,
                                                     CustomerId = sr.Customer_Id,
                                                     CustomerFirstName = sr.First_Name,
                                                     CustomerLastName = sr.Last_Name,
                                                     SalesFirstName = sr.Expr1,
                                                     SalesLastName = sr.Expr2,

                                                 }).ToList();

               return paymentLists;
           }
           catch (Exception)
           {

               throw;
           }
       }
       public List<PaymentList> GetPaymentsByType(PaymentType paymentType)
       {
           try
           {
               List<PaymentList> paymentLists = (from sr in repository.GetBy<VW_PAYMENT>(x => x.Payment_Type_id == paymentType.Id)
                                                 select new PaymentList
                                                 {
                                                     PaymentId = sr.Payment_Id,
                                                     UserId = sr.User_Id,
                                                     PaymentTypeid = sr.Payment_Type_id,
                                                     PaymentTypeName = sr.Payment_Type_Name,
                                                     Amount = sr.Amount,
                                                     OutstandingAmount = sr.Outstanding_Amount,
                                                     OrderNo = sr.Order_No,
                                                     Paid = sr.Paid,
                                                     LastUpdateTime = sr.Last_Update_Time,
                                                     ExpectedPaymentDate = sr.Expected_Payment_Date,
                                                     CustomerId = sr.Customer_Id,
                                                     CustomerFirstName = sr.First_Name,
                                                     CustomerLastName = sr.Last_Name,
                                                     SalesFirstName = sr.Expr1,
                                                     SalesLastName = sr.Expr2,

                                                 }).ToList();

               return paymentLists;
           }
           catch (Exception)
           {

               throw;
           }
       }

       public bool Modify(Payment payment)
       {
           try
           {
               PAYMENT entity = GetEntityBy(x => x.Payment_Id == payment.Id);
               if (entity!= null)
               {
                   if (payment.Customer!= null)
                   {
                       entity.Customer_Id = payment.Customer.Person.Id;
                       
                   }
                   
                   if (payment.Staff != null)
                   {
                       entity.Staff_Id = payment.Staff.Id;

                   }
                   if (payment.PaymentType != null)
                   {
                       entity.Payment_Type_id = payment.PaymentType.Id;

                   }
                   if (payment.Amount != null)
                   {
                       entity.Amount = payment.Amount;

                   }
                   if (payment.AmountTendered != null)
                   {
                       entity.Amount_Tendered= payment.AmountTendered;

                   }
                   if (payment.OutstandingAmount != null)
                   {
                       entity.Outstanding_Amount = payment.OutstandingAmount;

                   }
                   if (payment.OrderNo != null)
                   {
                       entity.Order_No = payment.OrderNo;

                   }
                   if (payment.Paid != null)
                   {
                       entity.Paid = payment.Paid;

                   }
                   if (payment.LastUpdateTime != null)
                   {
                       entity.Last_Update_Time = payment.LastUpdateTime;

                   }
                   if (payment.ExpectedPaymentDate != null)
                   {
                       entity.Expected_Payment_Date = payment.ExpectedPaymentDate;

                   }
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
    }
}
