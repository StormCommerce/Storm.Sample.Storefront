using Model.Commerce.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Dto.Product
{
    public class VariantDto : IVariant
    {
        public string PartNo { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        
        public string VariantName { get; set; }
        public decimal? Price { get; set; }
        public decimal? VatRate { get; set; }
        public decimal? PreviousPrice { get; set; }
        public bool Buyable { get; set; }
        public IList<IAttributeValue> Values { get; set; }

        public string PriceListId { get; set; }
        public string VendorPartNo { get; set; }
        public string StockStatus { get; set; }
        public decimal? AvailableToSell { get; set; }
        public int LeadTime { get; set; }
    }
}
