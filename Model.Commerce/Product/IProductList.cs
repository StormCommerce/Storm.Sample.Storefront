using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Product
{
    public interface IProductList
    {
        int ProductCount { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
        IList<IProduct> Products { get; set; }

    }
}
