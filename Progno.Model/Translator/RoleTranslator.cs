using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
    public class RoleTranslator : BaseTranslator<Role, ROLE>
    {
        public override Role TranslateToModel(ROLE entity)
        {
            try
            {
                Role model = null;
                if (entity != null)
                {
                    model = new Role();
                    model.Id = entity.Role_Id;
                    model.Name = entity.Role_Name;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override ROLE TranslateToEntity(Role model)
        {
            try
            {
                ROLE entity = null;
                if (model != null)
                {
                    entity = new ROLE();
                    entity.Role_Id = model.Id;
                    entity.Role_Name = model.Name;
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
