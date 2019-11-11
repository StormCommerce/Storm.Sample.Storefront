using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Product
{
    public interface IProduct
    {
        string ExternalId { get; set; }
        string Name { get; set; }
        IManufacturer Manufacturer { get; set; }
        ICategory Category { get; set; }
        string ShortDescription { get; set; }
        string Description { get; set; }
        string PrimaryImageUrl { get; set; }
        IVariant PrimaryVariant { get; set; }
        IList<IVariant> Variants { get; set; }
        IList<IAttributeValue> Values { get; set; }
        List<IFile> Files { get; set; }
    }
}
