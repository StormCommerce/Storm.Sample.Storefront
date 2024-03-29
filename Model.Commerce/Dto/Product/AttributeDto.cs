﻿using Model.Commerce.Product;
using System.Collections.Generic;

namespace Model.Commerce.Dto.Product
{
    public class AttributeDto : IAttribute
    {
        public string ExternalId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Uom { get; set; }

        public ValueType ValueType { get; set; }

        public List<AttributeValueDto> Values { get; set; }

        List<IAttributeValue> IAttribute.Values { get => Values!=null ?  Values.ConvertAll(x=>(IAttributeValue)x) : null; }
    }
}
