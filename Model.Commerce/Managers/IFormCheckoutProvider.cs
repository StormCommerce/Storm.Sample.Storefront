using Model.Commerce.Customer;
using Model.Commerce.Shopping;
using System.Threading.Tasks;

namespace Model.Commerce.Managers
{
    public interface IFormCheckoutProvider
    {
        Task<IPaymentResponse> PaymentForm(IUser currentUser, string basketId);
        Task<IPaymentResponse> PaymentComplete(string reference);
    }
}
