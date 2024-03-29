﻿using System.Collections.Generic;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Model.Commerce.Product.InputModel
{
    public interface IProductListInputModel
    {

        List<string> CategoryIds { get; set; }
        List<string> FlagIds { get; set; }
        List<string> ManufacturerIds { get; set; }
        List<IFilter> Filters { get; set; }
        int PageSize { get; set; }
        int PageNumber { get; set; }
        string Query { get; set; }
    }
}
