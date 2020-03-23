using Model.Commerce.Customer;
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
namespace Model.Commerce.Managers
{
    public interface ICheckoutManager
    {
        ICheckout GetCheckout(IUser currentUser, string basketExternalId);
    }
}
