using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progno.Model.Entity;
using Progno.Model.Model;

namespace Progno.Model.Translator
{
    public class PriceListTranslator : BaseTranslator<PriceList,PRICE_LIST>
    {
        private BarTranslator barTranslator;

        public PriceListTranslator()
        {
            barTranslator = new BarTranslator();
        }
        public override PriceList TranslateToModel(PRICE_LIST entity)
        {
            try
            {
                PriceList model = null;
                if (entity != null)
                {
                    model = new PriceList();
                    model.Id = entity.Price_List_Id;
                    model.NormalPrice = entity.Normal_Price;
                    model.HappyHourPrice = entity.Happy_Hour_Price;
                    model.Cost = entity.Cost;
                    model.Bar = barTranslator.Translate(entity.BAR);
                }
                return model;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override PRICE_LIST TranslateToEntity(PriceList model)
        {
            try
            {
                PRICE_LIST entity = null;
                if (model != null)
                {
                    entity = new PRICE_LIST();
                    entity.Price_List_Id = model.Id;
                    entity.Bar_Id = model.Bar.Id;
                    entity.Normal_Price = model.NormalPrice;
                    entity.Happy_Hour_Price = model.HappyHourPrice;
                    model.Cost = entity.Cost;
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
