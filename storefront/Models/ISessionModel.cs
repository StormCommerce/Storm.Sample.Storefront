using Model.Commerce.Customer;
using Model.Commerce.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storefront.Models
{
    public interface ISessionModel
    {
        IUser CurrentUser { get; set; }
        string CurrentBasketId { get; set; }
    }
}
