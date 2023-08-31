using Model.Commerce.Shopping;

namespace Model.Commerce.Dto.Shopping
{
    public class PaymentResponseDto : IPaymentResponse
    {
        public string Reference { get; set; }
        public string Html { get; set; }
        public string FormCheckoutProvider { get; set; }
    }
}
