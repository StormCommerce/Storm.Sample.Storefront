
/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Model.Commerce.Product
{
    public interface IProductFilterItem
    {
        string Id { get; set; }
        string Name { get; set; }
        string Value { get; set; }
        string Type { get; set; }
        int Count { get; set; }
    }
}
