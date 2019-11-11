using System;
using System.Collections.Generic;
using System.Text;
/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Model.Commerce.Product
{
    public interface IProductList
    {
        int ProductCount { get; set; }
        int PageNumber { get; set; }
        int NumberOfPages { get; }
        int PageSize { get; set; }
        IList<IProduct> Products { get; set; }
        string CategoryId { get; set; }
    }
}
