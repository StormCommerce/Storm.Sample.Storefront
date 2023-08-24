using Model.Commerce.Customer;
using Model.Commerce.Shopping;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        Task<IBasket> FindOrCreateBasket(IUser currentUser);
        Task<IBasket> CreateBasket(IUser currentUser);
        Task<IBasket> FindBasketById(IUser currentUser, string externalId);
        Task<IBasket> AddItem(IUser currentUser, string basketId, string partNo, int quantity);
        Task<IBasket> UpdateItem(IUser currentUser, string basketId, string partNo, int quantity);
        Task<IBasket> DeleteItem(IUser currentUser, string basketId, string partNo);
        
    }
}
