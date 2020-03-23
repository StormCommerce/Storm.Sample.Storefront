using Model.Commerce.Customer;
using Model.Commerce.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Managers
{
    public interface IApplicationManager
    {
        List<IManufacturer> FindAllManufacturers(IUser currentUser);
        List<IAttribute> FindAllParametricsWithValues(IUser currentUser);


    }
}
