using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
   public class UnitTranslator : BaseTranslator<Unit, UNIT>
    {
        public override Unit TranslateToModel(UNIT entity)
        {
            try
            {
                Unit model = null;
                if (entity != null)
                {
                    model = new Unit();
                    model.Id = entity.Unit_Id;
                    model.Name = entity.Unit_Name;
                    model.Description = entity.Unit_Description;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override UNIT TranslateToEntity(Unit model)
        {
 try
            {
                UNIT entity = null;
                if (model != null)
                {
                    entity = new UNIT();
                    entity.Unit_Id = model.Id;
                    entity.Unit_Name = model.Name;
                    entity.Unit_Description = model.Description;
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
