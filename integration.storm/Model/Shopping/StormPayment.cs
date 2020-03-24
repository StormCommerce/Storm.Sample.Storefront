using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Storm.Model.Shopping
{
    public class StormPayment
    {
        public int PaymentCode { get; set; }
        public decimal Amount { get; set; }
        public string CardNo { get; set; }
        public int PaymentMethodId { get; set; }
        public int PaymentServiceId { get; set; }
    }
}
