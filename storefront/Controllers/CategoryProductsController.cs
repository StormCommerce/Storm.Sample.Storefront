using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Commerce.Dto.Product.InputModel;
using Model.Commerce.Managers;
using Storefront.Models;

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
        
        public IActionResult Index([FromRoute]string id, int pageNumber)
        {
            ProductListInputModel query = new ProductListInputModel();
            query.CategoryIds = new List<string>() { id };
            query.PageNumber = pageNumber;


            var allProducts = _productManager.FindByCategory(_sessionModel.CurrentUser, query);
            allProducts.CategoryId = id;

            return View(allProducts);
        }

        public IActionResult Search(string q)
        {
            ProductListInputModel query = new ProductListInputModel();
            
            query.PageSize = 20;
            query.PageNumber = 1;
            query.Query = q;


            var allProducts = _productManager.FindByCategory(_sessionModel.CurrentUser, query);

            return View(allProducts);
        }

        public JsonResult Products([FromRoute]string id, int pageNumber)
        {
            ProductListInputModel query = new ProductListInputModel();
            query.CategoryIds = new List<string>() { id };
            query.PageNumber = pageNumber;


            var allProducts = _productManager.FindByCategory(_sessionModel.CurrentUser, query);

            allProducts.CategoryId = id;

            return Json(allProducts);
        }

        public JsonResult Filters([FromRoute]string id)
        {
            ProductListInputModel query = new ProductListInputModel();
            query.CategoryIds = new List<string>() { id };

            var allFilters = _productManager.FindAllFilters(_sessionModel.CurrentUser, query);

            return Json(allFilters);
        }

        public IActionResult AjaxList([FromRoute]string id, int pageNumber)
        {
            ProductListInputModel query = new ProductListInputModel();
            query.CategoryIds = new List<string>() { id };
            query.PageNumber = pageNumber;


            var allProducts = _productManager.FindByCategory(_sessionModel.CurrentUser, query);
            allProducts.CategoryId = id;

            return View(allProducts);
        }
    }
}