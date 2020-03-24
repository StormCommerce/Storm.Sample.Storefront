using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Commerce.Shopping
{
    public interface IPaymentResponse
    {
        string Reference { get; set; }
        string Html { get; set; }
    }
}
