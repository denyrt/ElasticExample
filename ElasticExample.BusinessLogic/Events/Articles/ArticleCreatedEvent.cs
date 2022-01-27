using MediatR;

namespace ElasticExample.BusinessLogic.Events.Articles
{
    internal record ArticleCreatedEvent : INotification
    {
        public ArticleCreatedEvent(Guid articleId)
        {
            ArticleId = articleId;
        }

        public Guid ArticleId { get; set; }
    }
}