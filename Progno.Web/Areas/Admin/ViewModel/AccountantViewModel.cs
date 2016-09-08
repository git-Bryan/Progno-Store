using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Progno.Model.Model;

namespace Progno.Web.Areas.Admin.ViewModel
{
    public class AccountantViewModel
    {
        public Salary Salary { get; set; }
        public List<Salary> Salaries { get; set; }  
    }
}