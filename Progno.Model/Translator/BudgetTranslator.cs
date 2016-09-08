using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
    public class BudgetTranslator : BaseTranslator<Budget,BUDGET>
    {
        public override Budget TranslateToModel(BUDGET entity)
        {
            try
            {
                Budget model = null;
                if (entity != null)
                {
                    model = new Budget();
                    model.Id = entity.Budget_Id;
                    model.BudgetNo = entity.Budget_No;
                    model.BudgetItem = entity.Budget_Item;
                    model.Signed = entity.Signed;
                    model.Date = entity.Date;
                    model.Delivered = entity.Delivered;
                }
                return model;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override BUDGET TranslateToEntity(Budget model)
        {
            try
            {
                BUDGET entity = null;
                if (model != null)
                {
                    entity = new BUDGET();
                    entity.Budget_Id = model.Id;
                    entity.Budget_No = model.BudgetNo;
                    entity.Budget_Item = model.BudgetItem;
                    entity.Signed = model.Signed;
                    entity.Date = model.Date;
                    entity.Delivered = model.Delivered;
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
