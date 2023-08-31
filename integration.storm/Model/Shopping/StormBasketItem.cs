using Integration.Storm.Model.Product;
using System;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Integration.Storm.Model.Shopping
{
    public class StormBasketItem
    {
    
        public int? Id { get; set; }
        public int? LineNo { get; set; }
        public int? ParentLineNo { get; set; }
        public int? ProductId { get; set; }
        public string PartNo { get; set; }
        public string ManufacturerPartNo { get; set; }
        public string Name { get; set; }
        public string SubHeader { get; set; }
        public string ThumbnailImage { get; set; }
        public string FlagIdSeed { get; set; }
        public int? Type { get; set; }
        public decimal? PriceDisplay { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceOriginal { get; set; }
        public decimal? Cost { get; set; }
        public decimal? VatRate { get; set; }
        public decimal? Quantity { get; set; }
        public string UOM { get; set; }
        public decimal? UOMCount { get; set; }
        public string Comment { get; set; }
        public int? PriceListId { get; set; }
        public int? ReferId { get; set; }
        public string ReferUrl { get; set; }
        public bool? IsEditable { get; set; }
        public bool? IsDiscountable { get; set; }
        public Info2[] Info { get; set; }
        public Optionalitem[] OptionalItems { get; set; }
        public decimal? OnHandValue { get; set; }
        public decimal? IncomingValue { get; set; }
        public DateTime? NextDeliveryDate { get; set; }
        public int? LeadtimeDayCount { get; set; }
        public string PromotionIdSeed { get; set; }
        public string ImageKey { get; set; }
        public string ManufacturerName { get; set; }
        public int? CategoryId { get; set; }
        public StormOnhand OnHand { get; set; }
        public StormOnhand OnHandSupplier { get; set; }
        public decimal? PriceRecommended { get; set; }
        public int? ManufacturerId { get; set; }
        public string UniqueName { get; set; }
        public int? StatusId { get; set; }
        public int? StockDisplayBreakPoint { get; set; }
        public decimal? PriceCatalog { get; set; }
        public bool? IsBuyable { get; set; }
        public string SubDescription { get; set; }
        public string CategoryIdSeed { get; set; }
        public decimal? RecommendedQuantity { get; set; }
        public bool? IsRecommendedQuantityFixed { get; set; }
        public Appliedpromotion[] AppliedPromotions { get; set; }
        public string RequirementPromotionIdSeed { get; set; }
        public bool? IsSubscribable { get; set; }
        public string DescriptionHeader { get; set; }
        public bool? IsPriceManual { get; set; }
        public decimal? PriceStandard { get; set; }
        public string EanCode { get; set; }
        public bool? IsHidden { get; set; }
        public bool? IsAnyManagedErpPackage { get; set; }
        public bool? IsManagedPackage { get; set; }
        public bool? IsAnyManagedPackage { get; set; }
        public Parent Parent { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Length { get; set; }
        public Extensiondata10 ExtensionData { get; set; }
    }


}
