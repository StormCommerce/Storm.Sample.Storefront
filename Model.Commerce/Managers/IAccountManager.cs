using Model.Commerce.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.Commerce.Managers
{
    public interface IAccountManager
    {
        Task<IUser> Login(string username, string password);
        Task<IUser> FindById(string id);
    }
}
