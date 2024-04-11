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

        public async Task<ActionResult> Checkout()
        {
            var checkout = await _checkoutManager.GetCheckout(_sessionModel.CurrentUser, _sessionModel.CurrentBasketId);
            var paymentForm = await  _checkoutManager.PaymentForm(_sessionModel.CurrentUser, _sessionModel.CurrentBasketId);

            _sessionModel.CurrentCheckoutId = paymentForm.Reference;

            return View(paymentForm);
        }

        public async Task<ActionResult> OrderComplete()
        {
            var paymentForm = await _checkoutManager.PaymentComplete(_sessionModel.CurrentCheckoutId);

            _sessionModel.CurrentCheckoutId = null;
            _sessionModel.CurrentBasketId = null;

            return View(paymentForm);
        }


        public async Task<JsonResult> CheckoutJson()
        {
            var checkout = await _checkoutManager.GetCheckout(_sessionModel.CurrentUser, _sessionModel.CurrentBasketId);

            return Json(checkout);
        }

        public async Task<JsonResult> SetDeliveryMethod(string deliveryMethodId)
        {
            var checkout = await _checkoutManager.SetDeliveryMethod(_sessionModel.CurrentUser, _sessionModel.CurrentBasketId, deliveryMethodId);
            return Json(checkout);
        }

        public async Task<JsonResult> PaymentForm()
        {
            return Json(await _checkoutManager.PaymentForm(_sessionModel.CurrentUser, _sessionModel.CurrentBasketId));
        }

        public async Task<JsonResult> Minicart()
        {
            var basket = await GetCurrentBasket();
            return Json(basket);
        }

        private async Task<BasketDto> GetCurrentBasket()
        {
            var basketId = _sessionModel.CurrentBasketId;
            if (basketId == null)
            {
                return new BasketDto();
            }

            var basket = await _basketManager.FindBasketById(_sessionModel.CurrentUser, basketId);
            if (basket == null)
            {
                _sessionModel.CurrentBasketId = null;
                return new BasketDto();
            }

            return (BasketDto)basket;
        }

        public async Task<JsonResult> AddToCart(string partNo, int quantity)
        {
            var currentBasket = await GetCurrentBasket();
            if( string.IsNullOrEmpty(currentBasket.ExternalId))
            {
                currentBasket = (BasketDto)(await _basketManager.CreateBasket(_sessionModel.CurrentUser));
                _sessionModel.CurrentBasketId = currentBasket.ExternalId;
            }

            currentBasket = (BasketDto) (await _basketManager.AddItem(_sessionModel.CurrentUser, currentBasket.ExternalId, partNo, quantity));

            return Json(currentBasket);
        }

        public async Task<JsonResult> UpdateCart(string partNo, int quantity)
        {
            var currentBasket = await GetCurrentBasket();
            if (!string.IsNullOrEmpty(currentBasket.ExternalId))
            {
                var basket = await _basketManager.UpdateItem(_sessionModel.CurrentUser, currentBasket.ExternalId, partNo, quantity);
                return Json(basket);
            }

            return Json(currentBasket);
        }

        public async Task<JsonResult> RemoveFromCart(string partNo)
        {
            var currentBasket = await GetCurrentBasket();
            if (!string.IsNullOrEmpty(currentBasket.ExternalId))
            {
                var basket = await _basketManager.UpdateItem(_sessionModel.CurrentUser, currentBasket.ExternalId, partNo, 0);
                return Json(basket);
            }

            return Json(currentBasket);
        }
    }
}