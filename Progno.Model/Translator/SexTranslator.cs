﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
    public class SexTranslator : BaseTranslator<Sex, SEX>
    {
        public override Sex TranslateToModel(SEX entity)
        {
            try
            {
                Sex model = null;
                if (entity != null)
                {
                    model = new Sex();
                    model.Id = entity.Sex_Id;
                    model.Name = entity.Sex_Name;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override SEX TranslateToEntity(Sex model)
        {
            try
            {
                SEX entity = null;
                if (model != null)
                {
                    entity = new SEX();
                    entity.Sex_Id = model.Id;
                    entity.Sex_Name = model.Name;
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
