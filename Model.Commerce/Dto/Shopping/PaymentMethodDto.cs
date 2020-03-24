using Model.Commerce.Shopping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Dto.Shopping
{
    public class PaymentMethodDto : IPaymentMethod
    {
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public int? TypeId { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public string PartNo { get; set; }
        public decimal? Price { get; set; }
        public decimal? VatRate { get; set; }
        public bool? IsSelected { get; set; }
    }
}
