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
  public  class HappyHourLogic: BusinessBaseLogic<HappyHour, HAPPY_HOUR>
    {
      public HappyHourLogic()
      {
          translator = new HappyHourTranslator();
      }

      public bool Modify(HappyHour model)
      {
          try
          {
              HAPPY_HOUR entity = GetEntityBy(x => x.Happy_Hour_Id == model.Id);
              if (entity != null)
              {
                  if (model.Date != null)
                  {
                      entity.Date = model.Date;
                  }
                  if (model.StartTime != null)
                  {
                      entity.Start_Time = model.StartTime;
                  }
                  if (model.EndTime != null)
                  {
                      entity.End_Time = model.EndTime;
                  }
                  if (model.Activated != null)
                  {
                      entity.Activated = model.Activated;
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
