using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Skywalker.Webshop.Models;

namespace Skywalker.Webshop.Handlers
{
    public class AddressPartHandler : ContentHandler
    {
        public AddressPartHandler(IRepository<AddressPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}