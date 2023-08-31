
/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
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
