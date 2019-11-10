using Model.Commerce.Extensions;
using Model.Commerce.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Storm.Extensions
{
    public class DefaultBuyableExtension : IBuyableExtension
    {
        public bool Buyable(IProduct product, IVariant variant)
        {
            return true;
        }

        public string StockStatus(IProduct product, IVariant variant)
        {
            return "I lager";
        }
    }
}
