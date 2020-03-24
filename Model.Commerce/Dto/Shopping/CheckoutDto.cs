using Model.Commerce.Customer;
using Model.Commerce.Dto.Customer;
using Model.Commerce.Shopping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Dto.Shopping
{
    public class CheckoutDto : ICheckout
    {
        public BasketDto Basket { get; set; }
        public CustomerDto Buyer { get; set; }
        public CustomerDto ShipTo { get; set; }
        public CustomerDto Payer { get; set; }

        IBasket ICheckout.Basket { get => (IBasket)Basket; set => Basket = (BasketDto)value; }
        ICustomer ICheckout.Buyer { get => (ICustomer)Buyer; set => Buyer = (CustomerDto)value; }
        ICustomer ICheckout.ShipTo { get => (ICustomer)ShipTo; set => ShipTo = (CustomerDto)value; }
        ICustomer ICheckout.Payer { get => (ICustomer)Payer; set => Payer = (CustomerDto)value; }

        public IPaymentMethod PaymentMethod { get; set; }
        public IDeliveryMethod DeliveryMethod { get; set; }
        public List<IPaymentMethod> PaymentMethods { get; set; }
        public List<IDeliveryMethod> DeliveryMethods { get; set; }
    }
}
