using Model.Commerce.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Dto.Product
{
    public class AttributeValueDto : IAttributeValue
    {
        public string AttributeCode { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
    }
}
