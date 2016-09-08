using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Progno.Business;
using Progno.Model.Model;

namespace Progno.Web.Models
{
    public class Utility
    {
        public const string ID = "Id";
        public const string NAME = "Name";
        public const string Reg_No = "RegNo";
        public const string VALUE = "Value";
        public const string TEXT = "Text";
        public const string Select = "-- Select --";
        public const string SelectReservationType = "-- Select ReservationType--";
        public static List<SelectListItem> PopulateRoleSelectListItem()
        {
            try
            {
                RoleLogic roleLogic = new RoleLogic();
                List<Role> roles = roleLogic.GetAll();
                if (roles == null || roles.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> roleList = new List<SelectListItem>();
                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = Select;
                roleList.Add(list);
                foreach (Role role in roles)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = role.Id.ToString();
                    selectList.Text = role.Name;

                    roleList.Add(selectList);
                }

                return roleList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateSexSelectListItem()
        {
            try
            {
                SexLogic sexLogic = new SexLogic();
                List<Sex> sexs = sexLogic.GetAll();
                if (sexs == null || sexs.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> sexList = new List<SelectListItem>();
                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = Select;
                sexList.Add(list);
                foreach (Sex sex in sexs)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = sex.Id.ToString();
                    selectList.Text = sex.Name;

                    sexList.Add(selectList);
                }

                return sexList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateSalarySchemeListItem()
        {
            try
            {
                SalarySchemeLogic salarySchemeLogic = new SalarySchemeLogic();
                List<SalaryScheme> salarySchemes = salarySchemeLogic.GetAll();
                if (salarySchemes == null || salarySchemes.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> sexList = new List<SelectListItem>();
                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = Select;
                sexList.Add(list);
                foreach (SalaryScheme salary in salarySchemes)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = salary.Id.ToString();
                    selectList.Text = salary.Role.Name;

                    sexList.Add(selectList);
                }

                return sexList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<SelectListItem> PopulateReligionSelectListItem()
        {
            try
            {
                ReligionLogic religionLogic = new ReligionLogic();
                List<Religion> religions = religionLogic.GetAll();
                if (religions == null || religions.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> religionList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = Select;
                religionList.Add(list);

                foreach (Religion religion in religions)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = religion.Id.ToString();
                    selectList.Text = religion.Name;

                    religionList.Add(selectList);
                }

                return religionList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateStateSelectListItem()
        {
            try
            {
                StateLogic stateLogic = new StateLogic();
                List<State> states = stateLogic.GetAll();
                if (states == null || states.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> stateList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = Select;
                stateList.Add(list);

                foreach (State state in states)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = state.Id;
                    selectList.Text = state.Name;

                    stateList.Add(selectList);
                }

                return stateList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateSupplierSelectListItem()
        {
            try
            {
                SupplierLogic supplierLogic = new SupplierLogic();
                List<Supplier> suppliers = supplierLogic.GetAll();
                if (suppliers == null || suppliers.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> stateList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = "---select supplier--";
                stateList.Add(list);

                foreach (Supplier supplier in suppliers)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = supplier.Id.ToString();
                    selectList.Text = supplier.CompanyName+"----"+ supplier.Name;

                    stateList.Add(selectList);
                }

                return stateList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<SelectListItem> PopulateLocalGovernmentSelectListItem()
        {
            try
            {
                LocalGovernmentLogic localGovernmentLogic = new LocalGovernmentLogic();
                List<LocalGovernment> lgas = localGovernmentLogic.GetAll();

                if (lgas == null || lgas.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> stateList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = Select;
                stateList.Add(list);

                foreach (LocalGovernment lga in lgas)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = lga.Id.ToString();
                    selectList.Text = lga.Name;

                    stateList.Add(selectList);
                }

                return stateList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateLocalGovernmentSelectListItemByStateId(string id)
        {
            try
            {
                LocalGovernmentLogic localGovernmentLogic = new LocalGovernmentLogic();
                List<LocalGovernment> lgas = localGovernmentLogic.GetModelsBy(l => l.State_Id == id);

                if (lgas == null || lgas.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> stateList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = Select;
                stateList.Add(list);

                foreach (LocalGovernment lga in lgas)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = lga.Id.ToString();
                    selectList.Text = lga.Name;

                    stateList.Add(selectList);
                }

                return stateList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateCountrySelectListItem()
        {
            try
            {
                CountryLogic countryLogic = new CountryLogic();
                List<Country> countries = countryLogic.GetAll();
                if (countries == null || countries.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> countryList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = Select;
                countryList.Add(list);

                foreach (Country country in countries)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = country.Id.ToString();
                    selectList.Text = country.Name;

                    countryList.Add(selectList);
                }

                return countryList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateNationalitySelectListItem()
        {
            try
            {
                NationalityLogic nationalityLogic = new NationalityLogic();
                List<Nationality> nationalities = nationalityLogic.GetAll();
                if (nationalities == null || nationalities.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> NationalityList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = Select;
                NationalityList.Add(list);

                foreach (Nationality nationality in nationalities)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = nationality.Id.ToString();
                    selectList.Text = nationality.Name;

                    NationalityList.Add(selectList);
                }

                return NationalityList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateProductsSelectListItem()
        {
            try
            {
                ProductLogic productLogic = new ProductLogic();
                List<Product> products = productLogic.GetAll();
                if (products == null || products.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> ProductList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = Select;
                ProductList.Add(list);

                foreach (Product product in products)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = product.Id.ToString();
                    selectList.Text = product.Name;

                    ProductList.Add(selectList);
                }

                return ProductList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateUnitsSelectListItem()
        {
            try
            {
                UnitLogic unitLogic = new UnitLogic();
                List<Unit> units = unitLogic.GetAll();
                if (units == null || units.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> unitList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = Select;
                unitList.Add(list);

                foreach (Unit unit in units)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = unit.Id.ToString();
                    selectList.Text = unit.Name;

                    unitList.Add(selectList);
                }

                return unitList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateReservationTypeSelectListItem()
        {
            try
            {
                ReservationTypeLogic reservationTypeLogic = new ReservationTypeLogic();
                List<ReservationType> reservationTypes = reservationTypeLogic.GetAll();
                if (reservationTypes == null || reservationTypes.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> ReservationTypeList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = SelectReservationType;
                ReservationTypeList.Add(list);

                foreach (ReservationType reservationType in reservationTypes)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = reservationType.Id.ToString();
                    selectList.Text = reservationType.Name;

                    ReservationTypeList.Add(selectList);
                }

                return ReservationTypeList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<SelectListItem> PopulateStockTypeSelectListItem()
        {
            try
            {
                StockTypeLogic stockTypeLogic = new StockTypeLogic();
                List<StockType> stockTypes = stockTypeLogic.GetAll();
                if (stockTypes == null || stockTypes.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> stocktypeList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = Select;
                stocktypeList.Add(list);

                foreach (StockType stockType in stockTypes)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = stockType.Id.ToString();
                    selectList.Text = stockType.Name;

                    stocktypeList.Add(selectList);
                }

                return stocktypeList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulatePaymentTypeSelectListItem()
        {
            try
            {
                PaymentTypeLogic paymentTypeLogic = new PaymentTypeLogic();
                List<PaymentType> paymentTypes = paymentTypeLogic.GetAll();
                if (paymentTypes == null || paymentTypes.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> spaymenttypeList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = Select;
                spaymenttypeList.Add(list);

                foreach (PaymentType paymentType in paymentTypes)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = paymentType.Id.ToString();
                    selectList.Text = paymentType.Name;

                    spaymenttypeList.Add(selectList);
                }

                return spaymenttypeList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateSalesOfficerSelectListItem()
        {
            try
            {
                UserLogic userLogic = new UserLogic();
                List<User> users = userLogic.GetModelsBy(x=>x.Role_Id==4);
                if (users == null || users.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> spaymenttypeList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = Select;
                spaymenttypeList.Add(list);

                foreach (User user in users)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = user.Id.ToString();
                    selectList.Text = user.Person.FullName;

                    spaymenttypeList.Add(selectList);
                }

                return spaymenttypeList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateStaffSelectListItem()
        {
            try
            {
                UserLogic userLogic = new UserLogic();
                List<User> users = userLogic.GetModelsBy(x => x.Role_Id == 4);
                if (users == null || users.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> spaymenttypeList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = Select;
                spaymenttypeList.Add(list);

                foreach (User user in users)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = user.Id.ToString();
                    selectList.Text = user.Person.FullName;

                    spaymenttypeList.Add(selectList);
                }

                return spaymenttypeList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<SelectListItem> PopulateProductCategorySelectListItem()
        {
            try
            {
                ProductCategoryLogic productCategoryLogic = new ProductCategoryLogic();
                List<ProductCategory> productCategories = productCategoryLogic.GetAll();
                if (productCategories == null || productCategories.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> ProductList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = Select;
                ProductList.Add(list);

                foreach (ProductCategory productCategory in productCategories)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = productCategory.Id.ToString();
                    selectList.Text = productCategory.Name;

                    ProductList.Add(selectList);
                }

                return ProductList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateProductsByCategory(ProductCategory category)
        {
            try
            {
                ProductLogic productLogic = new ProductLogic();
                List<Product> products = productLogic.GetModelsBy(x=>x.Category_Id== category.Id);
                if (products == null || products.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> ProductList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = Select;
                ProductList.Add(list);

                foreach (Product product in products)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = product.Id.ToString();
                    selectList.Text = product.Name;

                    ProductList.Add(selectList);
                }

                return ProductList;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}