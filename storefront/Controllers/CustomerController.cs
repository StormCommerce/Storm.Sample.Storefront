using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Commerce.Customer;
using Model.Commerce.Dto.Customer;
using Model.Commerce.Managers;
using Storefront.Models;

namespace Storefront.Controllers
{
    public class CustomerController : Controller
    {
        private IAccountManager _accountManager;
        private ISessionModel _sessionModel;
        private IHttpContextAccessor _httpContextAccessor;

        public CustomerController(IAccountManager accountManager, ISessionModel sessionModel, IHttpContextAccessor httpContextAccessor)
        {
            _accountManager = accountManager;
            _sessionModel = sessionModel;
            _httpContextAccessor = httpContextAccessor;
        }
        //
        // public IActionResult Index()
        // {
        //     return View();
        // }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Login([FromBody]LoginInputModel loginInputModel)
        {
            IUser user = await _accountManager.Login(loginInputModel.Username, loginInputModel.Password);

            if( user == null )
            {
                _httpContextAccessor.HttpContext.Response.StatusCode = 401;
                return Json(new UserDto());
            }

            _sessionModel.CurrentUser = user;

            return Json(user);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            _sessionModel.CurrentUser = null;

            return View();
        }

        public JsonResult Me()
        {
            return Json(_sessionModel.CurrentUser);
        }
    }
}