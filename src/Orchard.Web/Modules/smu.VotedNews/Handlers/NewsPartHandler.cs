using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Smu.VotedNews.Models;

namespace Smu.VotedNews.Handlers
{
    public class NewsPartHandler : ContentHandler
    {
        public NewsPartHandler(IRepository<NewsPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}