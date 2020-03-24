using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Customer
{
    public interface IAddress
    {

        int? Id { get; set; }
        string CareOf { get; set; }
        string Line1 { get; set; }
        string Line2 { get; set; }
        string Zip { get; set; }
        string City { get; set; }
        int? CountryId { get; set; }
        string Country { get; set; }
        string Region { get; set; }
        bool? IsValidated { get; set; }
        string GlobalLocationNo { get; set; }
        string ShippingPhoneNumber { get; set; }
    }
}
