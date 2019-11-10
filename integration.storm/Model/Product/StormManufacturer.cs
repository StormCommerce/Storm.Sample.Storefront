using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Storm.Model.Product
{
    public class StormManufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PartNo { get; set; }
        public string LogoPath { get; set; }
        public string LogoKey { get; set; }
        public string UniqueName { get; set; }
    }
}
