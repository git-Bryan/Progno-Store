﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
    public class LocalGovernmentTranslator : BaseTranslator<LocalGovernment, LOCAL_GOVERNMENT>
    {
        private StateTranslator stateTranslator = new StateTranslator();

        public override LocalGovernment TranslateToModel(LOCAL_GOVERNMENT localGovernmentEntity)
        {
            try
            {
                LocalGovernment localGovernment = null;
                if (localGovernmentEntity != null)
                {
                    localGovernment = new LocalGovernment();
                    localGovernment.Id = localGovernmentEntity.Local_Government_Id;
                    localGovernment.Name = localGovernmentEntity.Local_Government_Name;
                    localGovernment.State = stateTranslator.TranslateToModel(localGovernmentEntity.STATE);
                }

                return localGovernment;
            }
            catch (Exception)
            {
                throw;
            };
        }

        public override LOCAL_GOVERNMENT TranslateToEntity(LocalGovernment localGovernment)
        {
            try
            {
                LOCAL_GOVERNMENT localGovernmentEntity = null;
                if (localGovernment != null)
                {
                    localGovernmentEntity = new LOCAL_GOVERNMENT();
                    localGovernmentEntity.Local_Government_Id = localGovernment.Id;
                    localGovernmentEntity.Local_Government_Name = localGovernment.Name;
                    localGovernmentEntity.State_Id = localGovernment.State.Id;
                }

                return localGovernmentEntity;
            }
            catch (Exception)
            {
                throw;
            };
        }
    }

}
