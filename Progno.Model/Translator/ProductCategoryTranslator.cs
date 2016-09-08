using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
    public class ProductCategoryTranslator: BaseTranslator<ProductCategory, PRODUCT_CATEGORY>
    {
        public override ProductCategory TranslateToModel(PRODUCT_CATEGORY entity)
        {
try
            {
                ProductCategory model = null;
                if (entity != null)
                {
                    model = new ProductCategory();
                    model.Id = entity.Category_Id;
                    model.Name = entity.Category_Name;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }        }

        public override PRODUCT_CATEGORY TranslateToEntity(ProductCategory model)
        {
            try
            {
                PRODUCT_CATEGORY entity = null;
                if (model != null)
                {
                    entity = new PRODUCT_CATEGORY();
                    entity.Category_Id = model.Id;
                    entity.Category_Name = model.Name;
                   }

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
        }
    }

