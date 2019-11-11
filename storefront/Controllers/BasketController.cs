using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Commerce.Dto.Shopping;
using Model.Commerce.Managers;
using Storefront.Models;

namespace Storefront.Controllers
{
    public class BasketController : Controller
    {
        private IBasketManager _basketManager;
        private ISessionModel _sessionModel;

        public BasketController(ISessionModel sessionModel, IBasketManager basketManager)
        {
            _basketManager = basketManager;
            _sessionModel = sessionModel;
        }



        public ActionResult Cart()
        {
            return View(GetCurrentBasket());
        }

        public ActionResult Checkout()
        {
            return View(GetCurrentBasket());
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