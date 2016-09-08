using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
using System.Web.Mvc;
using Progno.Business;
using Progno.Model.Model;
using Progno.Web.Areas.Sales.ViewModel;
using Progno.Web.Models;
using System.Drawing;
using BarcodeLib;
using System.IO;


namespace Progno.Web.Areas.Sales.Controllers
{
    public class SalesController : BaseController
    {
        private SalesViewModel viewModel;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateOrder()
        {
            SalesViewModel vm = new SalesViewModel();
            try
            {
                //viewModel = new SalesViewModel();
                //SalesViewModel view = (SalesViewModel)TempData["RemovedOrders"];
                //SalesViewModel Vm = (SalesViewModel)Session["addtoCartSession"];
                HappyHourLogic happyHourLogic = new HappyHourLogic();
               
                vm.HappyHour = happyHourLogic.GetModelBy(x => x.Activated == true);
                PopulateDropDowns();
            }
            catch (Exception ex)
            {
                SetMessage("Error Occured! " + ex.Message, Message.Category.Error);
            }
            return View(vm);
        }
        [HttpPost]
        public ActionResult CreateOrder(string[] formDetails)
        
        {
            try
            {
                 int pId = Convert.ToInt32(formDetails[0]);
                int quantity = Convert.ToInt32(formDetails[1]);

                viewModel = new SalesViewModel();
                SalesViewModel view = (SalesViewModel)TempData["RemovedOrders"];
                SalesViewModel Vm = (SalesViewModel) Session["addtoCartSession"];
                ProductLogic productLogic = new ProductLogic();
                viewModel.Products = productLogic.GetAll();
                StockLogic stockLogic = new StockLogic();
                Stock stock = new Stock();
                HappyHourLogic happyHourLogic = new HappyHourLogic();
              
                if (pId != null && quantity != null)
                {
                    OrderLogic orderLogic = new OrderLogic();
                        Order order = new Order();
                        int count = 1;
                        Product product = productLogic.GetModelBy(x => x.Product_Id == pId);
                        stock = stockLogic.GetModelBy(x => x.Product_Id == product.Id);
                    if (stock==null)
                    {
                        SetMessage("Product no longer in stock. Check back later", Message.Category.Warning);
                        return PartialView("_ShoppingCart",Vm);  
                    }
                    if (stock.QuantityLeft==0 ||stock.QuantityLeft < quantity)
                    {
                        SetMessage("Quantity is more than Stock remaining", Message.Category.Warning);
                        return PartialView("_ShoppingCart", Vm);
                       
                    }
                        order.OrderNo = UniqueCode();
                        order.Product = product;
                        order.Quantity = quantity;
                        viewModel.HappyHour = happyHourLogic.GetModelBy(x => x.Activated == true);
                        if (viewModel.HappyHour!= null)
                        {
                            order.UnitPrice = product.HappyHourPrice;
                        }
                        else
                        {
                            order.UnitPrice = product.SellingPrice;
                        }
                        int amou = Convert.ToInt32(product.SellingPrice);
                        int? am = amou * quantity;
                        order.Amount = (decimal)am;
                        order.OrderTime = DateTime.Now.Date;
                        //orderLogic.Create(order);
                        if (view != null)
                        {
                            if (view.Orders != null && view.Orders.Count > 0)
                            {
                                if (order != null)
                                {
                                    view.Orders.Add(order);  
                                }
                                TempData["RemovedOrders"] = view;
                               return PartialView("_ShoppingCart", view);

                            }
                            else
                            {
                                TempData.Clear();
                            }
                        }
                        

                    if (quantity!=0 && quantity>0)
                    {
                        List<Order> orders = new List<Order>();
                        if (Vm != null)
                        {
                            if (Vm.Orders.Count > 0)
                            {
                                order.OrderNo = Vm.Orders[0].OrderNo;
  
                            }
                            Vm.Orders.Add(order); 
                            Session["addtoCartSession"] = Vm;
                            return PartialView("_ShoppingCart", Vm);  
                        }
                        viewModel.Order = order;
                        orders.Add(viewModel.Order);
                        viewModel.Orders= orders;
                        Session["addtoCartSession"] = viewModel;
                        return PartialView("_ShoppingCart", viewModel);
                    }
                    else
                    {
                        SetMessage("Quantity Cannot be Zero", Message.Category.Warning);
                        return PartialView("_ShoppingCart", viewModel);
 

                    }

                   
                  }
               

            }
            catch (Exception ex)
            {
                SetMessage("Error Occured! " + ex.Message,Message.Category.Error );
            }
            return View(viewModel);
        }

