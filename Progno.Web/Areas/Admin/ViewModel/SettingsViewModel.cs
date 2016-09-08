using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarcodeLib;
using Progno.Model.Model;
using Progno.Web.Models;

namespace Progno.Web.Areas.Admin.ViewModel
{
    public class SettingsViewModel
    {
        public SettingsViewModel()
        {
            UnitSelectList = Utility.PopulateUnitsSelectListItem();
            ProductCategorySelectList = Utility.PopulateProductCategorySelectListItem();
            StockTypeSelectList = Utility.PopulateStockTypeSelectListItem();
            RoleSelectList = Utility.PopulateRoleSelectListItem();
            SexSelectList = Utility.PopulateSexSelectListItem();
        }

        public List<SelectListItem> UnitSelectList { get; set; }
        public List<SelectListItem> ProductCategorySelectList { get; set; }
        public List<SelectListItem> StockTypeSelectList { get; set; }
        public List<SelectListItem> RoleSelectList { get; set; }
        public List<SelectListItem> SexSelectList { get; set; }
        public Customer Customer { get; set; }

        public Model.Model.Business Business { get; set; }
        public Branch Branch { get; set; }
        public ReservationType ReservationType { get; set; }
        public User User { get; set; }
        public Staff Staff { get; set; }
        public Person Person { get; set; }
        public PaymentType PaymentType { get; set; }
        public Discount Discount { get; set; }
        public Product Product { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public Unit Unit { get; set; }
        public StockType  StockType { get; set; }
        public Stock Stock { get; set; }
        public Catalog Catalog { get; set; }
        public HappyHour HappyHour { get; set; }
        public List<HappyHour> HappyHours { get; set; }
    }
}