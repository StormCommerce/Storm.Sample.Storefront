
using Integration.Storm.Model.Product;
using Model.Commerce.Dto.Product;
using Model.Commerce.Extensions;
using Model.Commerce.Product;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;


/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Integration.Storm.Builder
{
    public class ProductBuilder: IProductBuilder<StormProductItem, StormProduct>
    {
        IBuyableExtension _buyableExtension;
        IConfiguration _configuration;

        public ProductBuilder(IBuyableExtension buyableExtension, IConfiguration configuration)
        {
            _buyableExtension = buyableExtension;
            _configuration = configuration;
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
            p.PrimaryImageUrl = _configuration["Storm:ImagePrefix"] +  stormProductItem.ImageKey;
            p.ShortDescription = stormProductItem.SubDescription;

            p.Files = new List<IFile>();

            
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
            primaryVariant.ImageUrl = _configuration["Storm:ImagePrefix"] + (stormProductItem.VariantImageKey ?? stormProductItem.ImageKey);

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
            p.PrimaryImageUrl = _configuration["Storm:ImagePrefix"] + stormProduct.ImageKey;
            p.ShortDescription = stormProduct.SubDescription;
            p.Description = stormProduct.Description;

            p.Files = new List<IFile>();

            // Add default image
            FileDto primaryimagefile = new FileDto();
            p.Files.Add(primaryimagefile);

            primaryimagefile.ExternalId = stormProduct.ImageKey;
            primaryimagefile.ImageUrl = _configuration["Storm:ImagePrefix"] + stormProduct.ImageKey;
            primaryimagefile.Extension = "jpg";
            primaryimagefile.Name = stormProduct.Image;

            if ( stormProduct.Files != null )
            {
                foreach( var stormfile in stormProduct.Files  )
                {
                    FileDto filedto = new FileDto();
                    p.Files.Add(filedto);

                    filedto.ExternalId = stormfile.Key;
                    filedto.ImageUrl = _configuration["Storm:ImagePrefix"] + stormfile.Key;
                    filedto.Extension = stormfile.Extension;
                    filedto.Name = stormfile.Name;
                }
            }


            p.Values = new List<IAttributeValue>();
            foreach( var parametric in stormProduct.Parametrics )
            {
                AttributeValueDto av = new AttributeValueDto();
                av.Name = parametric.Name;
                av.Code = parametric.Value2;
                av.Value = parametric.Value;
                av.ExternalId = parametric.Id.ToString();
                av.Uom = parametric.Uom;
                av.AttributeCode = parametric.ValueId.HasValue ? parametric.ValueId.Value.ToString() : string.Empty;
                av.Hidden = parametric.IsHidden;
                p.Values.Add(av);
            }
            
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
                primaryVariant.ImageUrl = _configuration["Storm:ImagePrefix"] + stormProduct.ImageKey;

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
                    primaryVariant.ImageUrl = _configuration["Storm:ImagePrefix"] + stormVariant.ImageKey;

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
