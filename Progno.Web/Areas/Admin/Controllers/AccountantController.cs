using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Progno.Business;
using Progno.Model.Model;
using Progno.Web.Areas.Admin.ViewModel;

namespace Progno.Web.Areas.Admin.Controllers
{
    public class AccountantController : BaseController
    {
        private AccountantViewModel viewModel;
        public ActionResult Index()
        {
            try
            {
                viewModel = new AccountantViewModel();
                SalaryLogic salaryLogic = new SalaryLogic();
                viewModel.Salaries = salaryLogic.GetAll();
                
            }
            catch (Exception ex)
            {
                SetMessage("Error Occured! " + ex.Message, Message.Category.Error);
            }
            return View(viewModel);
        }

        public ActionResult ModifySalary(long? id)
        {
            try
            {
            viewModel = new AccountantViewModel();
            SalaryLogic salaryLogic = new SalaryLogic();
                if (id != null)
                {
                    viewModel.Salary = salaryLogic.GetModelBy(x => x.Salary_Id == id);
                    
                }
            }
            catch (Exception ex)
            {
                SetMessage("Error Occured! " + ex.Message, Message.Category.Error);
            }
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult ModifySalary(AccountantViewModel viewModel)
        {
            try
            {
                bool Ismodified = false;
                SalaryLogic salaryLogic = new SalaryLogic();
                Salary salary = new Salary();
                salary = salaryLogic.GetModelBy(x => x.Salary_Id == viewModel.Salary.Id);
                salary.CreditBalance = viewModel.Salary.CreditBalance;
                salary.UnauthorisedCredit = viewModel.Salary.UnauthorisedCredit;
                salary.StaffCredit = viewModel.Salary.StaffCredit;
                salary.Surcharge = viewModel.Salary.Surcharge;
                salary.Attendance = viewModel.Salary.Attendance;
                salary.Deduction = viewModel.Salary.Deduction;
                salary.Bonus = viewModel.Salary.Bonus;
                salary.FinalBalance = salary.SalaryScheme - viewModel.Salary.CreditBalance -
                                      viewModel.Salary.UnauthorisedCredit - viewModel.Salary.StaffCredit
                                      - viewModel.Salary.Surcharge - viewModel.Salary.Deduction + viewModel.Salary.Bonus;

                Ismodified = salaryLogic.Modify(salary);
                if (Ismodified == true)
                {
                    SetMessage("Operation Successful ", Message.Category.Information);
 
                }
                else
                {
                    SetMessage("Error Occured ", Message.Category.Error);
  
                }
            }
            catch (Exception ex)
            {
                SetMessage("Error Occured! " + ex.Message, Message.Category.Error);
            }
            return View(viewModel);
        }

    }
}