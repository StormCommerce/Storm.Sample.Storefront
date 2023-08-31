using Model.Commerce.Product;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
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
