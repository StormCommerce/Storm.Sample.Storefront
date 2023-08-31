using Model.Commerce.Customer;
using Model.Commerce.Product;
using Model.Commerce.Product.InputModel;
using System.Collections.Generic;
using System.Threading.Tasks;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Model.Commerce.Managers
{
    public interface IProductManager
    {

        Task<IProductList> FindByCategory(IUser currentUser, IProductListInputModel query);
        Task<IProduct> FindByPartNo(IUser currentUser, string partNo);
        Task<IProduct> FindByUrl(IUser currentUser, string url);
        Task<IProductList> Query(IUser currentUser, string query);
        Task<IList<IProductFilter>> FindAllFilters(IUser currentUser, IProductListInputModel query);

    }
}