        private Customer newCustomer(Customer customer)
        {
            try
            {
                CustomerLogic customerLogic = new CustomerLogic();
                PersonLogic personLogic = new PersonLogic();
                Person person = new Person();
                Person customerPerson = new Person();
                Customer existCustomer = new Customer();
                Customer newCustomer = new Customer();
                Customer CreatedCustomer = new Customer();

                using (TransactionScope scope = new TransactionScope())
                {
                    existCustomer = customerLogic.GetModelBy(x => x.PERSON.First_Name == customer.FirstName &&
                                                             x.PERSON.Last_Name == customer.LastName &&
                                                             x.PERSON.Email == customer.Email);
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
                SetMessage("Error Occured!"+ ex.Message, Message.Category.Error);
                return null;
            }
           
        }

        private Customer existingCustomer(Customer customer)
        {
            try
            {
                Customer existCustomer = new Customer();
                Customer returnCustomer = new Customer();
                CustomerLogic customerLogic = new CustomerLogic();
                existCustomer = customerLogic.GetModelBy(x => x.Customer_Id == customer.CustomerId);
                if (existCustomer == null)
                {
                    SetMessage("Customer does not exist!", Message.Category.Error);
                    return null;   
                }
                return existCustomer;
                existCustomer.LastDateVisited = DateTime.Now.Date;
                existCustomer.TimesVisited = existCustomer.TimesVisited + 1;
                returnCustomer = customerLogic.Modify(existCustomer);

                return returnCustomer;
            }
            catch (Exception ex)
            {
                SetMessage("Error Occured!" + ex.Message, Message.Category.Error);
                return null;
            }
        }
        public ActionResult CheckedOut()
        {

            try
            {
                viewModel = (SalesViewModel)Session["addtoCartSession"];
                Order order = new Order();
                OrderLogic orderLogic = new OrderLogic();
                StockLogic stockLogic = new StockLogic();
                Stock stock = new Stock();
                SalesLogic salesLogic = new SalesLogic();
                Model.Model.Sales sales = new Model.Model.Sales();
                UserLogic userLogic = new UserLogic();
                Model.Model.User loggedInUser = userLogic.GetModelBy(x => x.User_Name == User.Identity.Name);
                Staff staff = new Staff();
                StaffLogic staffLogic = new StaffLogic();
                staff = staffLogic.GetModelBy(x => x.User_Id == loggedInUser.Id);
                bool ismodified = false;
                if (viewModel==null) 
                {
                  SetMessage("Cart is empty  ", Message.Category.Warning);
                    return RedirectToAction("CreateOrder");  
                   }
                if (viewModel.Orders.Count == 0)
                {
                    SetMessage("Cart is empty  ", Message.Category.Warning);
                    return RedirectToAction("CreateOrder");
                } 
                using (TransactionScope trans = new TransactionScope())
                {
                    for (int i = 0; i < viewModel.Orders.Count; i++)
                    {
                        Order createdOrder =new Order();
                        order = viewModel.Orders[i];
                        order.OrderNo = viewModel.Orders[0].OrderNo;
                        order.Checked = true;
                        createdOrder = orderLogic.Create(order);
                        stock = stockLogic.GetModelBy(x => x.Product_Id == order.Product.Id);
                        viewModel.Stock =new Stock();
                        viewModel.Stock.Id = stock.Id;
                        if (stock.QuantityLeft==0 || stock.QuantityLeft< 0) 
                        {
                            SetMessage("Quantity is more than Stock remaining: Remove some orders on  " + stock.Product.Name, Message.Category.Warning);
                            return RedirectToAction("CreateOrder", viewModel); 
                        }
                        int stockQty = stock.QuantityLeft;
                        int orderQty = (int)order.Quantity;
                        viewModel.Stock.QuantityLeft = stockQty - orderQty;
                        viewModel.Stock.Product = stock.Product;
                        viewModel.Stock.LastUpdate = DateTime.Now.Date;
                        ismodified = stockLogic.Modify(viewModel.Stock);
                        // create catalog register
                        sales.Order = createdOrder;
                        sales.TransactionDate = DateTime.Now;
                        sales.SalesType = new SalesType() {Id = 1};
                       sales.Staff = staff;
                        salesLogic.Create(sales);

                    }
                    trans.Complete();
                }
                BarcodeLib.Barcode barcode = new BarcodeLib.Barcode(viewModel.Orders[0].OrderNo, TYPE.CODE39);
                Image image = barcode.Encode(TYPE.CODE39, viewModel.Orders[0].OrderNo);
                byte[] imageByteData = imageToByteArray(image);
                string imageBase64Data = Convert.ToBase64String(imageByteData);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                viewModel.Orders[0].barcodeImageUrl = imageDataURL;
                TempData["OrderVoucher"] = viewModel;
                TempData.Keep();
            }
            catch (Exception ex)
            {
                SetMessage("Error Occured! " + ex.Message, Message.Category.Error);
                return RedirectToAction("CreateOrder");
            }
            PopulateDropDowns();
            return View(viewModel);

        }
        public ActionResult RemoveOrder(string[] formDetails)
        {
            SalesViewModel view = new SalesViewModel();
            try
            {
                if (formDetails == null)
                {
                    viewModel = (SalesViewModel)Session["addtoCartSession"];

                    return PartialView("_ShoppingCart", viewModel);  

                }
                long id = Convert.ToInt32(formDetails[0]);

                int pId = Convert.ToInt32(formDetails[0]);
                viewModel = (SalesViewModel)Session["addtoCartSession"];
                Order order = new Order();
                OrderLogic orderLogic = new OrderLogic();
                order = viewModel.Orders.Find(x=>x.Product.Id== pId);
                viewModel.Orders.Remove(order);
                TempData["RemovedOrders"] = viewModel;
                TempData.Keep();
                //SetMessage("Item removed",Message.Category.Information);
                return PartialView("_ShoppingCart", viewModel);

             //   return PartialView(, viewModel = view);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PartialView("_ShoppingCart", viewModel);
        }

        public ActionResult Reservation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Reservation(SalesViewModel viewModel)
        {
            try
            {
                ReservationLogic reservationLogic = new ReservationLogic();
                string orderno = viewModel.Reservation.ReservationCode;
                viewModel.Reservation = reservationLogic.GetModelBy(x => x.Reservation_Code.Replace(" ", "") == orderno.Replace(" ", ""));
                TempData["Reservation"] = viewModel;
                TempData.Keep();
            }
            catch (Exception ex)
            {
                SetMessage("Error Occured! " + ex.Message, Message.Category.Error);
            }
            return RedirectToAction("ReservationAction");
        }

        public ActionResult ReservationAction()
        {
            try
            {
                SalesViewModel vm = (SalesViewModel)TempData["Reservation"];
                if (vm.Reservation != null)
                {
                    return View(vm);
                }

            }
            catch (Exception ex)
            {
                SetMessage("Error Occured! " + ex.Message, Message.Category.Error);
            }
            return View();
        }
        [HttpPost]
        public ActionResult ReservationAction(SalesViewModel viewModel)
        {
            try
            {
                decimal? outstanding = new decimal();
                ReservationLogic reservationLogic = new ReservationLogic();
               

                bool isModified = reservationLogic.Modify(viewModel.Reservation);
                if (isModified == true)
                {
                    SetMessage("Operation Successful ", Message.Category.Information);
                    return RedirectToAction("Reservation");

                }

            }
            catch (Exception ex)
            {
                SetMessage("Error Occured! " + ex.Message, Message.Category.Error);
            }
            return View();
        }
        public ActionResult Payment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Payment(SalesViewModel viewModel)
        {
            try
            {
                PaymentLogic paymentLogic = new PaymentLogic();
                string orderno = viewModel.Payment.OrderNo;
                viewModel.Payment = paymentLogic.GetModelBy(x => x.Order_No.Replace(" ", "") == orderno.Replace(" ", ""));
                TempData["Payment"] = viewModel;
                TempData.Keep();
            }
            catch (Exception ex)
            {
              SetMessage("Error Occured! "+ ex.Message, Message.Category.Error);
            }
            return RedirectToAction("PaymentAction");
        }

        public ActionResult PaymentAction()
        {
            try
            {
                SalesViewModel vm = (SalesViewModel) TempData["Payment"];
                if (vm.Payment != null )
                {
                    return View(vm);
                }

            }
            catch (Exception ex)
            {
                SetMessage("Error Occured! " + ex.Message, Message.Category.Error);
            }
            return View();
        }
        [HttpPost]
        public ActionResult PaymentAction(SalesViewModel viewModel)
        {
            try
            {
                decimal? outstanding = new decimal();
                PaymentLogic paymentLogic = new PaymentLogic();
                viewModel.Payment.LastUpdateTime = DateTime.Now.Date;
                outstanding = viewModel.Payment.OutstandingAmount;
                if (viewModel.ClearPayment == outstanding)
                {
                    viewModel.Payment.Paid = true;
                    viewModel.Payment.OutstandingAmount = 0;
                    viewModel.Payment.PaymentType = new PaymentType() {Id = 1};
                }
                if (viewModel.ClearPayment > outstanding)
                {
                    SetMessage("Amount is more than debt owed ", Message.Category.Warning);
                    return View(viewModel);

                }
                if (viewModel.ClearPayment < outstanding)
                {
                    viewModel.Payment.OutstandingAmount = outstanding - viewModel.ClearPayment;
                }
               
                bool isModified = paymentLogic.Modify(viewModel.Payment);
                if (isModified== true)
                {
                    SetMessage("Operation Successful ", Message.Category.Information);
                    return RedirectToAction("Payment");

                }

             }
            catch (Exception ex)
            {
                SetMessage("Error Occured! " + ex.Message, Message.Category.Error);
            }
            return View();
        }
        public ActionResult OrderVoucher(SalesViewModel viewModel)
        {
             SalesViewModel vm = new SalesViewModel();
            try
            {
             vm = (SalesViewModel)TempData["OrderVoucher"];
                UserLogic userLogic = new UserLogic();
                Customer customer = new Customer();
                PaymentLogic paymentLogic = new PaymentLogic();
                Payment existPayment = new Payment();
                Payment newPayment = new Payment();
                User loggedInUser = userLogic.GetModelBy(x => x.User_Name == User.Identity.Name);
                vm.User = loggedInUser;
                Staff staff = new Staff();
                StaffLogic staffLogic = new StaffLogic();
                staff = staffLogic.GetModelBy(x => x.User_Id == loggedInUser.Id);

                using (TransactionScope scope = new TransactionScope()) 
                {
                
                
                vm.Business = new Model.Model.Business() {Id = 1};
                if (viewModel.OldCustomer != null)
                {
                    if (viewModel.OldCustomer != null)
                    {
                        customer = existingCustomer(viewModel.OldCustomer);
                    }

                    if (customer == null)
                    {
                        SetMessage("Customer does not exist", Message.Category.Warning);
                        return RedirectToAction("CheckedOut", vm);
                    }
                    vm.Customer = customer;
                    newPayment.Customer = vm.Customer;
                  for (int j = 0; j < vm.Orders.Count; j++)
                  {
                      //vm.Orders[j].TotalDiscount = vm.Orders[j].Amount * discount.PercentageOff;
                      //vm.GrossAmount = vm.Orders.Sum(x => x.Amount);
                      //vm.Orders[j].Amount = (vm.Orders[j].Amount) - (vm.Orders[j].Amount * discount.PercentageOff);
                      //vm.TotalAmount = vm.Orders.Sum(x => x.Amount);
                      //vm.TotalDiscount = vm.Orders.Sum(x => x.TotalDiscount);

                  }
                }
                else
                {
                    for (int j = 0; j < vm.Orders.Count; j++)
                    {
                        vm.Orders[j].TotalDiscount = 0;
                        vm.GrossAmount = vm.Orders.Sum(x=>x.Amount);
                        vm.Orders[j].Amount = vm.Orders[j].Amount;
                        vm.TotalAmount = vm.Orders.Sum(x => x.Amount);
                        vm.TotalDiscount = vm.Orders.Sum(x => x.TotalDiscount);
                    } 
                }
                string orderno = vm.Orders[0].OrderNo;
                existPayment = paymentLogic.GetModelBy(x => x.Order_No == orderno);
                if (existPayment == null  && viewModel.PaymentType != null)
                {
                    newPayment.Staff = vm.Staff;
                    newPayment.PaymentType = viewModel.PaymentType;
                    newPayment.Amount = vm.TotalAmount;
                    if (viewModel.Payment.AmountTendered != null && viewModel.PaymentType.Id !=1)
                    {
                        newPayment.AmountTendered = viewModel.Payment.AmountTendered;
                        newPayment.OutstandingAmount = vm.TotalAmount - viewModel.Payment.AmountTendered;
                        newPayment.ExpectedPaymentDate = viewModel.Payment.ExpectedPaymentDate;
                        newPayment.Paid = false;

                    }
                    else
                    {
                        newPayment.AmountTendered = vm.TotalAmount;
                        newPayment.OutstandingAmount = 0;
                        newPayment.Paid = true;
                        newPayment.ExpectedPaymentDate = null;
                     }

                    newPayment.OrderNo = vm.Orders[0].OrderNo;
                    newPayment.LastUpdateTime = DateTime.Now.Date;
                    vm.Payment = paymentLogic.Create(newPayment);
                    if (vm.Payment.ExpectedPaymentDate!= null)
                    {
                        DateTime myExpectedDate = (DateTime) vm.Payment.ExpectedPaymentDate;
                        vm.Payment.ExpectedPaymentDate = myExpectedDate;
   
                    }
                }
                    scope.Complete();
                }
               
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return View( vm);
        }
        private void PopulateDropDowns()
        {
           SalesViewModel view = new SalesViewModel();
           ViewBag.Units = view.UnitSelectList;
           ViewBag.ProductCategory = view.ProductCategorySelectList;
           ViewBag.Sex = view.SexSelectList;
            ViewBag.PaymentType = view.PaymentTypeSelectList;
            ViewBag.Products = new SelectList(new List<Product>(), "Id", "Name");
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
                string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZSNFIDHBADNAHSDIF67869546789654678DUGFEDNIUFDSNF87CAHSDH345678345678BFHFUYBFOYULDSKUYFB";
                OrderLogic orderLogic = new OrderLogic();
                string code = "";
                int check = 1;
                while (check != 0)
                {
                    code = Shuffle(str).Substring(0, 10).ToUpper();
                    check = orderLogic.GetEntitiesBy(x => x.Order_No == code).Count();
                }

                return code;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public JsonResult AutoCompleteSearch(string term)
        {
            try
            {
                ProductLogic productLogic = new ProductLogic();


                List<string> itemsSelectList = new List<string>();

                List<Product> items = productLogic.GetModelsBy(i => i.Product_Name.Contains(term));
                foreach (Product item in items)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = item.Id.ToString();
                    selectList.Text = item.Name;
                    itemsSelectList.Add(item.Name); 
                }

                //var searchResult = new[] {"apple", "oranges", "pines"};

                return Json(itemsSelectList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Search(string p)
        {
            string searchParameter = p;
            viewModel = new SalesViewModel();
            List<Product> productlist = new List<Product>();
            List<Product> productlistresult = new List<Product>();

            ProductLogic productLogic = new ProductLogic();
            try
            {
                HappyHourLogic happyHourLogic = new HappyHourLogic();
                viewModel.HappyHour = happyHourLogic.GetModelBy(x => x.Activated == true);
                productlist = productLogic.GetModelsBy(x => x.Barcode_No== p);
                foreach (Product product in productlist)
                {
                    if (viewModel.HappyHour!= null)
                    {
                        product.SellingPrice = (decimal)product.HappyHourPrice;
                    }
                    productlistresult.Add(product);
                }
                viewModel.Products = productlistresult;
                TempData["Search"] = viewModel;
            }
            catch (Exception ex)
            {
               SetMessage("Error Occured!"+ex.Message, Message.Category.Error);
            }
            return PartialView("_SearchResult", viewModel);

        }
        public JsonResult CategoryChangeForProduct(string id)
        {
            try
            {
                if (!id.Any())
                {
                    return null;
                }

                int CategoryId = Convert.ToInt32(id);
                ProductLogic productLogic = new ProductLogic();
                List<Product> products = new List<Product>();
                products = productLogic.GetModelsBy(x => x.Category_Id == CategoryId);
                List<SelectListItem> itemsSelectList = new List<SelectListItem>();

                foreach (var i in products)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = i.Id.ToString();
                    selectList.Text = i.Name;
                    itemsSelectList.Add(selectList); 
                }
                return Json(itemsSelectList, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        }
}