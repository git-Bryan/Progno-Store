using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Progno.Model.Model;
using Progno.Web.Models;

namespace Progno.Web.Areas.Admin.ViewModel
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            UnitSelectList = Utility.PopulateUnitsSelectListItem();
            ProductCategorySelectList = Utility.PopulateProductCategorySelectListItem();
            StockTypeSelectList = Utility.PopulateStockTypeSelectListItem();
            SupplierSelectList = Utility.PopulateSupplierSelectListItem();
        }

        public List<SelectListItem> UnitSelectList { get; set; }
        public List<SelectListItem> SupplierSelectList { get; set; }
        public List<SelectListItem> ProductCategorySelectList { get; set; }
        public List<SelectListItem> StockTypeSelectList { get; set; }

        public Product Product { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public Unit Unit { get; set; }
        public List<StockList> StockLists { get; set; }
        public List<ActivityLog> ActivityLogs { get; set; }
        public List<PaymentList> PaymentLists { get; set; }
        public StockList StockList { get; set; }
        public StockType  StockType { get; set; }
        public Stock Stock { get; set; }
        public Catalog Catalog { get; set; }
        public Supplier Supplier { get; set; }
    }
}