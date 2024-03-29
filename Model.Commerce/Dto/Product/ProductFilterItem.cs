﻿using Model.Commerce.Product;
using System.Collections.Generic;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Model.Commerce.Dto.Product
{
    public class ProductFilterItem : IProductFilterItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public int Count { get; set; }
        public List<IProductFilterItem> Items { get; set; }
    }
}
