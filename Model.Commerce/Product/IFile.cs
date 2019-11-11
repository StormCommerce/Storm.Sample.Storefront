using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Product
{
    public interface IFile
    {
        string ExternalId { get; set; }
        string Name { get; set; }
        string Extension { get; set; }
        string Type { get; set; }
        string ImageUrl { get; set; }
    }
}
