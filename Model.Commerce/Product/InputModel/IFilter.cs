using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Product.InputModel
{
    public interface IFilter
    {
        FilterType FilterType { get; set; }
        string ExternalId { get; set; }
        string Value { get; set; }
    }
}
