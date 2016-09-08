using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
   public class SalarySchemeTranslator: BaseTranslator<SalaryScheme, SALARY_SCHEME>
   {
       private RoleTranslator roleTranslator;

       public SalarySchemeTranslator()
       {
           roleTranslator = new RoleTranslator();
       }
        public override SalaryScheme TranslateToModel(SALARY_SCHEME entity)
        {
            
            try
            {
                SalaryScheme model = null;
                if (entity != null)
                {
                    model = new SalaryScheme();
                    model.Id = entity.Salary_Scheme_Id;
                    model.Role = roleTranslator.Translate(entity.ROLE);
                    model.BasicSalary = entity.Basic_Salary_Amount;
                    model.Tax = entity.Tax;
                }
                return model;
                }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override SALARY_SCHEME TranslateToEntity(SalaryScheme model)
        {
            try
            {
                SALARY_SCHEME entity = null;
                if (model != null)
                {
                    entity = new SALARY_SCHEME();
                    entity.Salary_Scheme_Id = model.Id;
                    entity.Role_Id = model.Role.Id;
                    entity.Basic_Salary_Amount = model.BasicSalary;
                    entity.Tax = model.Tax;
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
