using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Storm.Model.Product
{
    public class StormParametric
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int Id { get; set; }
        public int? ValueId { get; set; }
        public string Description { get; set; }
        public string ValueDescription { get; set; }
        public bool IsPrimary { get; set; }
        public string ValueIdSeed { get; set; }
        public string Value2 { get; set; }
        public string Uom { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int SortOrder { get; set; }
        public object Code { get; set; }
        public bool IsHidden { get; set; }
    }
}
