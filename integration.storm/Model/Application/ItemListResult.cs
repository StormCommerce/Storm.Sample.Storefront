using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Storm.Model.Application
{
    public class ItemListResult<T>
    {
        public int ItemCount { get; set; }
        public List<T> Items { get; set; }
    }
}
