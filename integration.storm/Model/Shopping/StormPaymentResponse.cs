namespace Integration.Storm.Model.Shopping
{
    public class StormPaymentResponse
    {
        public string Status { get; set; }
        public string StatusDescription { get; set; }
        public int? BasketId { get; set; }
        public string OrderNo { get; set; }
        public string PaymentCode { get; set; }
        public string PaymentReference { get; set; }
        public string RedirectUrl { get; set; }
    }
}
