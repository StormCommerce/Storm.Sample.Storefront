using System.Collections.Generic;

namespace Model.Commerce.Product
{
    public interface IAttribute
    {
        string ExternalId { get; }
        string Name { get; }
        string Code { get; }
        string Uom { get; }
        ValueType ValueType { get; }
        List<IAttributeValue> Values { get; }
    }
}
