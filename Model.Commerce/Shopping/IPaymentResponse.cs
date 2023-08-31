namespace Model.Commerce.Shopping
{
    public interface IPaymentResponse
    {
        string Reference { get; set; }
        string Html { get; set; }
        string FormCheckoutProvider { get; set; }
    }
}
