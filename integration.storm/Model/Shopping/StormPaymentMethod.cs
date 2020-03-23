using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Storm.Model.Shopping
{
    public class StormPaymentMethod
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? TypeId { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public string PartNo { get; set; }
        public decimal? Price { get; set; }
        public decimal? VatRate { get; set; }
        public bool? IsSelected { get; set; }
        public StormPaymentService Service { get; set; }
        public string ImageKey { get; set; }
        public bool? IsForCompanyOnly { get; set; }
        public bool? IsForPersonOnly { get; set; }
    }

    public class StormPaymentService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageKey { get; set; }
    }

}
