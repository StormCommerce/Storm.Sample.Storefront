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
    public class ProductListDto : IProductList
    {
        public int ProductCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public IList<IProduct> Products { get; set; }
        public string CategoryId { get; set; }
        public int NumberOfPages
        {
            get
            {
                if (PageSize == 0) return 1;
                return ProductCount / PageSize;
            }
        }
    }
}
