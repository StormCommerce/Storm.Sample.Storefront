using Model.Commerce.Product;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Model.Commerce.Dto.Product
{
    public class AttributeValueDto : IAttributeValue
    {
        public string ExternalId { get; set; }
        public string AttributeCode { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Uom { get; set; }
        public bool Hidden { get; set; }
        public string GroupCode { get; set; }
        public string GroupExternalId { get; set; }
        public string QueryCode { get; set; }
    }
}
