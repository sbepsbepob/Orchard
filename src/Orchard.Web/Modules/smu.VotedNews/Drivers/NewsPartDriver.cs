using System;
using System.Linq;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Smu.VotedNews.Models;

namespace Smu.VotedNews.Drivers
{
    public class NewsPartDriver : ContentPartDriver<NewsPart>
    {

        protected override string Prefix
        {
            get { return "SmuNews"; }
        }

        protected override DriverResult Editor(NewsPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_News_Edit", () => shapeHelper
                .EditorTemplate(TemplateName: "Parts/News", Model: part, Prefix: Prefix));
        }

        protected override DriverResult Editor(NewsPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        protected override DriverResult Display(NewsPart news, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_News", () => shapeHelper.Parts_News(
                IsFeatured: news.IsFetured,
                IsSticky: news.IsSticky,
                Weight: news.Weight
            ));
        }


    }
}