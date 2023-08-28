using Model.Commerce.Shopping;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
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
        public string Url { get; set; }
    }
}
