using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Shopping
{
    public interface IBasketItem
    {
        string ExternalId { get; set; }
        string PartNo { get; set; }
        string Name { get; set; }
        string ImageUrl { get; set; }
        decimal Price { get; set; }
        decimal? PricePrevious { get; set; }
        decimal VatRate { get; set; }
        decimal Quantity { get; set; }
    }
}
