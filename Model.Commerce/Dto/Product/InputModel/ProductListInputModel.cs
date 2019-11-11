using Model.Commerce.Product.InputModel;
using System;
using System.Collections.Generic;
using System.Text;

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
