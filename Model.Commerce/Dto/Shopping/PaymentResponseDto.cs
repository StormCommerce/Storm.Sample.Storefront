using Model.Commerce.Shopping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Dto.Shopping
{
    public class PaymentResponseDto : IPaymentResponse
    {
        public string Reference { get; set; }
        public string Html { get; set; }
    }
}
