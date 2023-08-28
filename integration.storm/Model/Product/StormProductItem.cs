
/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Integration.Storm.Model.Product
{
    
    public class StormProductItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubHeader { get; set; }
        public StormManufacturer Manufacturer { get; set; }
        public string FlagIdSeed { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceRecommended { get; set; }
        public decimal? PriceCatalog { get; set; }
        public decimal? VatRate { get; set; }
        public decimal? RecommendedQuantity { get; set; }
        public StormOnhand OnHand { get; set; }
        public StormOnhand OnHandStore { get; set; }
        public StormOnhand OnHandSupplier { get; set; }
        public string Key { get; set; }
        public string ImageKey { get; set; }
        public int? PopularityRank { get; set; }
        public int StatusId { get; set; }
        public string VariantName { get; set; }
        public string VariantImageKey { get; set; }
        public string AdditionalImageKeySeed { get; set; }
        public string GroupByKey { get; set; }
        public string VariantFlagIdSeed { get; set; }
        public string PartNo { get; set; }
        public int PriceListId { get; set; }
        public int SortOrder { get; set; }
        public int CategoryId { get; set; }
        public string ParametricListSeed { get; set; }
        public string ParametricMultipleSeed { get; set; }
        public string ParametricValueSeed { get; set; }
        public string VariantParametricSeed { get; set; }
        public string UniqueName { get; set; }
        public int? StockDisplayBreakPoint { get; set; }
        public bool IsBuyable { get; set; }
        public string SubDescription { get; set; }
        public int? Quantity { get; set; }
        public int Type { get; set; }
        public string CategoryIdSeed { get; set; }
        public bool IsRecommendedQuantityFixed { get; set; }
        public string Synonyms { get; set; }
        public string VariantUniqueName { get; set; }
        public bool IsSubscribable { get; set; }
        public string UnitOfMeasurement { get; set; }
        public decimal UnitOfMeasurementCount { get; set; }
        public string EanCode { get; set; }
        public decimal? PriceStandard { get; set; }
        public bool IsDangerousGoods { get; set; }
    }

    

    
}
