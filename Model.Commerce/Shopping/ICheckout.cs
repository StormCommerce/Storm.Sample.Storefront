using Model.Commerce.Customer;
using System.Collections.Generic;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Model.Commerce.Shopping
{

    public interface ICheckout
    {
        IBasket Basket { get; set; }
        ICustomer Buyer { get; set; }
        ICustomer ShipTo { get; set; }
        ICustomer Payer { get; set; }
        IPaymentMethod PaymentMethod { get; set; }
        IDeliveryMethod DeliveryMethod { get; set; }
        List<IPaymentMethod> PaymentMethods { get; set; }
        List<IDeliveryMethod> DeliveryMethods { get; set; }
    }
}
