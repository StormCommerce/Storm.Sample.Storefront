using Model.Commerce.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Extensions
{
    public interface IBuyableExtension
    {
        string StockStatus(IProduct product, IVariant variant);
        bool Buyable(IProduct product, IVariant variant);
    }
}
