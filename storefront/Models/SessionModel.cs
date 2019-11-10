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


namespace Storefront.Models
{
    public class SessionModel : ISessionModel
    {
        IUser _currentUser = null;
        IConfiguration _configuration;
        IHttpContextAccessor _httpContextAccessor;
        string _basketId;

        public SessionModel(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public IUser CurrentUser {
            get { 
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
    }
}
