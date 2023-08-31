using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    public class ProductController : Controller
    {
        IProductManager _productManager;
        ISessionModel _sessionModel;

        public ProductController(IProductManager productManager, ISessionModel sessionModel)
        {
            _productManager = productManager;
            _sessionModel = sessionModel;
        }



        public async Task<IActionResult> OneProduct([FromRoute]string id)
        {
            var product = await _productManager.FindByUrl(_sessionModel.CurrentUser, id);


            return View(product);
        }

        public async Task<IActionResult> Show([FromRoute]string id)
        {
            var product = await _productManager.FindByUrl(_sessionModel.CurrentUser, id);


            return View(product);
        }
    }
}