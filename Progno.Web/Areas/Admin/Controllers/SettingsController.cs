using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using Progno.Business;
using Progno.Model.Model;
using Progno.Web.Areas.Admin.ViewModel;

namespace Progno.Web.Areas.Admin.Controllers
{
    public class SettingsController : BaseController
    {
        private SettingsViewModel viewModel;
        public ActionResult Index()
        {
            try
            {
                PopulateDropDowns();
            }
            catch (Exception)
            {
                
                throw;
            }
            return View(viewModel);
        }

        public ActionResult BusinessSetUp()
        {
            try
            {
                BusinessLogic businessLogic = new BusinessLogic();
                viewModel = new SettingsViewModel();
                viewModel.Business = businessLogic.GetModelBy(x => x.Business_Id == 1);

            }
            catch (Exception ex)
            {
               SetMessage("Error occured! "+ ex.Message, Message.Category.Error);
            }
            return RedirectToAction("Index", viewModel);
        }
        [HttpPost]
        public ActionResult EditBusiness(SettingsViewModel viewModel)
        {
            try
            {
                BusinessLogic businessLogic = new BusinessLogic();
                if (viewModel.Business != null)
                {
                    using (TransactionScope trans = new TransactionScope())
                    {
                        if (Request.Files[0].ContentLength > 0)
                        {
                            HttpPostedFileBase hpf = Request.Files[0] as HttpPostedFileBase;
                            string pathForSaving = Server.MapPath("~/Images");
                            string savedFileName = Path.Combine(pathForSaving, hpf.FileName);
                            string[] getExtension = hpf.FileName.Split('.');
                            string extension = "." + getExtension[1];
                            string invalidImage = InvalidFile(Request.Files[0].ContentLength, extension);
                            if (string.IsNullOrEmpty(invalidImage))
                            {
                                hpf.SaveAs(savedFileName);
                                viewModel.Business.LogoUrl = "/Images/" + hpf.FileName;
                            }
                            else
                            {
                                SetMessage(invalidImage, Message.Category.Error);
                            }
                        }
                        businessLogic.Create(viewModel.Business);
                        trans.Complete();
                        SetMessage("Operation Successful", Message.Category.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                SetMessage("Error occured! " + ex.Message, Message.Category.Error);
            }
            return RedirectToAction("Index");
        }

        public ActionResult BranchSetUp(SettingsViewModel viewModel)
        {
            try
            {
                BranchLogic branchLogic = new BranchLogic();
                if (viewModel.Branch != null)
                {
                    using (TransactionScope trans = new TransactionScope())
                    {
                        viewModel.Branch.Business = new Model.Model.Business() {Id = 1};
                        branchLogic.Create(viewModel.Branch);
                        trans.Complete();
                        SetMessage("Operation Successful", Message.Category.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                SetMessage("Error occured! " + ex.Message, Message.Category.Error);
            }
            return RedirectToAction("Index");
        }
        public ActionResult ReservationSetUp(SettingsViewModel viewModel)
        {
            try
            {
                ReservationTypeLogic reservationTypeLogic = new ReservationTypeLogic();
                if (viewModel.ReservationType != null)
                {
                    reservationTypeLogic.Create(viewModel.ReservationType);
                }
                SetMessage("Operation Successful", Message.Category.Information);

            }
            catch (Exception ex)
            {
                SetMessage("Error occured! " + ex.Message, Message.Category.Error);
            }
            return RedirectToAction("Index");
        }
        public ActionResult UserSetUp(SettingsViewModel viewModel)
        {
            try
            {
                UserLogic userLogic = new UserLogic();
                PersonLogic personLogic = new PersonLogic();
                Person person = new Person();
                Model.Model.User user = new User();
                Staff staff = new Staff();
                string email = null;
                StaffLogic staffLogic = new StaffLogic();
                List<User> existingUsers = new List<User>();
                SalaryLogic salaryLogic = new SalaryLogic();
                Salary salary = new Salary();
                if (viewModel.User != null)
                {
                    using (TransactionScope trans = new TransactionScope())
                    {
                        if (Request.Files[0].ContentLength > 0)
                        {
                            HttpPostedFileBase hpf = Request.Files[0] as HttpPostedFileBase;
                            string pathForSaving = Server.MapPath("~/Images/Staff");
                            string savedFileName = Path.Combine(pathForSaving, hpf.FileName);
                            string[] getExtension = hpf.FileName.Split('.');
                            string extension = "." + getExtension[1];
                            string invalidImage = InvalidFile(Request.Files[0].ContentLength, extension);
                            if (string.IsNullOrEmpty(invalidImage))
                            {
                                hpf.SaveAs(savedFileName);
                                viewModel.User.Image = "/Images/Staff/" + hpf.FileName;
                            }
                            else
                            {
                                SetMessage(invalidImage, Message.Category.Error);
                            }
                        }
                        viewModel.Person.DateRegistered = DateTime.Now.Date;
                        person = personLogic.Create(viewModel.Person);
                        viewModel.User.Person = person;
                        viewModel.User.Name = person.FirstName + "." + person.LastName;
                        email = viewModel.User.Email;
                        viewModel.User.Password = email;
                        existingUsers =
                            userLogic.GetModelsBy(
                                x => x.Password.ToUpper().Replace(" ", "") == email.ToUpper().Replace(" ", ""));
                        if (existingUsers.Count > 0)
                        {
                            SetMessage("User with this email exists. Please, use another email", Message.Category.Warning);
                            return RedirectToAction("Index");
                        }
                        viewModel.User.LastLogin = DateTime.Now.Date;
                        user = userLogic.Create(viewModel.User);

                        viewModel.Staff.User = user;
                        viewModel.Staff.Person = person;
                        staff = staffLogic.Create(viewModel.Staff);

                        salary.CreditBalance = 0;
                        salary.UnauthorisedCredit = 0;
                        salary.StaffCredit = 0;
                        salary.Surcharge = 0;
                        salary.Attendance = 0;
                        salary.Deduction = 0;
                        salary.Staff = staff;
                        salary.Month = DateTime.Now.Month.ToString();
                        salary.Date = DateTime.Today;
                        salary.Bonus = 0;
                        salary.FinalBalance = staff.Salary;
                        salary.SalaryScheme = (decimal)staff.Salary;
                        salaryLogic.Create(salary);
                        trans.Complete();
                        SetMessage("Operation Successful", Message.Category.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                SetMessage("Error occured! " + ex.Message, Message.Category.Error);
            }
            return RedirectToAction("Index");
        }
        public ActionResult CustomerSetUp(SettingsViewModel viewModel)
        {
            try
            {
               CustomerLogic customerLogic = new CustomerLogic();
                PersonLogic personLogic = new PersonLogic();
                Person person = new Person();
                List<Customer> customers = new List<Customer>();
                Person customerPerson = new Person();
                Customer existCustomer = new Customer();
                Customer newCustomer = new Customer();
                Customer CreatedCustomer = new Customer();
                long number = 0;

                using (TransactionScope scope = new TransactionScope())
                {
                    existCustomer = customerLogic.GetModelBy(x => x.PERSON.First_Name == viewModel.Customer.FirstName &&
                                                             x.PERSON.Last_Name == viewModel.Customer.LastName &&
                                                             x.PERSON.Email == viewModel.Customer.Email);
                    number = customerLogic.GetAll().Count;
                    if (existCustomer != null)
                    {
                        SetMessage("Customer with same details already exists " , Message.Category.Warning);
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        person = new Person();
                        person.FirstName = viewModel.Customer.FirstName;
                        person.LastName = viewModel.Customer.LastName;
                        person.Email = viewModel.Customer.Email;
                        person.DateRegistered = DateTime.Now.Date;

                        customerPerson = personLogic.Create(person);
                        newCustomer.Id = customerPerson.Id;
                        long newnum = number+1;
                        string final = newnum.ToString("D4");
                        newCustomer.CustomerId = "EXT" + "/" +final ;
                        newCustomer.TimesVisited = 1;
                        newCustomer.LastDateVisited = DateTime.Now.Date;
                        CreatedCustomer = customerLogic.Create(newCustomer);
                    }
                    scope.Complete();

                }
                SetMessage("Operation Successful ", Message.Category.Information);

            }
            catch (Exception ex)
            {
                SetMessage("Error occured! " + ex.Message, Message.Category.Error);
            }
            return RedirectToAction("Index");
        }
        private Customer newCustomer(Customer customer)
        {
            try
            {
                CustomerLogic customerLogic = new CustomerLogic();
                PersonLogic personLogic = new PersonLogic();
                Person person = new Person();
                List<Customer> customers = new List<Customer>();
                Person customerPerson = new Person();
                Customer existCustomer = new Customer();
                Customer newCustomer = new Customer();
                Customer CreatedCustomer = new Customer();
                long number = 0;

                using (TransactionScope scope = new TransactionScope())
                {
                    existCustomer = customerLogic.GetModelBy(x => x.PERSON.First_Name == customer.FirstName &&
                                                             x.PERSON.Last_Name == customer.LastName &&
                                                             x.PERSON.Email == customer.Email);
                    number = customerLogic.GetAll().Count;
                    if (existCustomer != null)
                    {
                        return existCustomer;
                    }
                    else
                    {
                        person = new Person();
                        person.FirstName = customer.FirstName;
                        person.LastName = customer.LastName;
                        person.Email = customer.Email;
                        person.DateRegistered = DateTime.Now.Date;

                        customerPerson = personLogic.Create(person);
                        newCustomer.Id = customerPerson.Id;
                        long newnum = number+1;
                        string final = newnum.ToString("D4");
                        newCustomer.CustomerId = "EXT" + "/" +final ;
                        newCustomer.TimesVisited = 1;
                        newCustomer.LastDateVisited = DateTime.Now.Date;
                        CreatedCustomer = customerLogic.Create(newCustomer);
                    }
                    scope.Complete();

                }
                return CreatedCustomer;
            }
            catch (Exception ex)
            {
                SetMessage("Error Occured!" + ex.Message, Message.Category.Error);
                return null;
            }

        }

        public ActionResult PaymentSetUp(SettingsViewModel viewModel)
        {
            try
            {
                PaymentTypeLogic paymentTypeLogic = new PaymentTypeLogic();
                

                if (viewModel.PaymentType != null)
                {
                    List<PaymentType> existingPayments =
                    paymentTypeLogic.GetModelsBy(
                        x =>
                            x.Payment_Type_Name.ToUpper().Replace(" ", "") ==
                            viewModel.PaymentType.Name.ToUpper().Replace(" ", ""));
                    if (existingPayments.Count>0) 
                    {
                        SetMessage("Payment Type already exists! " , Message.Category.Warning);
                        return RedirectToAction("Index");

                    }
                    paymentTypeLogic.Create(viewModel.PaymentType);
                }
            }
            catch (Exception ex)
            {
                SetMessage("Error occured! " + ex.Message, Message.Category.Error);
            }
            return RedirectToAction("Index");
        }
        public ActionResult DiscountSetUp(SettingsViewModel viewModel)
        {
            try
            {
                DiscountLogic discountLogic = new DiscountLogic();
                if (viewModel.Discount != null)
                {
                    discountLogic.Create(viewModel.Discount);
                }
            }
            catch (Exception ex)
            {
                SetMessage("Error occured! " + ex.Message, Message.Category.Error);
            }
            return RedirectToAction("Index");
        }
        public ActionResult HappyHour()
        {
            try
            {
                viewModel = new SettingsViewModel();
          HappyHourLogic happyHourLogic = new HappyHourLogic();
               viewModel.HappyHours = happyHourLogic.GetAll();

            }
            catch (Exception ex)
            {
                SetMessage("Error occured! " + ex.Message, Message.Category.Error);
            }
            return View(viewModel);
        }

        public ActionResult AddHappyHour()
        {
            try
            {
            PopulateDropDowns();
            }
            catch (Exception ex)
            {
                SetMessage("Error occured! " + ex.Message, Message.Category.Error);
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddHappyHour(SettingsViewModel viewModel)
        {
            try
            {
                List<Model.Model.HappyHour> happyHours = new List<HappyHour>();
                HappyHourLogic happyHourLogic = new HappyHourLogic();
               
                if (viewModel.HappyHour != null) 
                {
                 UserLogic userLogic = new UserLogic();
                 Model.Model.User user =new User();
                 StaffLogic staffLogic = new StaffLogic();
                 happyHours =
                happyHourLogic.GetModelsBy(
                    x =>
                        x.Start_Time.CompareTo(viewModel.HappyHour.StartTime) <= 0 &&
                        x.End_Time.CompareTo(viewModel.HappyHour.EndTime) <= 0 && x.Date == viewModel.HappyHour.Date);
                 if (happyHours.Count> 0)
                 {
                     SetMessage("Happy hour with this period exist ", Message.Category.Warning);
                     return RedirectToAction("AddHappyHour");

                 }
                 if (viewModel.HappyHour.Date < DateTime.Now.Date)
                    {
                        SetMessage("You cannot set Happy hour for past events", Message.Category.Warning);
                        return RedirectToAction("AddHappyHour");

                    }
                 user = userLogic.GetModelBy(x => x.User_Name == User.Identity.Name);
                    if (user != null)
                    {
                        viewModel.HappyHour.Staff = staffLogic.GetModelBy(x => x.User_Id == user.Id);
                    }
                    using (TransactionScope trans = new TransactionScope())
                    {

                        happyHourLogic.Create(viewModel.HappyHour);
                        trans.Complete();
                        SetMessage("Operation Successful", Message.Category.Information);

                    }
                }   
            }
            catch (Exception ex)
            {
                SetMessage("Error occured! " + ex.Message, Message.Category.Error);
            }
            return RedirectToAction("AddHappyHour");
        }

        public ActionResult ActivateHappyHour(int? id)
        {
            try
            {
            Model.Model.HappyHour happyHour = new HappyHour();
            HappyHourLogic happyHourLogic = new HappyHourLogic();
            List<HappyHour> happyHours = new List<HappyHour>();
                bool isModified = false;
                if (id != null)
                {
                    happyHour = happyHourLogic.GetModelBy(x => x.Happy_Hour_Id == id);
                }
                happyHours = happyHourLogic.GetModelsBy(x => x.Activated == true);
                if (happyHours.Count > 0)
                {
                    SetMessage("Happy hour period already exists! " , Message.Category.Warning);
                    return RedirectToAction("HappyHour");

                }
                if (happyHour != null)
                {
                    if (happyHour.Activated == true)
                    {
                        SetMessage("Happy hour period Is already Active! ", Message.Category.Warning);
                        return RedirectToAction("HappyHour");

                    }
                    if (happyHour.StartTime.TimeOfDay < DateTime.Now.TimeOfDay && happyHour.Date.Date < DateTime.Now.Date) 
                    {
                        SetMessage("Happy hour period Cannot be set. Date has already passed! ", Message.Category.Warning);
                        return RedirectToAction("HappyHour");
                    }
                    happyHour.Activated = true;
                    isModified = happyHourLogic.Modify(happyHour);
                }
                if (isModified == true)
                {
                    SetMessage("Operation Successful! ", Message.Category.Information);
                  }
                else
                {
                    SetMessage("Error Occured! ", Message.Category.Error);

                }

            }
            catch (Exception ex)
            {
                SetMessage("Error occured! " + ex.Message, Message.Category.Error);
            }
            return RedirectToAction("HappyHour");
        }

        public ActionResult DeActivateHappyHour(int? id)
        {
            try
            {
                Model.Model.HappyHour happyHour = new HappyHour();
                HappyHourLogic happyHourLogic = new HappyHourLogic();
                bool isModified = false;
                if (id != null)
                {
                    happyHour = happyHourLogic.GetModelBy(x => x.Happy_Hour_Id == id);
                }
                if (happyHour != null)
                {
                    if (happyHour.Activated == false)
                    {
                        SetMessage("Happy hour period Is Not Active! ", Message.Category.Warning);
                        return RedirectToAction("HappyHour");

                    }
                   happyHour.Activated = false;
                    isModified = happyHourLogic.Modify(happyHour);
                }
                if (isModified == true)
                {
                    SetMessage("Operation Successful! ", Message.Category.Information);
                }
                else
                {
                    SetMessage("Error Occured! ", Message.Category.Error);

                }
            }
            catch (Exception ex)
            {
                SetMessage("Error occured! " + ex.Message, Message.Category.Error);
            }
            return RedirectToAction("HappyHour");
        }
        private string InvalidFile(decimal uploadedFileSize, string fileExtension)
        {
            try
            {
                string message = null;
                decimal oneKiloByte = 1024;
                decimal maximumFileSize = 5000 * oneKiloByte;

                decimal actualFileSizeToUpload = Math.Round(uploadedFileSize / oneKiloByte, 1);
                if (InvalidFileType(fileExtension))
                {
                    message = "File type '" + fileExtension + "' is invalid! File type must be any of the following: .jpg, .jpeg, .png or .jif ";
                }
                else if (actualFileSizeToUpload > (maximumFileSize / oneKiloByte))
                {
                    message = "Your file size of " + actualFileSizeToUpload.ToString("0.#") + " Kb is too large, maximum allowed size is " + (maximumFileSize / oneKiloByte) + " Kb";
                }

                return message;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool InvalidFileType(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {
                case ".jpg":
                    return false;
                case ".png":
                    return false;
                case ".gif":
                    return false;
                case ".jpeg":
                    return false;
                default:
                    return true;
            }
        }
        private void PopulateDropDowns()
        {
            viewModel = new SettingsViewModel();
            ViewBag.Role = viewModel.RoleSelectList;
            ViewBag.Sex = viewModel.SexSelectList;
        }
    }
}