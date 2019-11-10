using Model.Commerce.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Dto.Customer
{
    public class UserDto : IUser
    {
        public string ExternalId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public ICompany Company { get; set; }
        public string CurrencyCode { get; set; }
        public string LanguageCode { get; set; }
    }
}
