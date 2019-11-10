using Model.Commerce.Customer;
using Model.Commerce.Product;
using Model.Commerce.Product.InputModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Managers
{
    public interface IProductManager
    {

        public IProductList FindByCategory(IUser currentUser, IProductListInputModel query);
        public IProduct FindByPartNo(IUser currentUser, string partNo);
        public IProduct FindByUrl(IUser currentUser, string url);
        public IProductList Query(IUser currentUser, string query);

    }
}
