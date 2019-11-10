using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Commerce.Managers;
using Storefront.Models;

namespace Storefront.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryManager _categoryManager;
        private ISessionModel _sessionModel;
        public CategoryController(ICategoryManager categoryManager, ISessionModel sessionModel)
        {
            _categoryManager = categoryManager;
            _sessionModel = sessionModel;
        }

        // Sample page for Categories
        public IActionResult Index()
        {
            var allCategories = _categoryManager.FindAll(_sessionModel.CurrentUser);

            return View(allCategories);
        }

        [HttpGet]
        public JsonResult AllCategories()
        {
            var allCategories = _categoryManager.FindAll(_sessionModel.CurrentUser);

            return Json(allCategories);
        }
    }
}