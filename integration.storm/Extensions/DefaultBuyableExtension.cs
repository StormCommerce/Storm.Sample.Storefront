using Model.Commerce.Extensions;
using Model.Commerce.Product;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
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
