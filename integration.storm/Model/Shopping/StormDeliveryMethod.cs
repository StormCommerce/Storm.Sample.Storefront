namespace Integration.Storm.Model.Shopping
{
    public class StormDeliveryMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TypeId { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public string PartNo { get; set; }
        public decimal? Price { get; set; }
        public decimal? VatRate { get; set; }
        public bool? IsNotifiable { get; set; }
        public bool? IsSelected { get; set; }
        public string ImageKey { get; set; }
        public bool? IsForCompanyOnly { get; set; }
        public bool? IsForPersonOnly { get; set; }
        public decimal? Cost { get; set; }
        public int? StoreId { get; set; }
        public int? WarehouseId { get; set; }
        public int? LocationId { get; set; }
        public string Code { get; set; }
        public string Carrier { get; set; }
    }

}
