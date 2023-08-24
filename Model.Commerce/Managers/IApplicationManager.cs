using Model.Commerce.Customer;
using Model.Commerce.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.Commerce.Managers
{
    public interface IApplicationManager
    {
        Task<List<IManufacturer>>  FindAllManufacturers(IUser currentUser);
        Task<List<IAttribute>> FindAllParametricsWithValues(IUser currentUser);


    }
}
