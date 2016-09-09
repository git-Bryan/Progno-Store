using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using Progno.Business;
using Progno.Model.Model;
using Progno.Web.Areas.Admin.ViewModel;
using Message = Progno.Model.Model.Message;

namespace Progno.Web.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        ProductViewModel viewModel = new ProductViewModel();
        public ActionResult AddProduct()
        {
            try
            {
        PopulateDropDowns();
            }
            catch (Exception ex)
            {
              SetMessage("Error Occured! "+ex.Message, Message.Category.Error);
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(ProductViewModel  viewModel)
        {
            try
            {
            ProductLogic productLogic = new ProductLogic();
            ProductCategoryLogic productCategoryLogic = new ProductCategoryLogic();
            using (TransactionScope trans = new TransactionScope())
                {
                    if (Request.Files[0].ContentLength > 0)
                    {
                        HttpPostedFileBase hpf = Request.Files[0] as HttpPostedFileBase;
                        string pathForSaving = Server.MapPath("~/Images/Products");
                        string savedFileName = Path.Combine(pathForSaving, hpf.FileName);
                        string[] getExtension = hpf.FileName.Split('.');
                        string extension = "." + getExtension[1];
                        string invalidImage = InvalidFile(Request.Files[0].ContentLength, extension);
                        if (string.IsNullOrEmpty(invalidImage))
                        {
                            hpf.SaveAs(savedFileName);
                            viewModel.Product.PhotoUrl = "/Images/Products/" + hpf.FileName;
                        }
                        else
                        {
                            SetMessage(invalidImage, Message.Category.Error);
                        }
                    }
                    List<Product> existingProducts = productLogic.GetModelsBy(x => x.Product_Name.ToUpper().Replace(" ", "").ToUpper() ==
                                                                             viewModel.Product.Name.ToUpper().Replace(" ", "").ToUpper());
                    if (viewModel.ProductCategory != null && viewModel.ProductCategory.Name != null) 
                    {
                        List<ProductCategory> existingcategory = productCategoryLogic.GetModelsBy(x => x.Category_Name.ToUpper().Replace(" ", "").ToUpper() ==
                                                                                  viewModel.ProductCategory.Name.ToUpper().Replace(" ", "").ToUpper());
                        if (existingcategory.Count > 0)
                        {
                            SetMessage("Category Already exists", Message.Category.Warning);
                            return RedirectToAction("AddProduct");

                        }
                        viewModel.ProductCategory.Name = viewModel.ProductCategory.Name.Replace(" ", "");
                       ProductCategory category = productCategoryLogic.Create(viewModel.ProductCategory);
                        viewModel.Product.Category = category;
                    }
                    
                    if (existingProducts.Count>0)
                    {
                        SetMessage("Product Already exists", Message.Category.Warning);
                        return RedirectToAction("AddProduct");

                    }
                    viewModel.Product.Name = viewModel.Product.Name.Replace(" ", "");
                    if (viewModel.Product.BarCode == null)
                    {
                        viewModel.Product.BarCode = UniqueCode();
                    }
                    else
                    {
                        List<Product> barcodes = new List<Product>();
                        barcodes = productLogic.GetModelsBy(x => x.Barcode_No == viewModel.Product.BarCode);
                        if (barcodes.Count> 0)
                        {
                            SetMessage("Product with same barcode exists", Message.Category.Warning);
                            return RedirectToAction("AddProduct"); 
                        }
                    }
                   productLogic.Create(viewModel.Product);
                     trans.Complete();
                   SetMessage("Operation Successful", Message.Category.Information);
                }
            }
            catch (Exception ex)
            {
               SetMessage("Error Occured! "+ex.Message, Message.Category.Error);
            }
            return RedirectToAction("AddProduct");
        }
        public ActionResult EditProductPage()
        {
            try
            {
                
                PopulateDropDowns();
               
            }
            catch (Exception ex)
            {
SetMessage("Error Occured!"+ex.Message, Message.Category.Error);
            }
            return View();
        }
        [HttpPost]
        public ActionResult EditProduct(ProductViewModel viewModel)
        {
            try
            {
               
                Product product = new Product();
                ProductLogic productLogic = new ProductLogic();
                product = productLogic.GetModelBy(x => x.Product_Id == viewModel.Product.Id);
                viewModel.Product = product;
                PopulateDropDowns(); 
                
            }
            catch (Exception ex)
            {
                SetMessage("Error Occured! " + ex.Message, Message.Category.Error);

            }
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult EditProductAction(ProductViewModel viewModel)
        {
            try
            {
                ProductLogic productLogic = new ProductLogic();
                Product product = new Product();
                using (TransactionScope trans = new TransactionScope())
                {
                    if (Request.Files[0].ContentLength > 0)
                    {
                        HttpPostedFileBase hpf = Request.Files[0] as HttpPostedFileBase;
                        string pathForSaving = Server.MapPath("~/Images/Products");
                        string savedFileName = Path.Combine(pathForSaving, hpf.FileName);
                        string[] getExtension = hpf.FileName.Split('.');
                        string extension = "." + getExtension[1];
                        string invalidImage = InvalidFile(Request.Files[0].ContentLength, extension);
                        if (string.IsNullOrEmpty(invalidImage))
                        {
                            hpf.SaveAs(savedFileName);
                            viewModel.Product.PhotoUrl = "/Images/Products/" + hpf.FileName;
                        }
                        else
                        {
                            SetMessage(invalidImage, Message.Category.Error);
                        }
                    }
                   bool ismodified = productLogic.ModifyProduct(viewModel.Product);
                    if (ismodified==true)
                    {
                        SetMessage("Operation Successful", Message.Category.Information);
                        trans.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Replace(" ","").ToUpper()=="NOITEMMODIFIED") 
                {
                    SetMessage( ex.Message, Message.Category.Warning);
                    return RedirectToAction("EditProductPage");

                }
                SetMessage("Error Occured! " + ex.Message, Message.Category.Error);
            }
            return RedirectToAction("EditProductPage");
        }

        public ActionResult StockProduct()
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
        [HttpPost]
        //public ActionResult StockProduct(ProductViewModel viewModel)
        //{
        //    try
        //    {
        //    StockLogic stockLogic = new StockLogic();
        //    Stock stock = new Stock();
        //    CatalogLogic catalogLogic = new CatalogLogic();
        //    Catalog catalog = new Catalog();
        //    UserLogic userLogic = new UserLogic();
        //        Supplier supplier = new Supplier();
        //        SupplierLogic supplierLogic = new SupplierLogic();
        //    Staff staff = new Staff();
        //        StaffLogic staffLogic = new StaffLogic();
        //        Model.Model.User loggedInUser = userLogic.GetModelBy(x => x.User_Name == User.Identity.Name);
        //        staff = staffLogic.GetModelBy(x => x.User_Id == loggedInUser.Id);
        //    bool ismodified = false;

        //        using (TransactionScope trans = new TransactionScope())
        //        {
        //            if (viewModel.Catalog == null)
        //            {
        //                supplier = supplierLogic.Create(viewModel.Supplier);
        //                catalog.Supplier = supplier;
        //            }
        //            stock = stockLogic.GetModelBy(x => x.Product_Id == viewModel.Stock.Product.Id);
        //            if (stock!= null)
        //            {
        //                viewModel.Stock.Id = stock.Id;
        //                int Quantity = viewModel.Stock.QuantityLeft;
        //                if (viewModel.StockType.Id == 1)
        //                {
        //                    viewModel.Stock.QuantityLeft = viewModel.Stock.QuantityLeft + stock.QuantityLeft;
        //                }
        //                if (viewModel.StockType.Id == 2)
        //                {
        //                    if (stock.QuantityLeft==0 || viewModel.Stock.QuantityLeft > stock.QuantityLeft)
        //                    {
        //                        SetMessage("Quantity is more than stock remaining." +"STOCK REMAINING:" +stock.QuantityLeft, Message.Category.Warning);
        //                        return RedirectToAction("StockProduct");

        //                    }
        //                    viewModel.Stock.QuantityLeft = stock.QuantityLeft - viewModel.Stock.QuantityLeft;
        //                }
        //                viewModel.Stock.LastUpdate = DateTime.Now.Date;
        //                ismodified = stockLogic.Modify(viewModel.Stock);
        //                // create catalog register
        //                catalog.Product = viewModel.Stock.Product;
        //                catalog.TransactionDate = DateTime.Now;
        //                catalog.StockType = viewModel.StockType;
        //                catalog.Quantity = Quantity;
        //                catalog.Staff = staff;
        //                catalogLogic.Create(catalog);
        //                if (ismodified == true)
        //                {
        //                    SetMessage("Stock Successfully Updated", Message.Category.Information);
        //                }
        //                else if (ismodified == false)
        //                {
        //                    SetMessage("Error occured", Message.Category.Error);

        //                }
        //            }
        //            else if(stock == null)
        //            {
                        
        //                if (viewModel.StockType.Id == 2)
        //                {
        //                    SetMessage("Product does not exist in stock!", Message.Category.Warning);
        //                    return RedirectToAction("StockProduct");

        //                }
        //                else if (viewModel.StockType.Id == 1)
        //                {
        //                    viewModel.Stock.LastUpdate = DateTime.Now.Date;
        //                    stockLogic.Create(viewModel.Stock);
        //                    // create catalog register
        //                    catalog.Product = viewModel.Stock.Product;
        //                    catalog.TransactionDate = DateTime.Now;
        //                    catalog.StockType = viewModel.StockType;
        //                    catalog.Quantity = viewModel.Stock.QuantityLeft;
        //                    catalog.Staff = staff;
        //                    catalogLogic.Create(catalog);

        //                    SetMessage("Stock Created Successfully!", Message.Category.Information);

        //                }
                         
        //            }

        //            trans.Complete();
                    
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //     SetMessage("Error Occured! "+ ex.Message,Message.Category.Error);
        //    }
        //    return RedirectToAction("StockProduct");
        //}
        private void PopulateDropDowns()
        {
            viewModel = new ProductViewModel();
            ViewBag.Units = viewModel.UnitSelectList;
            ViewBag.ProductCategory = viewModel.ProductCategorySelectList;
            ViewBag.StockType = viewModel.StockTypeSelectList;
            ViewBag.Products = new SelectList(new List<Product>(), "Id", "Name");
            ViewBag.Supplier = viewModel.SupplierSelectList;
        }

        private string InvalidFile(decimal uploadedFileSize, string fileExtension)
        {
            try
            {
                string message = null;
                decimal oneKiloByte = 1024;
                decimal maximumFileSize = 1000 * oneKiloByte;

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

        public JsonResult LoadCategory()
        {
            try
            {
                ProductCategoryLogic categoryLogic = new ProductCategoryLogic();
                List<ProductCategory> categories = new List<ProductCategory>();
                categories = categoryLogic.GetAll();
                List<SelectListItem> itemsSelectList = new List<SelectListItem>();

                foreach (var i in categories)
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
        public JsonResult LoadSupplier()
        {
            try
            {
                SupplierLogic supplierLogic = new SupplierLogic();
                List<Supplier> categories = new List<Supplier>();
                categories = supplierLogic.GetAll();
                List<SelectListItem> itemsSelectList = new List<SelectListItem>();

                foreach (var i in categories)
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
                string str = "0123456789ABCDEFGHIJKLMNPQRSTUVWXYZ987654321";
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
        public ActionResult StockList()
        {
            try
            {
            viewModel = new ProductViewModel();
            StockLogic stockLogic = new StockLogic();
            viewModel.StockLists = stockLogic.GetAllStock();
                TempData["Stockreport"] = viewModel.StockLists;
                return View(viewModel);
            }
            catch (Exception ex)
            {
              SetMessage("Error occured! "+ex.Message, Message.Category.Error);
            }
            return View();
        }
        public ActionResult DownloadStockList()
        {
            try
            {
                TempData.Keep();
                List<StockList> stockList = (List<StockList>)TempData["Stockreport"];
                TempData.Keep();
                GridView gv = new GridView();
                if (stockList.Count > 0)
                {
                    gv.DataSource = stockList;
                    gv.DataBind();
                    return new DownloadFileAction(gv, "Stock report.xls");
                }
                else
                {
                    Response.Write("No data available for download");
                    Response.End();
                    return new JavaScriptResult();
                }

            }
            catch (Exception ex)
            {
                SetMessage("Error occurred! " + ex.Message, Message.Category.Error);
                return RedirectToAction("StockList");
            }

        }
        public ActionResult PaymentList()
        {
            try
            {
                viewModel = new ProductViewModel();
                PaymentLogic paymentLogic= new PaymentLogic();
                viewModel.PaymentLists = paymentLogic.GetAllPayments();
                TempData["Payment"] = viewModel.PaymentLists;
                return View(viewModel);
            }
            catch (Exception ex)
            {
                SetMessage("Error occured! " + ex.Message, Message.Category.Error);
            }
            return View();
        }

        public ActionResult ActivityList()
        {
            try
            {
                viewModel = new ProductViewModel();
                CatalogLogic catalogLogic = new CatalogLogic();
                viewModel.ActivityLogs = catalogLogic.GetAllActivity();
                TempData["ActivityList"] = viewModel.ActivityLogs;
                return View(viewModel);
            }
            catch (Exception ex)
            {
                SetMessage("Error occured! " + ex.Message, Message.Category.Error);
            }
            return View();
        }
        public ActionResult DownloadActivityList()
        {
            try
            {
                TempData.Keep();
                List<ActivityLog> activityLogs = (List<ActivityLog>)TempData["ActivityList"];
                TempData.Keep();
                GridView gv = new GridView();
                if (activityLogs.Count > 0)
                {
                    gv.DataSource = activityLogs;
                    gv.DataBind();
                    return new DownloadFileAction(gv, "Catalog.xls");
                }
                else
                {
                    Response.Write("No data available for download");
                    Response.End();
                    return new JavaScriptResult();
                }

            }
            catch (Exception ex)
            {
                SetMessage("Error occurred! " + ex.Message, Message.Category.Error);
                return RedirectToAction("StockList");
            }

        }

        public ActionResult Reports()
        {
            return View();
        }
    }
}