using Model.Commerce.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Managers
{
    public interface IAccountManager
    {
        IUser Login(string username, string password);
        IUser FindById(string id);
    }
}
