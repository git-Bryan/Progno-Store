using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
    public class BarTranslator :BaseTranslator<Bar,BAR>
    {
        public override Bar TranslateToModel(BAR entity)
        {
            try
            {
                Bar model = null;
                if (entity != null)
                {
                    model = new Bar();
                    model.Id = entity.Bar_Id;
                    model.Name = entity.Bar_name;
                    model.Active = entity.Active;
                }
                return model;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override BAR TranslateToEntity(Bar model)
        {
            try
            {
                BAR entity = null;
                if ( model != null)
                {
                    entity = new BAR();
                    entity.Bar_Id = model.Id;
                    entity.Bar_name = model.Name;
                    entity.Active = model.Active;
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
