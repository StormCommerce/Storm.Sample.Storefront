using Model.Commerce.Customer;
using Model.Commerce.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Managers
{
    public interface ICategoryManager
    {
        IList<ICategory> FindAll(IUser currentUser);
    }
}
