using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Commerce.Dto.Shopping;
using Model.Commerce.Managers;
using Storefront.Models;
/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Storefront.Controllers
{
    public class BasketController : Controller
    {
        private IBasketManager _basketManager;
        private ISessionModel _sessionModel;
        private ICheckoutManager _checkoutManager;

        public BasketController(ISessionModel sessionModel, IBasketManager basketManager, ICheckoutManager checkoutManager)
        {
            _basketManager = basketManager;
            _sessionModel = sessionModel;
            _checkoutManager = checkoutManager;
        }



        public ActionResult Cart()
        {
            return View(GetCurrentBasket());
        }

        public ActionResult Checkout()
        {
            var checkout = _checkoutManager.GetCheckout(_sessionModel.CurrentUser, _sessionModel.CurrentBasketId);
            var paymentForm = _checkoutManager.PaymentForm(_sessionModel.CurrentUser, _sessionModel.CurrentBasketId);

            _sessionModel.CurrentCheckoutId = paymentForm.Reference;

            return View(paymentForm);
        }

        public ActionResult OrderComplete()
        {
            var paymentForm = _checkoutManager.PaymentComplete(_sessionModel.CurrentCheckoutId);

            _sessionModel.CurrentCheckoutId = null;
            _sessionModel.CurrentBasketId = null;

            return View(paymentForm);
        }


        public JsonResult CheckoutJson()
        {
            var checkout = _checkoutManager.GetCheckout(_sessionModel.CurrentUser, _sessionModel.CurrentBasketId);

            return Json(checkout);
        }

        public JsonResult SetDeliveryMethod(string deliveryMethodId)
        {
            var checkout = _checkoutManager.SetDeliveryMethod(_sessionModel.CurrentUser, _sessionModel.CurrentBasketId, deliveryMethodId);
            return Json(checkout);
        }

        public JsonResult PaymentForm()
        {
            return Json(_checkoutManager.PaymentForm(_sessionModel.CurrentUser, _sessionModel.CurrentBasketId));
        }

        public JsonResult Minicart()
        {
            return Json(GetCurrentBasket());
        }

        private BasketDto GetCurrentBasket()
        {
            var basketId = _sessionModel.CurrentBasketId;
            if (basketId == null)
            {
                return new BasketDto();
            }

            var basket = _basketManager.FindBasketById(_sessionModel.CurrentUser, basketId);
            if (basket == null)
            {
                _sessionModel.CurrentBasketId = null;
                return new BasketDto();
            }

            return (BasketDto)basket;
        }

        public JsonResult AddToCart(string partNo, int quantity)
        {
            var currentBasket = GetCurrentBasket();
            if( string.IsNullOrEmpty(currentBasket.ExternalId))
            {
                currentBasket = (BasketDto)_basketManager.CreateBasket(_sessionModel.CurrentUser);
                _sessionModel.CurrentBasketId = currentBasket.ExternalId;
            }

            currentBasket = (BasketDto)_basketManager.AddItem(_sessionModel.CurrentUser, currentBasket.ExternalId, partNo, quantity);

            return Json(currentBasket);
        }

        public JsonResult UpdateCart(string partNo, int quantity)
        {
            var currentBasket = GetCurrentBasket();
            if (!string.IsNullOrEmpty(currentBasket.ExternalId))
            {
                var basket = _basketManager.UpdateItem(_sessionModel.CurrentUser, currentBasket.ExternalId, partNo, quantity);
                return Json(basket);
            }

            return Json(currentBasket);
        }

        public JsonResult RemoveFromCart(string partNo)
        {
            var currentBasket = GetCurrentBasket();
            if (!string.IsNullOrEmpty(currentBasket.ExternalId))
            {
                var basket = _basketManager.UpdateItem(_sessionModel.CurrentUser, currentBasket.ExternalId, partNo, 0);
                return Json(basket);
            }

            return Json(currentBasket);
        }
    }
}