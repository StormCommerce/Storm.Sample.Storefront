using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Storm.Model.Customer
{
    public class StormCustomer
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public string SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string ReferId { get; set; }
        public string ReferUrl { get; set; }
        public Account Account { get; set; }
        //public object[] Companies { get; set; }
        public Address[] DeliveryAddresses { get; set; }
        public Address InvoiceAddress { get; set; }
        //public object[] Flags { get; set; }
        public bool? UseInvoiceAddressAsDeliveryAddress { get; set; }
        //public object[] Info { get; set; }
        public object[] PricelistIds { get; set; }
    }

    public class Account
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string LoginName { get; set; }
        public string Name { get; set; }
        //public object[] Roles { get; set; }
        //public object[] Authorizations { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
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
