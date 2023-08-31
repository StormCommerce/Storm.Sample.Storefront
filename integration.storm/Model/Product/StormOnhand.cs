using System;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Integration.Storm.Model.Product
{
    public class StormOnhand
    {
        public decimal? Value { get; set; }
        public decimal? IncomingValue { get; set; }
        public DateTime? NextDeliveryDate { get; set; }
        public int? LeadtimeDayCount { get; set; }
        public DateTime? LastChecked { get; set; }
        public bool IsActive { get; set; }
        public bool IsReturnable { get; set; }
    }

}
