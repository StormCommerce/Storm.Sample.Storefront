using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Product
{
    public interface IProductFilterItem
    {
        string Id { get; set; }
        string Name { get; set; }
        string Value { get; set; }
        string Type { get; set; }
        int Count { get; set; }
    }
}
