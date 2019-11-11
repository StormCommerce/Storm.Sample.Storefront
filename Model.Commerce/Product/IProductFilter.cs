using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Product
{
    public interface IProductFilter
    {
        string Type { get; set; }
        string Name { get; set; }
        List<IProductFilterItem> Items { get; set; }
    }
}
