using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Customer
{
    public interface IUser
    {
        string ExternalId { get; set; }
        string Code { get; set; }
        string Name { get; set; }
        ICompany Company { get; set; }
        string CurrencyCode { get; set; }
        string LanguageCode { get; set; }
    }
}
