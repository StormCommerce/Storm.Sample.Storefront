using Integration.Storm.Builder;
using Integration.Storm.Model.Customer;
using Integration.Storm.Model.Shopping;
using Microsoft.Extensions.Configuration;
using Model.Commerce.Customer;
using Model.Commerce.Dto.Customer;
using Model.Commerce.Dto.Product;
using Model.Commerce.Dto.Shopping;
using Model.Commerce.Managers;
using Model.Commerce.Shopping;
using System;
using System.Collections.Generic;
using System.Text;
/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Integration.Storm.Managers
{
    public class StormCheckoutManager: ICheckoutManager
    {
        IStormConnectionManager _stormConnectionManager;
        IProductManager _productManager;
        IConfiguration _configuration;
        IFormCheckoutProvider _formCheckoutProvider;

        public StormCheckoutManager(IStormConnectionManager connectionManager, IProductManager productManager, IConfiguration configuration, IFormCheckoutProvider checkoutProvider)
        {
            _stormConnectionManager = connectionManager;
            _productManager = productManager;
            _configuration = configuration;
            _formCheckoutProvider = checkoutProvider;
        }

        public ICheckout GetCheckout(IUser currentUser, string basketExternalId)
        {

            string pricelistseed = string.Empty;
            if (currentUser != null && currentUser.PriceLists != null)
            {
                pricelistseed = string.Join(",", currentUser.PriceLists);
            }
            string url = $"ShoppingService.svc/rest/GetCheckout2?format=json";
            url += $"&basketId={basketExternalId}";
            url += addUserUrlDetails(currentUser);

            var stormCheckout = _stormConnectionManager.GetResult<StormCheckout>(url);

            if (stormCheckout == null) return null;

            var checkout = StormCheckoutToCheckoutDto(stormCheckout);

            // Set a default payment method configured in the settings file as Storm:DefaultPaymentMethodId 
            var defaultPaymentMethod = _configuration["Storm:DefaultPaymentMethodId"];
            if( !string.IsNullOrEmpty(defaultPaymentMethod))
            {
                if( checkout.PaymentMethod == null )
                {
                    return SetPaymentMethod(currentUser, basketExternalId, defaultPaymentMethod);
                }
            }

            return checkout;
        }

        public ICheckout SetDeliveryMethod(IUser currentUser, string basketExternalId, string deliveryMethodId )
        {
            string url = $"ShoppingService.svc/rest/UpdateDeliveryMethod?format=json";
            url += $"&basketId={basketExternalId}";
            url += $"&deliveryMethodId={deliveryMethodId}";
            url += addUserUrlDetails(currentUser);
            var stormCheckout = _stormConnectionManager.PostResult<StormCheckout>(url);

            if (stormCheckout == null) return null;
            var checkout = StormCheckoutToCheckoutDto(stormCheckout);

            return checkout;
        }

        public ICheckout SetPaymentMethod(IUser currentUser, string basketExternalId, string paymentMethodId)
        {
            string url = $"ShoppingService.svc/rest/UpdatePaymentMethod?format=json";
            url += $"&basketId={basketExternalId}";
            url += $"&paymentMethodId={paymentMethodId}";
            url += addUserUrlDetails(currentUser);
            var stormCheckout = _stormConnectionManager.PostResult<StormCheckout>(url);

            if (stormCheckout == null) return null;
            var checkout = StormCheckoutToCheckoutDto(stormCheckout);

            return checkout;
        }


        public IPaymentResponse PaymentForm(IUser currentUser, string basketId)
        {
            return _formCheckoutProvider.PaymentForm(currentUser, basketId);
        }
        public IPaymentResponse PaymentComplete(string reference)
        {
            return _formCheckoutProvider.PaymentComplete(reference);
        }


        private CustomerDto CustomerToDto(StormCustomer stormCustomer)
        {
            CustomerBuilder builder = new CustomerBuilder();
            return builder.Build(stormCustomer);
        }


        private BasketDto BasketToDto(StormBasket stormBasket)
        {
            BasketBuilder basketBuilder = new BasketBuilder(_configuration);
            return basketBuilder.BuildBasketDto(stormBasket);
        }

        private ICheckout StormCheckoutToCheckoutDto(StormCheckout stormCheckout)
        {
            ICheckout checkout = new CheckoutDto
            {
                Basket = BasketToDto(stormCheckout.Basket),
                Buyer = CustomerToDto(stormCheckout.Buyer),
                Payer = CustomerToDto(stormCheckout.Payer),
                ShipTo = CustomerToDto(stormCheckout.ShipTo),
                PaymentMethods = new List<IPaymentMethod>(),
                DeliveryMethods = new List<IDeliveryMethod>()
            };

            // Find payment methods
            if (stormCheckout.PaymentMethods != null)
            {
                foreach (var paymentMethod in stormCheckout.PaymentMethods)
                {
                    PaymentMethodDto dto = new PaymentMethodDto();
                    dto.Description = paymentMethod.Description;
                    dto.ExternalId = paymentMethod.Id.ToString();
                    dto.IsSelected = paymentMethod.IsSelected;
                    dto.Name = paymentMethod.Name;
                    dto.PartNo = paymentMethod.PartNo;
                    dto.Price = paymentMethod.Price;
                    dto.TypeId = paymentMethod.TypeId;
                    dto.TypeName = paymentMethod.TypeName;
                    dto.VatRate = paymentMethod.VatRate;
                    checkout.PaymentMethods.Add(dto);

                    if (dto.IsSelected.HasValue && dto.IsSelected.Value)
                    {
                        checkout.PaymentMethod = dto;
                    }
                }
            }

            // Find delivery methods
            if (stormCheckout.DeliveryMethods != null)
            {
                foreach (var deliveryMethod in stormCheckout.DeliveryMethods)
                {
                    DeliveryMethodDto dto = new DeliveryMethodDto();
                    dto.ExternalId = deliveryMethod.Id.ToString();
                    dto.IsSelected = deliveryMethod.IsSelected;
                    dto.Name = deliveryMethod.Name;
                    dto.PartNo = deliveryMethod.PartNo;
                    dto.Price = deliveryMethod.Price;
                    dto.VatRate = deliveryMethod.VatRate;
                    dto.TypeId = deliveryMethod.TypeId;
                    dto.TypeName = deliveryMethod.TypeName;
                    checkout.DeliveryMethods.Add(dto);

                    if (dto.IsSelected.HasValue && dto.IsSelected.Value)
                    {
                        checkout.DeliveryMethod = dto;
                    }
                }
            }


            return checkout;

        }

        private string addUserUrlDetails(IUser currentUser)
        {
            string url = string.Empty;

            if (!string.IsNullOrEmpty(currentUser.CurrencyCode))
            {
                url += "&currencyId=" + currentUser.CurrencyCode;
            }

            if (!string.IsNullOrEmpty(currentUser.LanguageCode))
            {
                url += "&cultureCode=" + currentUser.LanguageCode;
            }

            if (currentUser != null && currentUser.PriceLists != null)
            {                
                url += "&pricelistSeed=" + string.Join(",", currentUser.PriceLists);
            }

            return url;

        }

        
    }
}
