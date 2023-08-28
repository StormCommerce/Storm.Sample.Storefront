using Model.Commerce.Customer;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Storefront.Models
{
    public interface ISessionModel
    {
        IUser CurrentUser { get; set; }
        string CurrentBasketId { get; set; }
        string CurrentCheckoutId { get; set; }
    }
}
