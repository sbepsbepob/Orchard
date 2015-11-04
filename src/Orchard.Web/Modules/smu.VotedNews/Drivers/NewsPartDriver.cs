using System;
using System.Linq;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Smu.VotedNews.Models;
using Orchard.Comments.Services;
using Orchard.Comments.Models;

namespace Smu.VotedNews.Drivers
{
    public class NewsPartDriver : ContentPartDriver<NewsPart>
    {

        private readonly ICommentService _commentService;
        private readonly IContentManager _contentManager;

        public NewsPartDriver(
            ICommentService commentService,
            IContentManager contentManager)
        {
            _commentService = commentService;
            _contentManager = contentManager;
        }


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
//            var newsCommentAgree = _contentManager.Query<CommentsPart, CommentsPartRecord>().
            return Combined(
                
                // Shape 1: Parts_News
                ContentShape("Parts_News", () => shapeHelper.Parts_News(
                    IsFeatured: news.IsFetured,
                    IsSticky: news.IsSticky,
                    Weight: news.Weight
                )),

                // Shape 2: Parts_News_VoteButtons
                ContentShape("Parts_News_VoteButtons", () => shapeHelper.Parts_News_VoteButtons(
                    NewsId: news.Id
                )),

                // Shape 3: Parts_News_Comments
                ContentShape("Parts_News_Comments", () => shapeHelper.Parts_News_Comments(
                )),

                ContentShape("Parts_TopAgreeComment",
                    () => {
                        // create a hierarchy of shapes
                        var comments = _commentService
                            .GetCommentsForCommentedContent(news.ContentItem.Id)
                            .Where(x => x.Status == CommentStatus.Approved && x.ContentItemRecord.EnumerationField.Value == "Agree")
                            .OrderBy(x => x.Position)
                            .List()
                            .ToList();

                        foreach (var item in comments)
                        {
                            var shape = shapeHelper.Parts_Comment(ContentPart: item, ContentItem: item.ContentItem);
                            allShapes.Add(item.Id, shape);
                        }

                        foreach (var item in comments)
                        {
                            var shape = allShapes[item.Id];
                            if (item.RepliedOn.HasValue)
                            {
                                allShapes[item.RepliedOn.Value].Add(shape);
                            }
                            else
                            {
                                firstLevelShapes.Add(shape);
                            }
                        }

                        var list = shapeHelper.List(Items: firstLevelShapes);

                        return shapeHelper.Parts_ListOfComments(
                            List: list,
                            CommentCount: part.CommentsCount);
                    })

            );

        }


    }
}