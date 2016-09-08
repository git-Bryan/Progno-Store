using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Progno.Model.Model;
using Progno.Web.Models;

namespace Progno.Web.Areas.Sales.ViewModel
{
    public class SalesViewModel
    {
        public SalesViewModel()
        {
            UnitSelectList = Utility.PopulateUnitsSelectListItem();
            ProductCategorySelectList = Utility.PopulateProductCategorySelectListItem();
            ProductSelectList = Utility.PopulateProductsSelectListItem();
            SexSelectList = Utility.PopulateSexSelectListItem();
            PaymentTypeSelectList = Utility.PopulatePaymentTypeSelectListItem();
            ReservationTypeSelectList = Utility.PopulateReservationTypeSelectListItem();
        }
        public List<SelectListItem> ReservationTypeSelectList { get; set; }
        public List<SelectListItem> SexSelectList { get; set; }
        public List<SelectListItem> PaymentTypeSelectList { get; set; }

        public List<SelectListItem> UnitSelectList { get; set; }
        public List<SelectListItem> ProductSelectList { get; set; }

        public List<SelectListItem> ProductCategorySelectList { get; set; }
        public Order Order { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
         [RegularExpression("^[1-100]{3}$", ErrorMessage = "Not valid. It must be between 1-100")]
        public int Quantity { get; set; }

        public Staff Staff { get; set; }
        public decimal ClearPayment { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal GrossAmount { get; set; }
        public Payment Payment { get; set; }
        public decimal TotalDiscount { get; set; }
        public PaymentType PaymentType { get; set; }
        public Discount Discount { get; set; }
        public Customer Customer { get; set; }
        public Customer NewCustomer { get; set; }
        public Customer OldCustomer { get; set; }
        public Model.Model.Business Business { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public Unit Unit { get; set; }
        public Stock Stock { get; set; }
        public Catalog Catalog { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
        public HappyHour HappyHour { get; set; }
        public Reservation Reservation { get; set; }
        public class ProductOrder
        {
            public string  ProductName { get; set; }
            public string SellinPrice { get; set; }
            public string Quantity { get; set; }
            public string Amount { get; set; }
        }
    }
}