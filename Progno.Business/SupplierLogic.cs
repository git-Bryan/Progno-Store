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
   public class SupplierLogic: BusinessBaseLogic<Supplier, SUPPLIER>
    {
       public SupplierLogic()
       {
           translator = new SupplierTranslator();
       }
    }
}
