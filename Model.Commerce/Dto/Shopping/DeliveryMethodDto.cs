using Model.Commerce.Shopping;

namespace Model.Commerce.Dto.Shopping
{
    public class DeliveryMethodDto : IDeliveryMethod
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
        public string Code { get; set; }
        public string Carrier { get; set; }
    }
}
