using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
    public class SalaryTranslator: BaseTranslator<Salary, SALARY>
    {
        private StaffTranslator staffTranslator;
        private SalarySchemeTranslator salarySchemeTranslator;
        public SalaryTranslator()
        {
           staffTranslator = new StaffTranslator();
            salarySchemeTranslator = new SalarySchemeTranslator();
        }
        public override Salary TranslateToModel(SALARY entity)
        {
            try
            {
                Salary model = null;
                if (entity != null)
                {
                 model = new Salary();
                    model.Id = entity.Salary_Id;
                    model.CreditBalance = entity.Credit_Balance;
                    model.UnauthorisedCredit = entity.Unauthorised_Credit;
                    model.StaffCredit = entity.Staff_Credit;
                    model.Surcharge = entity.Surcharge;
                    model.Attendance = entity.Attendance;
                    model.Deduction = entity.Deduction;
                    model.Staff = staffTranslator.Translate(entity.STAFF);
                    model.Month = entity.Month;
                    model.Date = entity.Date;
                    model.Bonus = entity.Bonus;
                    model.FinalBalance = entity.Final_Balance;
                    model.SalaryScheme = entity.Salary1;
                }
                return model;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override SALARY TranslateToEntity(Salary model)
        {
            try
            {
                SALARY entity = null;
                if (model != null)
                {
                  entity = new SALARY();
                    entity.Salary_Id = model.Id;
                    entity.Credit_Balance = model.CreditBalance;
                    entity.Unauthorised_Credit = model.UnauthorisedCredit;
                    entity.Staff_Credit = model.StaffCredit;
                    entity.Surcharge = model.Surcharge;
                    entity.Attendance = model.Attendance;
                    entity.Deduction = model.Deduction;
                    entity.Staff_Id = model.Staff.Id;
                    entity.Month = model.Month;
                    entity.Date = model.Date;
                    entity.Bonus = model.Bonus;
                    entity.Final_Balance = model.FinalBalance;
                    entity.Salary1 = model.SalaryScheme;
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
