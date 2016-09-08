using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using Progno.Business;
using Progno.Model.Model;
using Progno.Web.Areas.Common.ViewModel;
using Progno.Web.Areas.Security.Controllers;

namespace Progno.Web.Areas.Common.Controllers
{
    public class HomePageController : BaseController
    {
        private ReservationViewModel viewModel;
        public ActionResult HomePage()
        {
            try
            {
                PopulateDropDowns();
            }
            catch (Exception)
            {
                
                throw;
            }
            return View();
        }
        public ActionResult MakeReservation(ReservationViewModel viewModel)
        {
            try
            {
                ReservationLogic reservationLogic = new ReservationLogic();
                PersonLogic personLogic = new PersonLogic();
                CustomerLogic customerLogic = new CustomerLogic();
                Customer  customer = new Customer();
                Person person = new Person();
                Customer existCustomer = new Customer();

               
                using (TransactionScope scope = new TransactionScope())
                {
                    customer = customerLogic.GetModelBy(x => x.PERSON.First_Name == viewModel.Customer.FirstName &&
                                                             x.PERSON.Last_Name == viewModel.Customer.LastName &&
                                                             x.PERSON.Email == viewModel.Customer.Email);
                    if (customer!= null)
                    {
                        customer.TimesVisited = customer.TimesVisited + 1;
                        customer.LastDateVisited = DateTime.Now.Date;
                        existCustomer = customerLogic.Modify(customer);
                        viewModel.Reservation.Customer = existCustomer;
                    }
                    viewModel.Reservation.ReservationCode = UniqueCode();
                    viewModel.Reservation.FirstName = viewModel.Customer.FirstName;
                    viewModel.Reservation.LastName = viewModel.Customer.LastName;
                    viewModel.Reservation.Emailaddress = viewModel.Customer.Email;
                    viewModel.Reservation.IsCheckedOut = false;
                    reservationLogic.Create(viewModel.Reservation);
                    scope.Complete();
                    SetMessage("Operation Successful,"+viewModel.Reservation.ReservationCode+ "Please Keep this code safe", Message.Category.Information);
                } 

            }
            catch (Exception ex)
            {
                SetMessage("Error Occured!  "+ ex.Message, Message.Category.Error);
            }
            return RedirectToAction("HomePage");
        }

       
        private void PopulateDropDowns()
        {
            viewModel = new ReservationViewModel();
            ViewBag.ReservationType = viewModel.ReservationTypeSelectList;
        }
        public string Shuffle(string str)
        {
            char[] array = str.ToCharArray();
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }
        public string UniqueCode()
        {
            try
            {
                string str = "0123456789ABCDEFGHIJKLMNPQRSTUVWXYZ987654321abcdefghijkmnopqrtvwxy";
                ProductLogic productLogic = new ProductLogic();
                string code = "";
                int check = 1;
                while (check != 0)
                {
                    code = Shuffle(str).Substring(0, 8).ToUpper();
                    check = productLogic.GetEntitiesBy(x => x.Barcode_No == code).Count();
                }

                return code;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}