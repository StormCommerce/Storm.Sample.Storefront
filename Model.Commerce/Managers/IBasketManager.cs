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
    public interface IBasketManager
    {
        IBasket FindOrCreateBasket(IUser currentUser);
        IBasket CreateBasket(IUser currentUser);
        IBasket FindBasketById(IUser currentUser, string externalId);
        IBasket AddItem(IUser currentUser, string basketId, string partNo, int quantity);
        IBasket UpdateItem(IUser currentUser, string basketId, string partNo, int quantity);
        IBasket DeleteItem(IUser currentUser, string basketId, string partNo);
        
    }
}
