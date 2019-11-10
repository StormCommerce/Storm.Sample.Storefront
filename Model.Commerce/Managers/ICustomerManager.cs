using Model.Commerce.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Managers
{
    public interface ICustomerManager
    {
        IUser FindByEmail(string email);
        IUser Login(string email, string password);
    }
}
