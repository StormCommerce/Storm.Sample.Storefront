using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Product
{
    public interface IManufacturer
    {
        string ExternalId { get; set; }
        string Code { get; set; }
        string Name { get; set; }
        string ImageUrl { get; set; }
    }
}
