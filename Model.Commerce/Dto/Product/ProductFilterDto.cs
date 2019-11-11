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
namespace Model.Commerce.Dto.Product
{
    public class ProductFilterDto : IProductFilter
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public List<IProductFilterItem> Items { get; set; }
    }
}
