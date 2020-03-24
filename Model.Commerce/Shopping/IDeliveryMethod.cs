using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Shopping
{
    public interface IDeliveryMethod
    {
        string ExternalId { get; set; }
        string Name { get; set; }
        int? TypeId { get; set; }
        string TypeName { get; set; }
        string Description { get; set; }
        string PartNo { get; set; }
        decimal? Price { get; set; }
        decimal? VatRate { get; set; }
        bool? IsSelected { get; set; }
        string Code { get; set; }
        string Carrier { get; set; }
    }
}
