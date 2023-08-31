using Model.Commerce.Shopping;
using System.Collections.Generic;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
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
