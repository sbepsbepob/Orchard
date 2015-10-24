using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace Smu.VotedNews.Models
{
    public class NewsPartRecord : ContentPartRecord
    {
        public virtual bool IsFetured { get; set; }
        public virtual int Weight { get; set; }
        public virtual bool IsSticky { get; set; }
    }
}