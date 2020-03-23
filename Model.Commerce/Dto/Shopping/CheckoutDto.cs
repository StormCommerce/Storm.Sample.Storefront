using Model.Commerce.Customer;
using Model.Commerce.Shopping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Dto.Shopping
{
    public class CheckoutDto : ICheckout
    {
        public IBasket Basket { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICustomer Buyer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICustomer ShipTo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IPaymentMethod PaymentMethod { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDeliveryMethod DeliveryMethod { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
