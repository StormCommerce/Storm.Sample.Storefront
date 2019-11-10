using Integration.Storm.Model.Product;
using Model.Commerce.Dto.Product;
using Model.Commerce.Extensions;
using Model.Commerce.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Storm.Builder
{
    public class ProductBuilder: IProductBuilder<StormProductItem, StormProduct>
    {
        IBuyableExtension _buyableExtension;

        public ProductBuilder(IBuyableExtension buyableExtension)
        {
            _buyableExtension = buyableExtension;
        }


        public IProduct BuildFromItem(StormProductItem stormProductItem)
        {

            var p = new ProductDto();

            p.Category = new CategoryDto();
            p.Category.ExternalId = stormProductItem.CategoryId.ToString();
            p.GroupByKey = stormProductItem.GroupByKey;
            p.Name = stormProductItem.Name;

            p.Manufacturer = new ManufacturerDto();
            p.Manufacturer.Name = stormProductItem.Manufacturer.Name;
            p.Manufacturer.ExternalId = stormProductItem.Manufacturer.Id.ToString();
            p.Manufacturer.ImageUrl = stormProductItem.Manufacturer.LogoKey;

            p.ExternalId = stormProductItem.Id.ToString();
            p.PrimaryImageUrl = stormProductItem.ImageKey;
            p.ShortDescription = stormProductItem.SubDescription;
            p.Variants = new List<VariantDto>();

            var primaryVariant = new VariantDto();
            p.Variants.Add(primaryVariant);
            p.PrimaryVariant = primaryVariant;

            primaryVariant.PartNo = stormProductItem.PartNo;
            primaryVariant.PreviousPrice = stormProductItem.PriceStandard;
            primaryVariant.Price = stormProductItem.Price;
            primaryVariant.PriceListId = stormProductItem.PriceListId.ToString();
            primaryVariant.VatRate = stormProductItem.VatRate;
            primaryVariant.VendorPartNo = stormProductItem.Manufacturer.PartNo;
            primaryVariant.VariantName = stormProductItem.VariantName ?? stormProductItem.Name;
            primaryVariant.Url = stormProductItem.VariantUniqueName ?? stormProductItem.UniqueName;

            primaryVariant.AvailableToSell = 0.0M;
            if( stormProductItem.OnHand != null )
            {
                primaryVariant.AvailableToSell = stormProductItem.OnHand.Value;
                primaryVariant.LeadTime = stormProductItem.OnHand.LeadtimeDayCount ?? 0;
            }
            if (stormProductItem.OnHandSupplier != null)
            {
                if( primaryVariant.AvailableToSell == 0 )
                {
                    primaryVariant.LeadTime = stormProductItem.OnHandSupplier.LeadtimeDayCount ?? 0;

                }
                primaryVariant.AvailableToSell += stormProductItem.OnHandSupplier.Value;
            }

            if (stormProductItem.IsBuyable)
            {
                primaryVariant.Buyable = _buyableExtension.Buyable(p, primaryVariant);
            }
            primaryVariant.StockStatus = _buyableExtension.StockStatus(p, primaryVariant);

            return p;
        }

        public IProduct BuildFromProduct(StormProduct stormProduct)
        {
            var p = new ProductDto();

            p.Category = new CategoryDto();
            p.Category.ExternalId = stormProduct.CategoryId.ToString();

            p.Manufacturer = new ManufacturerDto();
            p.Manufacturer.Name = stormProduct.Manufacturer.Name;
            p.Manufacturer.ExternalId = stormProduct.Manufacturer.Id.ToString();
            p.Manufacturer.ImageUrl = stormProduct.Manufacturer.LogoKey;
            
            p.ExternalId = stormProduct.Id.ToString();
            p.PrimaryImageUrl = stormProduct.ImageKey;
            p.ShortDescription = stormProduct.SubDescription;
            p.Variants = new List<VariantDto>();

            if( stormProduct.Variants == null || stormProduct.Variants.Length == 0 ) { 

                var primaryVariant = new VariantDto();
                p.Variants.Add(primaryVariant);
                p.PrimaryVariant = primaryVariant;

                primaryVariant.PartNo = stormProduct.PartNo;
                primaryVariant.PreviousPrice = stormProduct.PriceStandard;
                primaryVariant.Price = stormProduct.Price;
                primaryVariant.PriceListId = stormProduct.PriceListId.ToString();
                primaryVariant.VatRate = stormProduct.VatRate;
                primaryVariant.VendorPartNo = stormProduct.Manufacturer.PartNo;
                primaryVariant.VariantName = stormProduct.Name;

                primaryVariant.AvailableToSell = 0.0M;
                if (stormProduct.OnHand != null)
                {
                    primaryVariant.AvailableToSell = stormProduct.OnHand.Value;
                    primaryVariant.LeadTime = stormProduct.OnHand.LeadtimeDayCount ?? 0;
                }
                if (stormProduct.OnHandSupplier != null)
                {
                    if (primaryVariant.AvailableToSell == 0)
                    {
                        primaryVariant.LeadTime = stormProduct.OnHandSupplier.LeadtimeDayCount??0;

                    }
                    primaryVariant.AvailableToSell += stormProduct.OnHandSupplier.Value;
                }

                if (stormProduct.IsBuyable)
                {
                    primaryVariant.Buyable = _buyableExtension.Buyable(p, primaryVariant);
                }
                primaryVariant.StockStatus = _buyableExtension.StockStatus(p, primaryVariant);
            } else
            {
                foreach(var stormVariant in stormProduct.Variants)
                {
                    var primaryVariant = new VariantDto();
                    p.Variants.Add(primaryVariant);

                    primaryVariant.PartNo = stormVariant.PartNo;
                    primaryVariant.PreviousPrice = stormVariant.PriceStandard;
                    primaryVariant.Price = stormVariant.Price;
                    primaryVariant.PriceListId = stormVariant.PriceListId.ToString();
                    primaryVariant.VatRate = stormVariant.VatRate;
                    //primaryVariant.VendorPartNo = stormVariant.Manufacturer.PartNo;
                    primaryVariant.VariantName = stormVariant.VariantName;

                    primaryVariant.AvailableToSell = 0.0M;
                    if (stormVariant.OnHand != null)
                    {
                        primaryVariant.AvailableToSell = stormVariant.OnHand.Value;
                        primaryVariant.LeadTime = stormVariant.OnHand.LeadtimeDayCount ?? 0;
                    }
                    if (stormVariant.OnHandSupplier != null)
                    {
                        if (primaryVariant.AvailableToSell == 0)
                        {
                            primaryVariant.LeadTime = stormVariant.OnHandSupplier.LeadtimeDayCount ?? 0;

                        }
                        primaryVariant.AvailableToSell += stormVariant.OnHandSupplier.Value;
                    }

                    if (stormProduct.IsBuyable)
                    {
                        primaryVariant.Buyable = _buyableExtension.Buyable(p, primaryVariant);
                    }
                    primaryVariant.StockStatus = _buyableExtension.StockStatus(p, primaryVariant);
                }
                p.PrimaryVariant = p.Variants[0];
            }

            return p;
        }
    }
}
