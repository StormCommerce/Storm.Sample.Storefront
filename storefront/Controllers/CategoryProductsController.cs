using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Commerce.Dto.Product.InputModel;
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
    public class CategoryProductsController : Controller
    {

        IProductManager _productManager;
        ISessionModel _sessionModel;

        public CategoryProductsController(IProductManager productManager, ISessionModel sessionModel)
        {
            _productManager = productManager;
            _sessionModel = sessionModel;
        }
        
        public async Task<IActionResult> Index([FromRoute]string id, int pageNumber)
        {
            ProductListInputModel query = new ProductListInputModel();
            query.CategoryIds = new List<string>() { id };
            query.PageNumber = pageNumber;


            var allProducts = await _productManager.FindByCategory(_sessionModel.CurrentUser, query);
            allProducts.CategoryId = id;

            return View(allProducts);
        }

        public async Task<IActionResult> Search(string q)
        {
            ProductListInputModel query = new ProductListInputModel();
            
            query.PageSize = 20;
            query.PageNumber = 1;
            query.Query = q;


            var allProducts = await _productManager.FindByCategory(_sessionModel.CurrentUser, query);

            return View(allProducts);
        }

        public async Task<JsonResult> Products([FromRoute]string id, int pageNumber)
        {
            ProductListInputModel query = new ProductListInputModel();
            query.CategoryIds = new List<string>() { id };
            query.PageNumber = pageNumber;


            var allProducts = await _productManager.FindByCategory(_sessionModel.CurrentUser, query).ConfigureAwait(false);

            allProducts.CategoryId = id;

            return Json(allProducts);
        }

        public async Task<JsonResult> Filters([FromRoute]string id)
        {
            ProductListInputModel query = new ProductListInputModel();
            query.CategoryIds = new List<string>() { id };

            var allFilters = await _productManager.FindAllFilters(_sessionModel.CurrentUser, query);

            return Json(allFilters);
        }

        public async Task<IActionResult> AjaxList([FromRoute]string id, int pageNumber)
        {
            ProductListInputModel query = new ProductListInputModel();
            query.CategoryIds = new List<string>() { id };
            query.PageNumber = pageNumber;


            var allProducts = await _productManager.FindByCategory(_sessionModel.CurrentUser, query);
            allProducts.CategoryId = id;

            return View(allProducts);
        }
    }
}