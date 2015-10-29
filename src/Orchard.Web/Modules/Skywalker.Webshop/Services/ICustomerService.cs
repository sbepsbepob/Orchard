using Orchard;
using Skywalker.Webshop.Models;

namespace Skywalker.Webshop.Services
{
    public interface ICustomerService : IDependency
    {
        CustomerPart CreateCustomer(string email, string password);
        AddressPart GetAddress(int customerId, string addressType);
        AddressPart CreateAddress(int customerId, string addressType);
    }
}