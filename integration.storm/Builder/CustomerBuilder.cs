using Integration.Storm.Model.Customer;
using Model.Commerce.Dto.Customer;

namespace Integration.Storm.Builder
{
    public class CustomerBuilder
    {

        public CustomerDto Build(StormCustomer stormCustomer)
        {
            CustomerDto dto = new CustomerDto();

            dto.ExternalId = stormCustomer.Id.ToString();
            dto.FirstName = stormCustomer.FirstName;
            dto.LastName = stormCustomer.LastName;
            dto.Phone = stormCustomer.Phone;
            dto.Email = stormCustomer.Email;

            return dto;
        }

    }
}
