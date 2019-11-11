using Model.Commerce.Customer;
using Model.Commerce.Product;
using Model.Commerce.Product.InputModel;
using System;
using System.Collections.Generic;
using System.Text;
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

        public IProductList FindByCategory(IUser currentUser, IProductListInputModel query);
        public IProduct FindByPartNo(IUser currentUser, string partNo);
        public IProduct FindByUrl(IUser currentUser, string url);
        public IProductList Query(IUser currentUser, string query);
        public IList<IProductFilter> FindAllFilters(IUser currentUser, IProductListInputModel query);

    }
}
