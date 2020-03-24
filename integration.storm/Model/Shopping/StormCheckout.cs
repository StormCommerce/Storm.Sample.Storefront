using Integration.Storm.Model.Customer;
using Model.Commerce.Customer;
using Model.Commerce.Shopping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Storm.Model.Shopping
{
    public class StormCheckout
    {
        public StormBasket Basket { get; set; }
        public StormCustomer Buyer { get; set; }
        public StormCustomer Payer { get; set; }
        public StormCustomer ShipTo { get; set; }
        public StormPaymentMethod[] PaymentMethods { get; set; }
        public StormDeliveryMethod[] DeliveryMethods { get; set; }
        public StormPayment[] Payments { get; set; }
    }
}
