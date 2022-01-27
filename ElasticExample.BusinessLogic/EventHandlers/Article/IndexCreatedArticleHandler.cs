using ElasticExample.BusinessLogic.Events.Articles;
using ElasticExample.Elasticsearch.Indices;
using MediatR;
using Nest;

namespace ElasticExample.BusinessLogic.EventHandlers.Article
{
    internal class IndexCreatedArticleHandler : INotificationHandler<ArticleCreatedEvent>
    {
        private readonly IElasticClient _elasticsearchClient;

        public IndexCreatedArticleHandler(IElasticClient elasticClient)
        {
            _elasticsearchClient = elasticClient;
        }

        public async Task Handle(ArticleCreatedEvent notification, CancellationToken cancellationToken)
        {
            var mappedIndex = new ArticleIndex
            {
                Id = notification.ArticleEntity.Id,
                Title = notification.ArticleEntity.Title,
                Content = notification.ArticleEntity.Content,
                CreateDate = notification.ArticleEntity.CreatedDate,
                UpdateDate = notification.ArticleEntity.UpdateDate
            };

            await _elasticsearchClient.IndexAsync(mappedIndex, x => x.Index("articles"), cancellationToken);
        }
    }
}
