using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
    public class HappyHourTranslator : BaseTranslator<HappyHour, HAPPY_HOUR>
    {
        private StaffTranslator staffTranslator;

        public HappyHourTranslator()
        {
            staffTranslator = new StaffTranslator();
        }
        public override HappyHour TranslateToModel(HAPPY_HOUR entity)
        {
            try
            {
                HappyHour model = null;
                if (entity != null)
                {
                   model = new HappyHour();
                    model.Id = entity.Happy_Hour_Id;
                    model.Date = entity.Date;
                    model.StartTime = entity.Start_Time;
                    model.EndTime = entity.End_Time;
                    model.Staff = staffTranslator.Translate(entity.STAFF);
                    model.Activated = entity.Activated;
                }
                return model;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override HAPPY_HOUR TranslateToEntity(HappyHour model)
        {
            try
            {
                HAPPY_HOUR entity = null;
                if (model != null)
                {
                   entity = new HAPPY_HOUR();
                    entity.Happy_Hour_Id = model.Id;
                    entity.Date = model.Date;
                    entity.Start_Time = model.StartTime;
                    entity.End_Time = model.EndTime;
                    entity.Staff_Id = model.Staff.Id;
                    entity.Activated = model.Activated;
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
