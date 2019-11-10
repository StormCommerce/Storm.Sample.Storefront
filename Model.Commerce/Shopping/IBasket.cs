using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Shopping
{
    public interface IBasket
    {
        string ExternalId { get; set; }
        List<IBasketItem> Items { get; set; }
        decimal Total { get; set; }
        decimal TotalVat { get; set; }
        decimal TotalInclVat { get; set; }
        decimal Shipping { get; set; }
        decimal ShippingInclVat { get; set; }
    }
}
