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
    public interface IBasket
    {
        string ExternalId { get; set; }
        List<IBasketItem> Items { get; set; }
        decimal Total { get; set; }
        decimal TotalVat { get; set; }
        decimal TotalInclVat { get; set; }
        decimal Shipping { get; set; }
        decimal ShippingInclVat { get; set; }
        int NumberOfItems { get; set; }
    }
}
