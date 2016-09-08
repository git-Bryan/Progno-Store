using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Progno.Business;
using Progno.Model.Model;
using Progno.Web.Models;

namespace Progno.Web.Controllers
{
     [Authorize]
    public class HomeController : BaseController
    {
        private RegisterViewModel viewModel;

        public HomeController()
        {
            
        }
        public ActionResult Index()
        {
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            //UserLogic userLogic = new UserLogic();
            //User currentUser = userLogic.GetModelBy(x => x.User_Name == User.Identity.Name);
            //if (currentUser != null)
            //{
            //    ViewBag.Image = currentUser.Image;

            //}
            //StaffLogic staffLogic = new StaffLogic();
            //Staff staff = new Staff();
            //if (User.Identity.IsAuthenticated)
            //{
            //    staff = staffLogic.GetModelBy(x => x.User_Id == currentUser.Id);
            //    ViewBag.Name = staff.Person.FullName;
            //}
            try
            {
                UserLogic userLogic = new UserLogic();
                User currentUser = userLogic.GetModelBy(x => x.User_Name == User.Identity.Name);
                StaffLogic staffLogic = new StaffLogic();
                Staff staff = new Staff();
                ProductLogic productLogic = new ProductLogic();
                
                if (User.Identity.IsAuthenticated)
                {
                    staff = staffLogic.GetModelBy(x => x.User_Id == currentUser.Id);
                    ViewBag.Name = staff.Person.FullName;
                    ViewBag.Role = currentUser.Role.Name;
                    ViewBag.Admin = userLogic.GetCount(p=>p.Role_Id==3);
                    ViewBag.SalesUsers = userLogic.GetCount(p => p.Role_Id == 4);
                    ViewBag.ProductCount = productLogic.GetCount(p => p.Product_Id != null);
                    ViewBag.ImagefileUrl = currentUser.Image;
                    ViewBag.Role = currentUser.Role.Name;
                }
            }
            catch (Exception ex)
            {
               SetMessage("Error occured"+ ex.Message, Message.Category.Warning);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       
    }
}