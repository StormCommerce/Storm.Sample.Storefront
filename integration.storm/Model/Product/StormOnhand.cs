using System;
using System.Collections.Generic;
using System.Text;

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
