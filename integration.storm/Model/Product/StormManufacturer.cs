using System;
using System.Collections.Generic;
using System.Text;
/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Integration.Storm.Model.Product
{
    public class StormManufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PartNo { get; set; }
        public string LogoPath { get; set; }
        public string LogoKey { get; set; }
        public string UniqueName { get; set; }
    }
}
