using Integration.Storm.Model.Shopping;
using Microsoft.Extensions.Configuration;
using Model.Commerce.Dto.Shopping;
using Model.Commerce.Shopping;
using System;
using System.Collections.Generic;

namespace Integration.Storm.Builder
{
    public class BasketBuilder
    {
        private IConfiguration _configuration;

        public BasketBuilder(IConfiguration configuration )
        {
            _configuration = configuration;
        }

        public BasketDto BuildBasketDto(StormBasket basket)
        {
            BasketDto dto = new BasketDto();

            dto.ExternalId = basket.Id.ToString();
            dto.Items = new List<IBasketItem>();
            dto.Shipping = basket.Summary.Freigt.Amount;
            dto.ShippingInclVat = basket.Summary.Freigt.Amount + basket.Summary.Freigt.Vat;
            dto.Total = basket.Summary.Total.Amount;
            dto.TotalInclVat = basket.Summary.Total.Vat + dto.Total;
            dto.TotalVat = basket.Summary.Total.Vat;
            dto.NumberOfItems = 0;

            foreach (var stormItem in basket.Items)
            {
                if (stormItem.Type.HasValue && _configuration["Storm:ExcludeTypeFromBasket"].Contains(stormItem.Type.Value.ToString()))
                {
                    continue;
                }

                decimal? priceStandard = null;
                if (stormItem.PriceStandard.HasValue && stormItem.PriceStandard.Value > 0)
                {
                    priceStandard = stormItem.PriceStandard.Value;
                }

                BasketItemDto itemdto = new BasketItemDto();
                itemdto.ExternalId = stormItem.Id.ToString();
                itemdto.ImageUrl = _configuration["Storm:ImagePrefix"] + stormItem.ImageKey;
                itemdto.Name = stormItem.Name;
                itemdto.PartNo = stormItem.PartNo;
                itemdto.Quantity = Convert.ToInt32(stormItem.Quantity);
                itemdto.Price = stormItem.PriceDisplay.Value;
                itemdto.PricePrevious = priceStandard;
                itemdto.VatRate = stormItem.VatRate.Value;
                itemdto.Url = stormItem.UniqueName;
                dto.NumberOfItems += Convert.ToInt32(itemdto.Quantity);

                dto.Items.Add(itemdto);
            }

            return dto;
        }

    }
}
