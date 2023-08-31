using Model.Commerce.Customer;
using Model.Commerce.Shopping;
using System.Threading.Tasks;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Model.Commerce.Managers
{
    public interface ICheckoutManager
    {
        Task<ICheckout> GetCheckout(IUser currentUser, string basketExternalId);
        Task<ICheckout> SetDeliveryMethod(IUser currentUser, string basketExternalId, string deliveryMethodId);
        Task<IPaymentResponse> PaymentForm(IUser currentUser, string basketId);
        Task<IPaymentResponse> PaymentComplete(string reference);
    }
}
