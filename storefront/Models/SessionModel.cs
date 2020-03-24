using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Model.Commerce.Customer;
using Model.Commerce.Dto.Customer;
using Model.Commerce.Dto.Shopping;
using Model.Commerce.Managers;
using Model.Commerce.Shopping;
using Newtonsoft.Json;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Storefront.Models
{
    public class SessionModel : ISessionModel
    {
        IUser _currentUser = null;
        IConfiguration _configuration;
        IHttpContextAccessor _httpContextAccessor;
        string _basketId;
        string _checkoutId; 

        public SessionModel(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public IUser CurrentUser {
            get {
                if (_currentUser != null) return _currentUser;

                string userJson = _httpContextAccessor.HttpContext.Session.GetString("user");
                if( !string.IsNullOrEmpty(userJson))
                {
                    _currentUser = JsonConvert.DeserializeObject<UserDto>(userJson);
                }

                if( _currentUser == null )
                {
                    _currentUser = new UserDto();
                    _currentUser.LanguageCode = _configuration.GetValue<string>("defaultLanguage", "sv-SE");
                    _currentUser.CurrencyCode = _configuration.GetValue<string>("defaultCurrency", "2");
                }

                return _currentUser;
            }

            set
            {
                _currentUser = value;

                if( value != null ) { 
                    _httpContextAccessor.HttpContext.Session.SetString("user", JsonConvert.SerializeObject(value));
                } 
                else
                {
                    _httpContextAccessor.HttpContext.Session.Remove("user");
                }

            }
        }
        public string CurrentBasketId {
            get {
                if (_basketId != null) return _basketId;
                var basketId = _httpContextAccessor.HttpContext.Request.Cookies["basketId"];
                if( !string.IsNullOrEmpty(basketId) )
                {
                    return basketId;
                }
                return null;
            } 
            set {
                if( value != null ) { 
                    CookieOptions option = new CookieOptions();
                    option.Expires = DateTime.Now.AddMonths(1);               
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("basketId", value, option);
                } else
                {
                    _httpContextAccessor.HttpContext.Response.Cookies.Delete("basketId");
                }
                _basketId = value;
            } 
        }


        public string CurrentCheckoutId
        {
            get
            {
                if (_checkoutId != null) return _checkoutId;
                var checkoutId = _httpContextAccessor.HttpContext.Request.Cookies["checkoutId"];
                if (!string.IsNullOrEmpty(checkoutId))
                {
                    return checkoutId;
                }
                return null;
            }
            set
            {
                if (value != null)
                {
                    CookieOptions option = new CookieOptions();
                    option.Expires = DateTime.Now.AddMonths(1);
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("checkoutId", value, option);
                }
                else
                {
                    _httpContextAccessor.HttpContext.Response.Cookies.Delete("checkoutId");
                }
                _checkoutId = value;
            }
        }
    }
}
