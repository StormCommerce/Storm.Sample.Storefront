using Integration.Storm.Model.Product.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Storm.Model.Product
{
    public class StormProduct
    {
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PartNo { get; set; }
        public string SubHeader { get; set; }
        public StormManufacturer Manufacturer { get; set; }
        public string Image { get; set; }       
        public string FlagIdSeed { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceCatalog { get; set; }
        public decimal? PriceRecommended { get; set; }
        public decimal? PriceFreight { get; set; }
        public decimal? PriceFreightVatRate { get; set; }
        public decimal? VatRate { get; set; }
        public decimal? RecommendedQuantity { get; set; }
        public StormOnhand OnHand { get; set; }
        public StormOnhand OnHandStore { get; set; }
        public StormOnhand OnHandSupplier { get; set; }
        public StormVariant[] Variants { get; set; }
        public int PriceListId { get; set; }
        public string Key { get; set; }
        public DateTime Updated { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImageKey { get; set; }
        public StormParametric[] VariantParametrics { get; set; }
        public int StatusId { get; set; }
        public string MetaTags { get; set; }
        public string MetaDescription { get; set; }
        public string VariantName { get; set; }
        public string DescriptionHeader { get; set; }
        public string UniqueName { get; set; }
        public decimal? StockDisplayBreakPoint { get; set; }
        public StormParametric[] Parametrics { get; set; }
        public object[] Families { get; set; }
        public bool IsBuyable { get; set; }
        public string SubDescription { get; set; }
        public string Uom { get; set; }
        public decimal? UomCount { get; set; }
        public string EanCode { get; set; }
        public int Type { get; set; }
        public StormCategory[] Categories { get; set; }
        public bool IsRecommendedQuantityFixed { get; set; }
        public int? PopularityRank { get; set; }
        public decimal? CostPurchase { get; set; }
        public decimal? CostUnit { get; set; }
        public string Title { get; set; }
        public decimal? ActualWeight { get; set; }
        public bool IsDropShipOnly { get; set; }
        public string Synonyms { get; set; }
        public bool IsSubscribable { get; set; }
        public string UnspscCode { get; set; }
        public decimal? PriceStandard { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public decimal? Depth { get; set; }
        public bool IsDangerousGoods { get; set; }
    }

   

    

    /*public class Category
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Code { get; set; }
    }*/

}
