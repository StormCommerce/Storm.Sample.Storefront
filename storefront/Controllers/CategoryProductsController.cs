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

            return View(allProducts);
        }
    }
}