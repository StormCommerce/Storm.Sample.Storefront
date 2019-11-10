using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Storm.Model.Product
{
    public class StormProductList
    {
        public int ItemCount { get; set; }
        public StormProductItem[] Items { get; set; }
    }
}
