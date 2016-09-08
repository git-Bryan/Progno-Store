using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Progno.Model.Model;

namespace Progno.Web.Areas.Sales.Controllers
{
    public class BaseController : Controller
    {
      
        protected void SetMessage(string message, Message.Category messageType)
        {
            Message msg = new Message(message, (int)messageType);
            TempData["Message"] = msg;
        }
    }
}