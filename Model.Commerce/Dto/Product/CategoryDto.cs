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
    public class CategoryDto : ICategory
    {
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public string Code { get; set; }
        public int Level { get; set; }
        public List<ICategory> Children { get; set; }
    }
}
