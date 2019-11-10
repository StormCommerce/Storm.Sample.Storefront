using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Commerce.Managers;
using Storefront.Models;

namespace Storefront.Controllers
{
    public class ProductController : Controller
    {
        IProductManager _productManager;
        ISessionModel _sessionModel;

        public ProductController(IProductManager productManager, ISessionModel sessionModel)
        {
            _productManager = productManager;
            _sessionModel = sessionModel;
        }



        public IActionResult OneProduct([FromRoute]string id)
        {
            var product = _productManager.FindByUrl(_sessionModel.CurrentUser, id);


            return View(product);
        }
    }
}