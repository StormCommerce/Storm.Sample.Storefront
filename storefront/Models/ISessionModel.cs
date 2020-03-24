using Model.Commerce.Customer;
using Model.Commerce.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Storefront.Models
{
    public interface ISessionModel
    {
        IUser CurrentUser { get; set; }
        string CurrentBasketId { get; set; }
        string CurrentCheckoutId { get; set; }
    }
}
