using Model.Commerce.Product;
using System.Collections.Generic;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Model.Commerce.Dto.Product
{
    public class ProductDto : IProduct
    {
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public IManufacturer Manufacturer { get; set; }
        public ICategory Category { get; set; }
        public List<IFile> Files { get; set; }
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
