using ElasticExample.Domain.Entities;
using MediatR;

namespace ElasticExample.BusinessLogic.Events.Articles
{
    public record ArticleCreatedEvent : INotification
    {
        public ArticleCreatedEvent(ArticleEntity articleEntity)
        {
            ArticleEntity = articleEntity;
        }

        public ArticleEntity ArticleEntity { get; set; }
    }
}