using Model.Commerce.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Dto.Product
{
    public class FileDto : IFile
    {
        public string ExternalId { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Type { get; set; }
    }
}
