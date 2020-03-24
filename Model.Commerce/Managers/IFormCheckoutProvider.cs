using Model.Commerce.Customer;
using Model.Commerce.Shopping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Managers
{
    public interface IFormCheckoutProvider
    {
        IPaymentResponse PaymentForm(IUser currentUser, string basketId);
        IPaymentResponse PaymentComplete(string reference);
    }
}
