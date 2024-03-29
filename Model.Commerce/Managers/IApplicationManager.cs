﻿using Model.Commerce.Customer;
using Model.Commerce.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Model.Commerce.Managers
{
    public interface IApplicationManager
    {
        Task<List<IManufacturer>>  FindAllManufacturers(IUser currentUser);
        Task<List<IAttribute>> FindAllParametricsWithValues(IUser currentUser);


    }
}
