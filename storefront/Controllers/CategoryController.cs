﻿using System.Threading.Tasks;
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
        public async Task<IActionResult> Index()
        {
            var allCategories = await _categoryManager.FindAll(_sessionModel.CurrentUser);

            return View(allCategories);
        }

        [HttpGet]
        public async Task<JsonResult> AllCategories()
        {
            var allCategories = await _categoryManager.FindAll(_sessionModel.CurrentUser);

            return Json(allCategories);
        }
    }
}