using System;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Common.Fields;
using Orchard.Core.Common.Models;
using Orchard.Core.Containers.Models;
using Orchard.Core.Contents.Extensions;
using Orchard.Core.Navigation.Models;
using Orchard.Autoroute.Models;
using Orchard.Comments.Models;
using Orchard.Core.Title.Models;
using Orchard.Data.Migration;
using Orchard.MediaLibrary.Fields;
using Orchard.Users.Models;
using Orchard.Widgets.Models;
using Orchard.PublishLater.Models;
using Orchard.Tags.Models;
using Orchard.Taxonomies.Models;
using Smu.VotedNews.Models;

namespace Smu.VotedNews
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable("NewsPartRecord", table => table
                // The following method will create an "Id" column for us and set it is the primary key for the table
                .ContentPartRecord()
                .Column<bool>("IsFetured")
                .Column<bool>("IsSticky")
                .Column<int>("Weight")
                );
            // Return the version that this feature will be after this method completes
            return 1;
        }

        public int UpdateFrom1()
        {
            // Create (or alter) a part called "ProductPart" and configure it to be "attachable".
            ContentDefinitionManager.AlterPartDefinition("NewsPart", part => part
                .WithField( "FeaturedImage", cfg => cfg
                        .OfType(typeof(MediaLibraryPickerField).Name)
                        .WithDisplayName("Featured Image")
                    )
                .WithField("NewsSummary", cfg => cfg
                        .OfType("TextField")
                        .WithDisplayName("News Summary")
                        .WithSetting("TextFieldSettings.Flavor", "html")
                    )
                .Attachable()
                .WithDescription("Adds ability to turn a content item into a news story")
                );

            ContentDefinitionManager.AlterTypeDefinition("NewsStory", type => type
                .WithPart(typeof(TitlePart).Name)
                .WithPart(typeof(NewsPart).Name)
                .WithPart(typeof(CommonPart).Name)
                .WithPart(typeof(AutoroutePart).Name)
                .WithPart(typeof(PublishLaterPart).Name)
                .WithPart(typeof(BodyPart).Name)
                .WithPart(typeof(CommentsPart).Name)
                .WithPart(typeof(TagsPart).Name)
                .WithPart(typeof(TaxonomyPart).Name)
                .Listable()
                .Creatable()
                .Draftable()
                );

            return 2;
        }
    }
}