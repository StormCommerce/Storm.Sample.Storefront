using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Product
{
    public interface IAttributeValue
    {
        string ExternalId { get; set; }
        string AttributeCode { get; set; }
        string Name { get; set; }
        string Code { get; set; }
        string Value { get; set; }
        string Uom { get; set; }
        bool Hidden { get; set; }
    }
}
