using Integration.Storm.Model.Customer;
using Model.Commerce.Customer;
using Model.Commerce.Dto.Customer;
using Model.Commerce.Managers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Integration.Storm.Managers
{
    public class StormAccountManager : IAccountManager
    {
        IStormConnectionManager _stormConnectionManager;

        public StormAccountManager(IStormConnectionManager stormConnectionManager)
        {
            _stormConnectionManager = stormConnectionManager;
        }

        public IUser Login(string username, string password)
        {

            string u = WebUtility.UrlEncode(username);
            string p = WebUtility.UrlEncode(password);

            string url = $"CustomerService.svc/rest/Login?loginName={username}&password={password}";
            var user = _stormConnectionManager.GetResult<StormCustomer>(url);

            if (user == null || user.Id == 0) return null;

            UserDto dto = new UserDto();

            dto.ExternalId = user.Id.ToString();
            dto.FirstName = user.FirstName;
            dto.LastName = user.LastName;
            dto.Address1 = user.InvoiceAddress?.Line1;
            dto.Address2 = user.InvoiceAddress?.Line2;
            dto.Zip = user.InvoiceAddress?.Zip;
            dto.Phone = user.CellPhone;
            dto.City = user.InvoiceAddress?.City;
            dto.Email = user.Email;
            dto.Code = user.Code;

            if( user.PricelistIds != null )
            {
                dto.PriceLists = new List<string>();
                foreach( var entry in user.PricelistIds )
                {
                    dto.PriceLists.Add(entry.ToString());
                }
            }


            return dto;
        }

        public IUser FindById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
