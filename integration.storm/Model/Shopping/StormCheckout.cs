﻿using Integration.Storm.Model.Customer;

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
