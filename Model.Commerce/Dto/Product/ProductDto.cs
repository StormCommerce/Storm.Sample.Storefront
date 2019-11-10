using Model.Commerce.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Dto.Product
{
    public class ProductDto : IProduct
    {
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public IManufacturer Manufacturer { get; set; }
        public ICategory Category { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string PrimaryImageUrl { get; set; }
        public string GroupByKey { get; set; }
        public IVariant PrimaryVariant { get; set; }
        public List<VariantDto> Variants { get; set; }
        IList<IVariant> IProduct.Variants { get=>Variants.ConvertAll(x=>(IVariant)x); set=>Variants=(List<VariantDto>)value; }
        public IList<IAttributeValue> Values { get; set; }
    }
}
