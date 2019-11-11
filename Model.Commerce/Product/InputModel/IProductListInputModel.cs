using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Product.InputModel
{
    public interface IProductListInputModel
    {

        List<string> CategoryIds { get; set; }
        List<string> FlagIds { get; set; }
        List<string> ManufacturerIds { get; set; }
        List<IFilter> Filters { get; set; }
        int PageSize { get; set; }
        int PageNumber { get; set; }
        string Query { get; set; }
    }
}
