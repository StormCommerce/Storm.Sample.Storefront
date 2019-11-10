using Integration.Storm.Model.Shopping;
using Model.Commerce.Customer;
using Model.Commerce.Dto.Product;
using Model.Commerce.Dto.Shopping;
using Model.Commerce.Managers;
using Model.Commerce.Shopping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Storm.Managers
{
    public class StormBasketManager : IBasketManager
    {
        IStormConnectionManager _stormConnectionManager;
        IProductManager _productManager;

        public StormBasketManager(IStormConnectionManager connectionManager, IProductManager productManager)
        {
            _stormConnectionManager = connectionManager;
            _productManager = productManager;
        }

        public IBasket AddItem(IUser currentUser, string basketId, string partNo, int quantity)
        {
            // Find current item
            var product = _productManager.FindByPartNo(currentUser, partNo);
            if (product == null) return null;

            var basket = FindBasketById(currentUser, basketId);
            if (basket == null) return null;

            // This should be a firstOrDefault() but it does not work for unknown reason :-)
            foreach( var curitm in basket.Items )
            {
                if( curitm.PartNo.Equals(partNo))
                {
                    return UpdateItem(currentUser, basketId, partNo, quantity + Convert.ToInt32(curitm.Quantity));
                }
            }

            StormBasketItem item = new StormBasketItem();
            item.PartNo = partNo;
            item.Quantity = quantity;
            item.PriceListId = Convert.ToInt32(product.PrimaryVariant.PriceListId);

            string url = $"ShoppingService.svc/rest/InsertBasketItem?basketid={basketId}&item=&createdBy=1";

            var stormBasket = _stormConnectionManager.PostResult<StormBasket>(url, item);

            return BasketToDto(stormBasket);
        }

        public IBasket CreateBasket(IUser currentUser)
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

            stormBasket = _stormConnectionManager.PostResult<StormBasket>(url, stormBasket);

            dto.ExternalId = stormBasket.Id.ToString();
            dto.Items = new List<IBasketItem>();

            return dto;
        }

        public IBasket DeleteItem(IUser currentUser, string basketId, string partNo)
        {
            throw new NotImplementedException();
        }

        public IBasket FindBasketById(IUser currentUser, string externalId)
        {
            string url = $"ShoppingService.svc/rest/GetBasket?id={externalId}&cultureCode={currentUser.LanguageCode}&currencyId={currentUser.CurrencyCode}";

            var stormBasket = _stormConnectionManager.GetResult<StormBasket>(url);

            if (stormBasket == null) return null;
            if (!stormBasket.IsBuyable) return null;

            return BasketToDto(stormBasket);
        }

        public IBasket FindOrCreateBasket(IUser currentUser)
        {
            throw new NotImplementedException();
        }

        public IBasket UpdateItem(IUser currentUser, string basketId, string partNo, int quantity)
        {
            // Find current item
            var product = _productManager.FindByPartNo(currentUser, partNo);
            if (product == null) return null;

            var basket = FindBasketById(currentUser, basketId);
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

                    var stormBasket = _stormConnectionManager.PostResult<StormBasket>(url, item);

                    return BasketToDto(stormBasket);
                }
            }

            return basket;
            
        }




        private BasketDto BasketToDto(StormBasket basket)
        {
            BasketDto dto = new BasketDto();

            dto.ExternalId = basket.Id.ToString();
            dto.Items = new List<IBasketItem>();
            dto.Shipping = basket.Summary.Freigt.Amount;
            dto.ShippingInclVat = basket.Summary.Freigt.Amount + basket.Summary.Freigt.Vat;
            dto.Total = basket.Summary.Total.Amount;
            dto.TotalInclVat = basket.Summary.Total.Vat + dto.Total;
            dto.TotalVat = basket.Summary.Total.Vat;

            foreach( var stormItem in basket.Items )
            {
                BasketItemDto itemdto = new BasketItemDto();
                itemdto.ExternalId = stormItem.Id.ToString();
                itemdto.ImageUrl = stormItem.ImageKey;
                itemdto.Name = stormItem.Name;
                itemdto.PartNo = stormItem.PartNo;
                itemdto.Quantity = Convert.ToInt32(stormItem.Quantity);
                itemdto.Price = stormItem.PriceDisplay.Value;
                itemdto.PricePrevious = stormItem.PriceOriginal;
                itemdto.VatRate = stormItem.VatRate.Value;

                dto.Items.Add(itemdto);
            }

            return dto;
        }
    }
}
