using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Product
{
    public interface IVariant
    {
        string PartNo { get; set; }
        string VariantName { get; set; }
        string ImageUrl { get; set; }

        decimal? Price { get; set; }
        decimal? VatRate { get; set; }
        decimal? PreviousPrice { get; set; }
        
        bool Buyable { get; set; }

        string Url { get; set; }

        IList<IAttributeValue> Values { get; set; }
        string PriceListId { get; set; }
        string VendorPartNo { get; set; }
        string StockStatus { get; set; }
        decimal? AvailableToSell { get; set; }
        int LeadTime { get; set; }

    }
}
