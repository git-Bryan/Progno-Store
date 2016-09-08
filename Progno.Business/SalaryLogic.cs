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
    public class SalaryLogic: BusinessBaseLogic<Salary, SALARY>
    {
        public SalaryLogic()
        {
            translator = new SalaryTranslator();
        }

        public bool Modify(Salary model)
        {
            try
            {
                SALARY entity = GetEntityBy(x => x.Salary_Id == model.Id);
                if (entity != null)
                {
                    if (model.CreditBalance != null)
                    {
                        entity.Credit_Balance = model.CreditBalance;
                    }
                    if (model.UnauthorisedCredit != null)
                    {
                        entity.Unauthorised_Credit = model.UnauthorisedCredit;
                    }
                    if (model.StaffCredit != null)
                    {
                        entity.Staff_Credit = model.StaffCredit;
                    }
                    if (model.Surcharge != null)
                    {
                        entity.Surcharge = model.Surcharge;
                    }
                    if (model.Attendance != null)
                    {
                        entity.Attendance = model.Attendance;
                    }
                    if (model.Deduction != null)
                    {
                        entity.Deduction = model.Deduction;
                    }
                    if (model.Bonus != null)
                    {
                        entity.Bonus = model.Bonus;
                    }
                    if (model.FinalBalance != null)
                    {
                        entity.Final_Balance = model.FinalBalance;
                    }
                    Save();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }
    }
}
