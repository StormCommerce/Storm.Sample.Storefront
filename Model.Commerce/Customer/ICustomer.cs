using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Customer
{
    public interface ICustomer
    {
        string ExternalId { get; set; }
        string Code { get; set; }
        string SSN { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        ICompany Company { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        string MobilePhone { get; set; }
        IAddress InvoiceAddress { get; set; }
        List<IAddress> DeliveryAddresses { get; set; }

    }
}
