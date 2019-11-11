using Model.Commerce.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Dto.Product
{
    public class ProductFilterItem : IProductFilterItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public int Count { get; set; }
        public List<IProductFilterItem> Items { get; set; }
    }
}
