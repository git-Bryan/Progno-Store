using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Translator;


namespace Progno.Business
{
   public class BusinessLogic : BusinessBaseLogic<Model.Model.Business, BUSINESS>
   {
       public BusinessLogic()
       {
           translator = new BusinessTranslator();
       }
    }
}
