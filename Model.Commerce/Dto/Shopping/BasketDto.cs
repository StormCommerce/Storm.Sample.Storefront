using Model.Commerce.Shopping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Dto.Shopping
{
    public class BasketDto : IBasket
    {
        public string ExternalId { get; set; }
        public List<IBasketItem> Items { get; set; }
        public decimal Total { get; set; }
        public decimal TotalVat { get; set; }
        public decimal TotalInclVat { get; set; }
        public decimal Shipping { get; set; }
        public decimal ShippingInclVat { get; set; }
        public int NumberOfItems { get; set; }
    }
}
