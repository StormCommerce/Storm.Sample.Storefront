using System;
using System.Collections.Generic;
using System.Text;
/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
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
        string Url { get; set; }
    }
}
