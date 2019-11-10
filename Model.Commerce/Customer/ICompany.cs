using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Customer
{
    public interface ICompany
    {
        string ExternalId { get; set; }
        string Code { get; set; }
        string Name { get; set; }
    }
}
