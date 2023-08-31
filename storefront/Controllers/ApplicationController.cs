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
    public class ApplicationController: Controller
    {

        private IApplicationManager _applicationManager;
        private ISessionModel _sessionModel;
        public ApplicationController(IApplicationManager applicationManager, ISessionModel sessionModel)
        {
            _applicationManager = applicationManager;
            _sessionModel = sessionModel;
        }

        [HttpGet]
        public JsonResult AllManufacturers()
        {
            var allManufacturers = _applicationManager.FindAllManufacturers(_sessionModel.CurrentUser);
            return Json(allManufacturers);
        }


        [HttpGet]
        public JsonResult AllParametrics()
        {
            var allParametrics = _applicationManager.FindAllParametricsWithValues(_sessionModel.CurrentUser);
            return Json(allParametrics);
        }
    }
}
