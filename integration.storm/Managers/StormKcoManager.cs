﻿using Integration.Storm.Model.Shopping;
using Microsoft.Extensions.Configuration;
using Model.Commerce.Customer;
using Model.Commerce.Dto.Shopping;
using Model.Commerce.Managers;
using Model.Commerce.Shopping;
using System.Collections.Generic;
using System.Threading.Tasks;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Integration.Storm.Managers
{
    public class StormKcoManager: IFormCheckoutProvider
    {
        IStormConnectionManager _stormConnectionManager;
        IProductManager _productManager;
        IConfiguration _configuration;

        const string FORM_CHECKOUT_PROVIDER = "KCOv3";

        public StormKcoManager(IStormConnectionManager connectionManager, IProductManager productManager, IConfiguration configuration)
        {
            _stormConnectionManager = connectionManager;
            _productManager = productManager;
            _configuration = configuration;
        }

        public async Task<IPaymentResponse> PaymentComplete(string reference)
        {
            List<StormNameValue> list = new List<StormNameValue>();
            list.Add(new StormNameValue() { Name = "checkoutId", Value = reference });
            list.Add(new StormNameValue() { Name = "PaymentService", Value = "KlarnaCheckoutV3" });

            string url = $"ShoppingService.svc/rest/PaymentCallback?format=json";
            var paymentResponse = await _stormConnectionManager.PostResult<StormPaymentResponse>(url, list);

            PaymentResponseDto dto = new PaymentResponseDto();
            dto.Html = paymentResponse.PaymentReference;
            dto.FormCheckoutProvider = FORM_CHECKOUT_PROVIDER;

            return dto;
        }

        public async Task<IPaymentResponse> PaymentForm(IUser currentUser, string basketId)
        {
            var baseUrl = _configuration["Storm:BaseUrl"];

            List<StormNameValue> list = new List<StormNameValue>();
            list.Add(new StormNameValue() { Name = "mobile", Value = "false" });
            list.Add(new StormNameValue() { Name = "termsurl", Value = baseUrl + "/terms" });
            list.Add(new StormNameValue() { Name = "checkouturl", Value = baseUrl + "/Basket/Checkout" });
            list.Add(new StormNameValue() { Name = "confirmationurl", Value = baseUrl + "/Basket/OrderComplete" });

            string url = $"ShoppingService.svc/rest/GetPaymentForm?format=json";

            url += "&basketId=" + basketId;
            url += "&ipAddress=" + "172.16.98.1";
            url += "&userAgent=" + "unknown";

            if( currentUser.PriceLists != null )
            {
                url += "&priceListSeed=" + string.Join(",", currentUser.PriceLists);
            }


            var paymentResponse = await _stormConnectionManager.PostResult<StormPaymentResponse>(url, list);

            PaymentResponseDto dto = new PaymentResponseDto();

            dto.Reference = paymentResponse.RedirectUrl;
            dto.Html = paymentResponse.PaymentReference;
            dto.FormCheckoutProvider = FORM_CHECKOUT_PROVIDER;

            return dto;
        }

    }
}
