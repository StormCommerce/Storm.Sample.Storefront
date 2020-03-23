using Integration.Storm.Model.Shopping;
using Microsoft.Extensions.Configuration;
using Model.Commerce.Customer;
using Model.Commerce.Dto.Product;
using Model.Commerce.Dto.Shopping;
using Model.Commerce.Managers;
using Model.Commerce.Shopping;
using System;
using System.Collections.Generic;
using System.Text;
/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Integration.Storm.Managers
{
    public class StormKcoManager
    {
        IStormConnectionManager _stormConnectionManager;
        IProductManager _productManager;
        IConfiguration _configuration;

        public StormKcoManager(IStormConnectionManager connectionManager, IProductManager productManager, IConfiguration configuration)
        {
            _stormConnectionManager = connectionManager;
            _productManager = productManager;
            _configuration = configuration;
        }


        /*public ICheckout GetCheckout(IUser currentUser, string basketId)
        {
            return null;
        }*/

    }
}
