using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Storm.Model.Product
{
    public class StormFilter
    {
    
        public string Name { get; set; }
        public string Type { get; set; }
        public Item[] Items { get; set; }
    }

    public class Item
    {
        public string __type { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string Uom { get; set; }
        public int? Count { get; set; }
        public int? FalseCount { get; set; }

        public string Description { get; set; }
        public string Code { get; set; }
        public string SortOrder { get; set; }
        public Item[] Items { get; set; }

    }

}
