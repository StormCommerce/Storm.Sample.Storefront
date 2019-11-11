using System;
using System.Collections.Generic;
using System.Text;
/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Model.Commerce.Product
{
    public interface IAttributeValue
    {
        string ExternalId { get; set; }
        string AttributeCode { get; set; }
        string Name { get; set; }
        string Code { get; set; }
        string Value { get; set; }
        string Uom { get; set; }
        bool Hidden { get; set; }
    }
}
