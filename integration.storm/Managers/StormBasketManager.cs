using Integration.Storm.Builder;
using Integration.Storm.Model.Shopping;
using Microsoft.Extensions.Configuration;
using Model.Commerce.Customer;
using Model.Commerce.Dto.Product;
using Model.Commerce.Dto.Shopping;
using Model.Commerce.Managers;
using Model.Commerce.Shopping;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Integration.Storm.Managers
{
    public class StormBasketManager : IBasketManager
    {
        IStormConnectionManager _stormConnectionManager;
        IProductManager _productManager;
        IConfiguration _configuration;

        public StormBasketManager(IStormConnectionManager connectionManager, IProductManager productManager, IConfiguration configuration)
        {
            _stormConnectionManager = connectionManager;
            _productManager = productManager;
            _configuration = configuration;
        }

        public async Task<IBasket> AddItem(IUser currentUser, string basketId, string partNo, int quantity)
        {
            // Find current item
            var product = await _productManager.FindByPartNo(currentUser, partNo);
            if (product == null) return null;

            var basket = await FindBasketById(currentUser, basketId);
            if (basket == null) return null;

            // This should be a firstOrDefault() but it does not work for unknown reason :-)
            foreach( var curitm in basket.Items )
            {
                if( curitm.PartNo.Equals(partNo))
                {
                    return await UpdateItem(currentUser, basketId, partNo, quantity + Convert.ToInt32(curitm.Quantity));
                }
            }

            StormBasketItem item = new StormBasketItem();
            item.PartNo = partNo;
            item.Quantity = quantity;
            item.PriceListId = Convert.ToInt32(product.PrimaryVariant.PriceListId);

            string url = $"ShoppingService.svc/rest/InsertBasketItem?basketid={basketId}&createdBy=1";

            var stormBasket = await _stormConnectionManager.PostResult<StormBasket>(url, item);

            return BasketToDto(stormBasket);
        }

        public async Task<IBasket> CreateBasket(IUser currentUser)
        {
            BasketDto dto = new BasketDto();

            StormBasket stormBasket = new StormBasket();
            stormBasket.Items = new List<StormBasketItem>();

            string url = "ShoppingService.svc/rest/CreateBasket?ipAddress=127.0.0.1&createdBy=1";

            if( !string.IsNullOrEmpty(currentUser.ExternalId))
            {
                stormBasket.CustomerId = Convert.ToInt32(currentUser.ExternalId);
            }
            if (currentUser.Company != null && !string.IsNullOrEmpty(currentUser.Company.ExternalId))
            {
                stormBasket.CompanyId = Convert.ToInt32(currentUser.Company.ExternalId);
            }
            stormBasket.CurrencyId =  Convert.ToInt32( currentUser.CurrencyCode );

            stormBasket = await _stormConnectionManager.PostResult<StormBasket>(url, stormBasket);

            dto.ExternalId = stormBasket.Id.ToString();
            dto.Items = new List<IBasketItem>();

            return dto;
        }

        public async Task<IBasket> DeleteItem(IUser currentUser, string basketId, string partNo)
        {
            throw new NotImplementedException();
        }

        public async Task<IBasket> FindBasketById(IUser currentUser, string externalId)
        {
            string pricelistseed = string.Empty;
            if( currentUser != null && currentUser.PriceLists != null )
            {
                pricelistseed = string.Join(",", currentUser.PriceLists);
            }


            string url = $"ShoppingService.svc/rest/GetBasket?id={externalId}&cultureCode={currentUser.LanguageCode}&currencyId={currentUser.CurrencyCode}&pricelistSeed={pricelistseed}";

            var stormBasket = await _stormConnectionManager.GetResult<StormBasket>(url);

            if (stormBasket == null) return null;
            if (!stormBasket.IsBuyable) return null;

            return BasketToDto(stormBasket);
        }

        public async Task<IBasket> FindOrCreateBasket(IUser currentUser)
        {
            throw new NotImplementedException();
        }

        public async Task<IBasket> UpdateItem(IUser currentUser, string basketId, string partNo, int quantity)
        {
            // Find current item
            var product = await _productManager.FindByPartNo(currentUser, partNo);
            if (product == null) return null;

            var basket = await FindBasketById(currentUser, basketId);
            if (basket == null) return null;

            // This should be a firstOrDefault() but it does not work for unknown reason :-)
            foreach (var curitm in basket.Items)
            {
                if (curitm.PartNo.Equals(partNo))
                {
                    StormBasketItem item = new StormBasketItem();
                    item.PartNo = partNo;
                    item.Quantity = quantity;
                    item.PriceListId = Convert.ToInt32(product.PrimaryVariant.PriceListId);
                    item.Id = Convert.ToInt32(curitm.ExternalId);

                    string url = $"ShoppingService.svc/rest/UpdateBasketItem?basketId={basketId}&item=";

                    var stormBasket = await _stormConnectionManager.PostResult<StormBasket>(url, item);

                    return BasketToDto(stormBasket);
                }
            }

            return basket;
        }

        private IBasket BasketToDto(StormBasket stormBasket)
        {
            BasketBuilder basketBuilder = new BasketBuilder(_configuration);
            return basketBuilder.BuildBasketDto(stormBasket);
        }

    }
}
