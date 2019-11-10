using Model.Commerce.Shopping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Dto.Shopping
{
    public class BasketItemDto : IBasketItem
    {
        public string ExternalId { get; set; }
        public string PartNo { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal? PricePrevious { get; set; }
        public decimal VatRate { get; set; }
        public decimal Quantity { get; set; }
    }
}
