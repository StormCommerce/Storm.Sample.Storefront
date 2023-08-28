using Model.Commerce.Customer;
using System.Collections.Generic;

namespace Model.Commerce.Dto.Customer
{
    public class CustomerDto : ICustomer
    {
        public string ExternalId { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICompany Company { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string CurrencyCode { get; set; }
        public string LanguageCode { get; set; }
        public List<string> PriceLists { get; set; }
        public IAddress InvoiceAddress { get; set; }
        public string SSN { get; set; }
        public List<IAddress> DeliveryAddresses { get; set; }
    }
}
