
/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Model.Commerce.Product.InputModel
{
    public interface IFilter
    {
        FilterType FilterType { get; set; }
        string ExternalId { get; set; }
        string Value { get; set; }
    }
}
