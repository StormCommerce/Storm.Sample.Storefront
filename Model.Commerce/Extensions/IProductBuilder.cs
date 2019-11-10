using Model.Commerce.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Extensions
{
    public interface IProductBuilder<T,P>
    {
        IProduct BuildFromItem(T stormProductItem);
        IProduct BuildFromProduct(P stormProduct);
    }
}
