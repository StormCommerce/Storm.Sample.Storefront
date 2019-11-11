using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Storm.Model.Shopping
{
    public class StormBasket
    { 
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? CompanyId { get; set; }
        public int? SalesContactId { get; set; }
        public int StatusId { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string Comment { get; set; }
        public string OrderReference { get; set; }
        public string DiscountCode { get; set; }
        public int? ReferId { get; set; }
        public string ReferUrl { get; set; }
        public DateTime? ValidTo { get; set; }
        public bool IsEditable { get; set; }
        public List<StormBasketItem> Items { get; set; }
        public Info[] Info { get; set; }
        public Summary Summary { get; set; }
        public Appliedpromotion1[] AppliedPromotions { get; set; }
        public string IpAddress { get; set; }
        public int? AttestedBy { get; set; }
        public int TypeId { get; set; }
        public bool DoHold { get; set; }
        public bool IsBuyable { get; set; }
        public string InvoiceReference { get; set; }
        public int? PaymentMethodId { get; set; }
        public int? DeliveryMethodId { get; set; }
        public string Email { get; set; }
        public int[] CustomerFlags { get; set; }
        public int[] CompanyFlags { get; set; }
        public Nullbasket NullBasket { get; set; }
        public Extensiondata5 ExtensionData { get; set; }
    }

    public class Summary
    {
        public Items Items { get; set; }
        public Freigt Freigt { get; set; }
        public Fees Fees { get; set; }
        public Total Total { get; set; }
        public Extensiondata4 ExtensionData { get; set; }
    }

    public class Items
    {
        public decimal Amount { get; set; }
        public decimal Vat { get; set; }
        public Extensiondata ExtensionData { get; set; }
    }

    public class Extensiondata
    {
    }

    public class Freigt
    {
        public decimal Amount { get; set; }
        public decimal Vat { get; set; }
        public Extensiondata1 ExtensionData { get; set; }
    }

    public class Extensiondata1
    {
    }

    public class Fees
    {
        public decimal Amount { get; set; }
        public decimal Vat { get; set; }
        public Extensiondata2 ExtensionData { get; set; }
    }

    public class Extensiondata2
    {
    }

    public class Total
    {
        public decimal Amount { get; set; }
        public decimal Vat { get; set; }
        public Extensiondata3 ExtensionData { get; set; }
    }

    public class Extensiondata3
    {
    }

    public class Extensiondata4
    {
    }

    public class Nullbasket
    {
    }

    public class Extensiondata5
    {
    }

    public class Extensiondata6
    {
    }

    public class Info
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Code { get; set; }
        public int SortOrder { get; set; }
        public Extensiondata7 ExtensionData { get; set; }
    }

    public class Extensiondata7
    {
    }

    public class Extensiondata8
    {
    }

    
    public class Extensiondata9
    {
    }

    public class Parent
    {
    }

    public class Extensiondata10
    {
    }

    public class Info2
    {
        public int TypeId { get; set; }
        public string Value { get; set; }
        public string Code { get; set; }
        public Extensiondata11 ExtensionData { get; set; }
    }

    public class Extensiondata11
    {
    }

    public class Optionalitem
    {
    }

    public class Appliedpromotion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DiscountCode { get; set; }
        public decimal AppliedAmount { get; set; }
        public Extensiondata12 ExtensionData { get; set; }
    }

    public class Extensiondata12
    {
    }

    public class Info3
    {
        public int TypeId { get; set; }
        public string Value { get; set; }
        public string Code { get; set; }
        public Extensiondata13 ExtensionData { get; set; }
    }

    public class Extensiondata13
    {
    }

    public class Appliedpromotion1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Header { get; set; }
        public string ShortDescription { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ImageKey { get; set; }
        public string RequirementSeed { get; set; }
        public string DiscountCode { get; set; }
        public bool? IsExcludedFromPriceCalculation { get; set; }
        public bool? AllowProductListing { get; set; }
        public Image[] Images { get; set; }
        public Productfilter[] ProductFilters { get; set; }
        public decimal? AppliedAmount { get; set; }
        public string EffectSeed { get; set; }
        public decimal? FreightDiscountPct { get; set; }
        public bool? IsStackable { get; set; }
        public decimal? AppliedAmountIncVat { get; set; }
        public Extensiondata14 ExtensionData { get; set; }
    }

    public class Extensiondata14
    {
    }

    public class Image
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Key { get; set; }
        public Extensiondata15 ExtensionData { get; set; }
    }

    public class Extensiondata15
    {
    }

    public class Productfilter
    {
        public int? ManufacturerId { get; set; }
        public string CategorySeed { get; set; }
        public int? TypeId { get; set; }
        public int? ProductId { get; set; }
        public int? VariantProductId { get; set; }
        public string PartNo { get; set; }
        public int? PricelistId { get; set; }
        public int? FlagId { get; set; }
        public Extensiondata16 ExtensionData { get; set; }
    }

    public class Extensiondata16
    {
    }

}
