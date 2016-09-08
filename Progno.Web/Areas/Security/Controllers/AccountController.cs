using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Progno.Business;
using Progno.Model.Model;
using Progno.Web.Models;

namespace Progno.Web.Areas.Security.Controllers
{
   
    public class AccountController : BaseController
    {
        // GET: Security/Account
        
        public ActionResult LogIn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel viewModel, string returnUrl)
        {
            try
            {
                UserLogic userLogic = new UserLogic();
                if (userLogic.ValidateUser(viewModel.UserName, viewModel.Password))
                {
                    User user =
                        userLogic.GetModelBy(x => x.User_Name == viewModel.UserName && x.Password == viewModel.Password);
                    
                        FormsAuthentication.SetAuthCookie(viewModel.UserName, false);
                      if (string.IsNullOrEmpty(returnUrl))
                        {
                            return RedirectToAction("index", "Home", new { Area = "" });

                           
                        }
                   
                        else
                        {
                            return RedirectToLocal(returnUrl);
                        }
                     
                  }
            }
            catch (Exception ex)
            {
                SetMessage("Error Occurred! " + ex.Message, Message.Category.Error);
            }

            SetMessage("Invalid Username or Password!", Message.Category.Error);
            return RedirectToAction("LogIn");
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn", new { Area = "Security" });
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

    }
}