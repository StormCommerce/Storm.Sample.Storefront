using Model.Commerce.Product;
using System;
using System.Collections.Generic;
using System.Text;
/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Model.Commerce.Extensions
{
    public interface IProductBuilder<T,P>
    {
        IProduct BuildFromItem(T stormProductItem);
        IProduct BuildFromProduct(P stormProduct);
    }
}
