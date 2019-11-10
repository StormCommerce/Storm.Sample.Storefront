using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Product
{
    public interface IAttributeValue
    {
        string AttributeCode { get; set; }
        string Code { get; set; }
        string Value { get; set; }
    }
}
