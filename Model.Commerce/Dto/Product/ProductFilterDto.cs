using Model.Commerce.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Dto.Product
{
    public class ProductFilterDto : IProductFilter
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public List<IProductFilterItem> Items { get; set; }
    }
}
