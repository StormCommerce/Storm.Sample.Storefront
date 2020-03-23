using Model.Commerce.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Shopping
{
    public interface ICheckout
    {
        IBasket Basket { get; set; }
        ICustomer Buyer { get; set; }
        ICustomer ShipTo { get; set; }
        IPaymentMethod PaymentMethod { get; set; }
        IDeliveryMethod DeliveryMethod { get; set; }
    }
}
