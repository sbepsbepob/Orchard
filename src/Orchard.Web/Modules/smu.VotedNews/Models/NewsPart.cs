using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;

namespace Smu.VotedNews.Models
{
    public class NewsPart : ContentPart<NewsPartRecord>
    {
        public bool IsFetured
        {
            get { return Record.IsFetured; }
            set { Record.IsFetured = value; }
        }

        public int Weight
        {
            get { return Record.Weight; }
            set { Record.Weight = value; }
        }

        public bool IsSticky
        {
            get { return Record.IsSticky; }
            set { Record.IsSticky = value; }
        }

    }
}