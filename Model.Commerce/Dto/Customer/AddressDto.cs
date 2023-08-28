using Model.Commerce.Customer;

namespace Model.Commerce.Dto.Customer
{
    public class AddressDto : IAddress
    {
        public int? Id { get; set; }
        public string CareOf { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public int? CountryId { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public bool? IsValidated { get; set; }
        public string GlobalLocationNo { get; set; }
        public string ShippingPhoneNumber { get; set; }
    }
}
