using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Storm.Model.Product
{
    public class StormParametricInfo
    {    
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; }
        public string Description { get; set; }
        public string Uom { get; set; }
        public bool? IsVariantParametric { get; set; }
        public int? ValueType { get; set; }
        public string Code { get; set; }
        public bool? IsHidden { get; set; }
    }

}
