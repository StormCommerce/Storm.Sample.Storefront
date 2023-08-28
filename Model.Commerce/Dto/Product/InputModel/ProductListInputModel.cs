using Model.Commerce.Product.InputModel;
using System.Collections.Generic;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Model.Commerce.Dto.Product.InputModel
{
    public class ProductListInputModel : IProductListInputModel
    {
        public List<string> CategoryIds { get; set; }
        public List<string> FlagIds { get; set; }
        public List<string> ManufacturerIds { get; set; }
        public List<IFilter> Filters { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string Query { get; set; }
    }
}
