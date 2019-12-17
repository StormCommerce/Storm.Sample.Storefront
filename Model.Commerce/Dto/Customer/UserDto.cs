using Model.Commerce.Customer;
using System;
using System.Collections.Generic;
using System.Text;
/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public List<string> PriceLists { get; set; }
    }
}
